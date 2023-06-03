using Service.API;
using DataLayer.API;

namespace ServiceTest
{
    [TestClass]
    public class ServiceTests
    {
        private readonly IDataRepository _repository = new MockDataRepository();

        [TestMethod]
        public async Task UserServiceTests()
        {
            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);
            //int id, string firstName, string lastName
            await userCrud.AddUserAsync(1, "John", "Doe");
            //int id
            IUserDTO user = await userCrud.GetUserAsync(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("John", user.FirstName);
            Assert.AreEqual("Doe", user.LastName);

            Assert.IsNotNull(await userCrud.GetAllUsersAsync());
            Assert.IsTrue(await userCrud.GetUsersCountAsync() > 0);

            await userCrud.UpdateUserAsync(1, "Johnny", "Doer");

            IUserDTO updatedUser = await userCrud.GetUserAsync(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.Id);
            Assert.AreEqual("Johnny", updatedUser.FirstName);
            Assert.AreEqual("Doer", updatedUser.LastName);

            await userCrud.DeleteUserAsync(1);
        }

        [TestMethod]
        public async Task ProductServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProductDTO product = await productCrud.GetProductAsync(1);

            Assert.IsNotNull(product);
            Assert.AreEqual(1, product.Id);
            Assert.AreEqual("Black Coffee", product.ProductName);
            Assert.AreEqual("Strong blend", product.ProductDescription);
            Assert.AreEqual(3.5, product.Price);

            Assert.IsNotNull(await productCrud.GetAllProductsAsync());
            Assert.IsTrue(await productCrud.GetProductsCountAsync() > 0);

            await productCrud.UpdateProductAsync(1, "Latte", "Milk and Coffee", 4);

            IProductDTO updatedProduct = await productCrud.GetProductAsync(1);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(1, updatedProduct.Id);
            Assert.AreEqual("Latte", updatedProduct.ProductName);
            Assert.AreEqual("Milk and Coffee", updatedProduct.ProductDescription);
            Assert.AreEqual(4, updatedProduct.Price);

            await productCrud.DeleteProductAsync(1);
        }

        [TestMethod]
        public async Task StateServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProductDTO product = await productCrud.GetProductAsync(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);
            //int id, int productId
            await stateCrud.AddStateAsync(1, product.Id, true);

            IStateDTO state = await stateCrud.GetStateAsync(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.StateId);
            Assert.AreEqual(1, state.ProductId);
            Assert.AreEqual(true, state.Available);

            await stateCrud.UpdateStateAsync(1, product.Id, false);

            IStateDTO updatedState = await stateCrud.GetStateAsync(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.StateId);
            Assert.AreEqual(1, updatedState.ProductId);
            Assert.AreEqual(false, updatedState.Available);

            await stateCrud.DeleteStateAsync(1);
            await productCrud.DeleteProductAsync(1);
        }

        [TestMethod]
        public async Task PlaceEventServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProductDTO product = await productCrud.GetProductAsync(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);
            //int id, int productId
            await stateCrud.AddStateAsync(1, product.Id, true);

            IStateDTO state = await stateCrud.GetStateAsync(1);

            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            //int id, string firstName, string lastName
            await userCrud.AddUserAsync(1, "John", "Doe");

            IUserDTO user = await userCrud.GetUserAsync(1);

            IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);
            //int id, int stateId, int userId, DateTime occurrenceDate, string type, int quantity = 0
            await eventCrud.AddEventAsync(1, state.StateId, user.Id, "PlacedEvent");

            user = await userCrud.GetUserAsync(1);
            state = await stateCrud.GetStateAsync(1);

            Assert.AreEqual(true, state.Available);

            await eventCrud.DeleteEventAsync(1);
            await stateCrud.DeleteStateAsync(1);
            await productCrud.DeleteProductAsync(1);
            await userCrud.DeleteUserAsync(1);
        }

        [TestMethod]
        public async Task PayedEventServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);

            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(1, "Cappucino", "Flavorful", 2);

            IProductDTO product = await productCrud.GetProductAsync(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);

            await stateCrud.AddStateAsync(1, product.Id, true);

            IStateDTO state = await stateCrud.GetStateAsync(1);

            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            await userCrud.AddUserAsync(1, "John", "Doe");

            IUserDTO user = await userCrud.GetUserAsync(1);

            IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);

            await eventCrud.AddEventAsync(1, state.StateId, user.Id, "PlacedEvent");

            await eventCrud.AddEventAsync(2, state.StateId, user.Id, "PayedEvent");

            user = await userCrud.GetUserAsync(1);
            state = await stateCrud.GetStateAsync(1);

            Assert.AreEqual(true, state.Available);

            await eventCrud.DeleteEventAsync(2);
            await eventCrud.DeleteEventAsync(1);
            await stateCrud.DeleteStateAsync(1);
            await productCrud.DeleteProductAsync(1);
            await userCrud.DeleteUserAsync(1);
        }
    }
}
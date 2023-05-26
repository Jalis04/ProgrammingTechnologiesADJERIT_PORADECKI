using Service.API;
using DataLayer.API;

namespace ServiceTest
{
    [TestClass]
    public class ServiceTests
    {
        private readonly IDataRepository _repository = IDataRepository.CreateDatabase();

        [TestMethod]
        public async Task UserServiceTests()
        {
            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);
            //int id, string firstName, string lastName
            await userCrud.AddUserAsync(1, "John", "Doe");
            //int id
            IUserDTO user = await userCrud.GetUserAsync(1);

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Doe", user.lastName);

            Assert.IsNotNull(await userCrud.GetAllUsersAsync());
            Assert.IsTrue(await userCrud.GetUsersCountAsync() > 0);

            await userCrud.UpdateUserAsync(1, "Johnny", "Doer");

            IUserDTO updatedUser = await userCrud.GetUserAsync(1);

            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(1, updatedUser.id);
            Assert.AreEqual("Johnny", updatedUser.firstName);
            Assert.AreEqual("Doer", updatedUser.lastName);

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
            Assert.AreEqual(1, product.id);
            Assert.AreEqual("Black Coffee", product.productName);
            Assert.AreEqual("Strong blend", product.productDescription);
            Assert.AreEqual(3.5, product.price);

            Assert.IsNotNull(await productCrud.GetAllProductsAsync());
            Assert.IsTrue(await productCrud.GetProductsCountAsync() > 0);

            await productCrud.UpdateProductAsync(1, "Latte", "Milk and Coffee", 4);

            IProductDTO updatedProduct = await productCrud.GetProductAsync(1);

            Assert.IsNotNull(updatedProduct);
            Assert.AreEqual(1, updatedProduct.id);
            Assert.AreEqual("Latte", updatedProduct.productName);
            Assert.AreEqual("Milk and Coffee", updatedProduct.productDescription);
            Assert.AreEqual(4, updatedProduct.price);

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
            await stateCrud.AddStateAsync(1, product.id, true);

            IStateDTO state = await stateCrud.GetStateAsync(1);

            Assert.IsNotNull(state);
            Assert.AreEqual(1, state.stateId);
            Assert.AreEqual(1, state.productId);
            Assert.AreEqual(false, state.available);

            await stateCrud.UpdateStateAsync(1, product.id, false);

            IStateDTO updatedState = await stateCrud.GetStateAsync(1);

            Assert.IsNotNull(updatedState);
            Assert.AreEqual(1, updatedState.stateId);
            Assert.AreEqual(1, updatedState.productId);
            Assert.AreEqual(false, updatedState.available);

            await stateCrud.DeleteStateAsync(1);
            await productCrud.DeleteProductAsync(1);
        }

        [TestMethod]
        public async Task PurchaseEventServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);
            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProductDTO product = await productCrud.GetProductAsync(1);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);
            //int id, int productId
            await stateCrud.AddStateAsync(1, product.id, true);

            IStateDTO state = await stateCrud.GetStateAsync(1);

            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            //int id, string firstName, string lastName
            await userCrud.AddUserAsync(1, "John", "Doe");

            IUserDTO user = await userCrud.GetUserAsync(1);

            IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);
            //int id, int stateId, int userId, DateTime occurrenceDate, string type, int quantity = 0
            await eventCrud.AddEventAsync(1, state.stateId, user.id, "PurchaseEvent");

            user = await userCrud.GetUserAsync(1);
            state = await stateCrud.GetStateAsync(1);

            Assert.AreEqual(true, state.available);

            await eventCrud.DeleteEventAsync(1);
            await stateCrud.DeleteStateAsync(1);
            await productCrud.DeleteProductAsync(1);
            await userCrud.DeleteUserAsync(1);
        }

        [TestMethod]
        public async Task ReturnEventServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);

            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(2, "Cappucino", "Flavorful", 2);

            IProductDTO product = await productCrud.GetProductAsync(2);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);

            await stateCrud.AddStateAsync(2, product.id, true);

            IStateDTO state = await stateCrud.GetStateAsync(2);

            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            await userCrud.AddUserAsync(2, "John", "Doe");

            IUserDTO user = await userCrud.GetUserAsync(2);

            IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);

            await eventCrud.AddEventAsync(2, state.stateId, user.id, "PlaceEvent");

            await eventCrud.AddEventAsync(3, state.stateId, user.id, "PayOrderEvent");

            user = await userCrud.GetUserAsync(2);
            state = await stateCrud.GetStateAsync(2);

            Assert.AreEqual(10, state.available);

            await eventCrud.DeleteEventAsync(2);
            await eventCrud.DeleteEventAsync(3);
            await stateCrud.DeleteStateAsync(2);
            await productCrud.DeleteProductAsync(2);
            await userCrud.DeleteUserAsync(2);
        }

        [TestMethod]
        public async Task SupplyEventServiceTests()
        {
            IProductCRUD productCrud = IProductCRUD.CreateProductCRUD(this._repository);

            //int id, string productName, string productDescription, float price
            await productCrud.AddProductAsync(4, "Cappucino", "Flavorful", 2);

            IProductDTO product = await productCrud.GetProductAsync(4);

            IStateCRUD stateCrud = IStateCRUD.CreateStateCRUD(this._repository);

            await stateCrud.AddStateAsync(4, product.id, true);

            IStateDTO state = await stateCrud.GetStateAsync(4);

            IUserCRUD userCrud = IUserCRUD.CreateUserCRUD(this._repository);

            await userCrud.AddUserAsync(4, "John", "Doe");

            IUserDTO user = await userCrud.GetUserAsync(4);

            IEventCRUD eventCrud = IEventCRUD.CreateEventCRUD(this._repository);

            await eventCrud.AddEventAsync(4, state.stateId, user.id, "SupplyEvent");

            state = await stateCrud.GetStateAsync(4);

            Assert.AreEqual(true, state.available);

            await eventCrud.DeleteEventAsync(4);
            await stateCrud.DeleteStateAsync(4);
            await productCrud.DeleteProductAsync(4);
            await userCrud.DeleteUserAsync(4);
        }
    }
}
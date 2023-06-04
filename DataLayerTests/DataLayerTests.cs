using DataLayer.API;
using DataLayer.Implementation;
using DataLayer.Instrumentation;
using System.Data.Common;

namespace DataLayerTests
{
    [TestClass]
    [DeploymentItem("CoffeeShopTestDB.mdf")]
    public class DataLayerTests
    {
        private static string testConnectionString;

        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase(testConnectionString);

        [ClassInitialize]
        public static void InitializeDataLayerTests(TestContext context)
        {
            string _DBRelativePath = @"CoffeeShopTestDB.mdf";
            string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
            FileInfo _databaseFile = new FileInfo(_DBPath);
            Assert.IsTrue(_databaseFile.Exists, $"{Environment.CurrentDirectory}");
            testConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
        }

        [TestMethod]
        public async Task UserTests()
        {
            int userId = 1;

            await _dataRepository.AddUserAsync(userId, "John", "Smith");

            IUser user = await _dataRepository.GetUserAsync(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Smith", user.lastName);

            user = await _dataRepository.GetUserAsyncMethodSyntax(userId);

            Assert.IsNotNull(user);
            Assert.AreEqual(userId, user.id);
            Assert.AreEqual("John", user.firstName);
            Assert.AreEqual("Smith", user.lastName);

            Assert.IsNotNull(await _dataRepository.GetAllUsersAsync());
            Assert.IsTrue(await _dataRepository.GetUsersCountAsync() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(userId + 2));

            await _dataRepository.UpdateUserAsync(userId, "Tom", "ABC");

            IUser userUpdated = await _dataRepository.GetUserAsync(userId);

            Assert.IsNotNull(userUpdated);
            Assert.AreEqual(userId, userUpdated.id);
            Assert.AreEqual("Tom", userUpdated.firstName);
            Assert.AreEqual("ABC", userUpdated.lastName);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateUserAsync(userId + 2,
                "Tom", "ABC"));

            await _dataRepository.DeleteUserAsync(userId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetUserAsync(userId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteUserAsync(userId));
        }

        [TestMethod]
        public async Task ProductTests()
        {
            int productId = 1;

            await _dataRepository.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProduct product = await _dataRepository.GetProductAsync(productId);

            Assert.IsNotNull(product);
            Assert.AreEqual(productId, product.id);
            Assert.AreEqual("Black Coffee", product.productName);
            Assert.AreEqual("Strong blend", product.productDescription);
            Assert.AreEqual(3.5f, product.price);

            Assert.IsNotNull(await _dataRepository.GetAllProductsAsync());
            Assert.IsTrue(await _dataRepository.GetProductsCountAsync() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(32));

            await _dataRepository.UpdateProductAsync(productId, "Coffee", "Regular", 4.5f);

            IProduct productUpdated = await _dataRepository.GetProductAsync(productId);

            Assert.IsNotNull(productUpdated);
            Assert.AreEqual(productId, productUpdated.id);
            Assert.AreEqual("Coffee", productUpdated.productName);
            Assert.AreEqual("Regular", productUpdated.productDescription);
            Assert.AreEqual(4.5f, productUpdated.price);

            await _dataRepository.DeleteProductAsync(productId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetProductAsync(productId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteProductAsync(productId));
        }

        [TestMethod]
        public async Task StateTests()
        {
            int productId = 1;
            int stateId = 1;

            await _dataRepository.AddProductAsync(1, "Black Coffee", "Strong blend", 3.5f);

            IProduct product = await _dataRepository.GetProductAsync(productId);

            await _dataRepository.AddStateAsync(stateId, productId, true);

            IState state = await _dataRepository.GetStateAsync(stateId);

            Assert.IsNotNull(state);
            Assert.AreEqual(stateId, state.stateId);
            Assert.AreEqual(productId, state.productId);
            Assert.AreEqual(true, state.available);

            Assert.IsNotNull(await _dataRepository.GetAllStatesAsync());
            Assert.IsTrue(await _dataRepository.GetStatesCountAsync() > 0);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetStateAsync(stateId + 2));

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.AddStateAsync(stateId, 13, false));

            await _dataRepository.UpdateStateAsync(stateId, productId, false);

            IState stateUpdated = await _dataRepository.GetStateAsync(stateId);

            Assert.IsNotNull(stateUpdated);
            Assert.AreEqual(stateId, stateUpdated.stateId);
            Assert.AreEqual(productId, stateUpdated.productId);
            Assert.AreEqual(false, stateUpdated.available);

            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateStateAsync(stateId + 2, productId, true));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.UpdateStateAsync(stateId, 13, false));

            await _dataRepository.DeleteStateAsync(stateId);
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.GetStateAsync(stateId));
            await Assert.ThrowsExceptionAsync<Exception>(async () => await _dataRepository.DeleteStateAsync(stateId));

            await _dataRepository.DeleteProductAsync(productId);
        }

        [TestMethod]
        public async Task EventTests()
        {
            await _dataRepository.AddUserAsync(1, "John", "Smith");
            await _dataRepository.AddProductAsync(1, "Coffee", "Regular", 3.99f);
            await _dataRepository.AddStateAsync(1, 1, true);
            await _dataRepository.AddEventAsync(1, 1, 1, "PlaceEvent");

            await _dataRepository.DeleteEventAsync(1);
            await _dataRepository.DeleteUserAsync(1);
            await _dataRepository.DeleteStateAsync(1);
            await _dataRepository.DeleteProductAsync(1);
        }
    }
}
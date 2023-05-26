using DataLayer.API;
using DataLayer.Implementation;
using DataLayer.Instrumentation;
using System.Data.Common;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerTests
    {
        private readonly IDataRepository _dataRepository = IDataRepository.CreateDatabase();

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
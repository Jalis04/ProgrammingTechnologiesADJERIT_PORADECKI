using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;
using LogicLayer.Implementation;

namespace LogicLayerTests
{
    [TestClass]
    public class LogicLayerTests
    {
        [TestMethod]
        public void TestPlaceOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IUser user = new User("01", "John", "Doe");
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            IState state = new State("01", product);
            dataRepository.AddUser(user);
            dataRepository.AddProduct(product);
            dataRepository.AddState(state);
            
            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            coffeeShopLogic.PlaceOrder("01", "01");
            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PlaceOrder("12", "03"));
        }

        [TestMethod]
        public void TestPayOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IUser user = new User("01", "John", "Doe");
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            IState state = new State("01", product);
            dataRepository.AddUser(user);
            dataRepository.AddProduct(product);
            dataRepository.AddState(state);

            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PayOrder("01", "01"));
            coffeeShopLogic.PlaceOrder("01", "01");
            coffeeShopLogic.PayOrder("01", "01");
        }
    }
}
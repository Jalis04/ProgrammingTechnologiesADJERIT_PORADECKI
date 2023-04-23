using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;
using LogicLayer.Implementation;

namespace LogicLayerTests
{
    [TestClass]
    public class LogicLayerStaticTests
    {
        [TestMethod]
        public void TestPlaceOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            dataRepository.AddUser("01", "John", "Doe");
            dataRepository.AddProduct("02", "Black coffee", "Description", 3.99f);
            dataRepository.AddState("01", "02");
            
            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            coffeeShopLogic.PlaceOrder("01", "01");
            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PlaceOrder("12", "03"));
        }

        [TestMethod]
        public void TestPayOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            dataRepository.AddUser("01", "John", "Doe");
            dataRepository.AddProduct("02", "Black coffee", "Description", 3.99f);
            dataRepository.AddState("01", "02");

            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PayOrder("01", "01"));
            coffeeShopLogic.PlaceOrder("01", "01");
            coffeeShopLogic.PayOrder("01", "01");
        }
    }
}
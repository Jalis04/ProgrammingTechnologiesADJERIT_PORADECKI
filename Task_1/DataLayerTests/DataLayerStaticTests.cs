using DataLayer.API;
using DataLayer.Implementation;
using System.Data.Common;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerStaticTests
    {

        [TestMethod]
        public void TestDataRepositoryWithUser()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            dataRepository.AddUser("01", "John", "Doe");
            dataRepository.AddUser("02", "Tom", "Eod");

            Assert.IsTrue(dataRepository.UserExists("01"));
            Assert.IsFalse(dataRepository.UserExists("01" + 1));

            dataRepository.DeleteUser("01");
            Assert.IsFalse(dataRepository.UserExists("01"));

        }

        [TestMethod]
        public void TestDataRepositoryWithProduct()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            dataRepository.AddProduct("01", "Black coffee", "Description", 3.99f);
            dataRepository.AddProduct("02", "White coffee", "Description2", 4.49f);

            Assert.IsTrue(dataRepository.ProductExists("01"));
            Assert.IsFalse(dataRepository.ProductExists("01" + 1));

            dataRepository.DeleteProduct("02");
            Assert.IsFalse(dataRepository.UserExists("02"));
        }

        [TestMethod]
        public void TestDataRepositoryWithEvents()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            dataRepository.AddEvent("Pay", "01", "01", "01");
            dataRepository.AddEvent("Place", "02", "03", "04");
            dataRepository.DeleteEvent("02");

        }
    }
}
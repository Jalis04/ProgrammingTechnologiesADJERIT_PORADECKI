using DataLayer.API;
using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerRandomTests
    {
        [TestMethod]
        public void TestDataRepositoryRandomNumberOfUsers()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            Random rnd = new Random();
            int size = rnd.Next(30);
            for (int i = 0; i < size; i++)
            {
                int randomId = rnd.Next();
                string strRandomId = randomId.ToString();
                IUser user = new User(strRandomId, "User" + strRandomId.ToString(), "Surname" + strRandomId.ToString());
                dataRepository.AddUser(user);
            }

            Assert.AreEqual(dataRepository.GetAllUsers().Count(), size);

        }

        [TestMethod]
        public void TestDataRepositoryRandomProduct()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            Random rnd = new Random();
            int size = rnd.Next();

            IProduct product = new Product(size.ToString(), "White coffee", "Description", 3.99f);
            dataRepository.AddProduct(product);

            Assert.IsTrue(dataRepository.ProductExists(size.ToString()));
        }
    }
}

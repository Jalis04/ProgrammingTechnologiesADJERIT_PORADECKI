using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeShop.LogicLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.DataLayer;

namespace CoffeeShop.LogicLayer.Tests
{
    [TestClass]
    public class ShopAPITests
    {
        [TestMethod]
        public void TestAddProduct()
        {
            // Arrange
            var api = new CoffeeShopAPI();
            var product = new Product("product a", "placeholder description", 10.5);

            // Act
            api.AddProduct(product);

            // Assert
            Assert.AreEqual(1, api.GetProductCount());
            Assert.AreEqual(product, api.GetProductByName("Product A"));
        }

        [TestMethod]
        public void TestRemoveProduct()
        {
            // Arrange
            var api = new CoffeeShopAPI();
            var product = new Product ("product a", "placeholder description", 10.5);
            api.AddProduct(product);

            // Act
            api.RemoveProduct(product);

            // Assert
            Assert.AreEqual(0, api.GetProductCount());
        }

        // Other unit tests for the ShopAPI class
    }

}
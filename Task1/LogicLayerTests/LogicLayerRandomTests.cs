﻿using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;
using LogicLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayerTests
{
    [TestClass]
    public class LogicLayerRandomTests
    {
        [TestMethod]
        public void TestRandomPlaceOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            Random rnd = new Random();
            string userId = rnd.Next().ToString();
            string productId = rnd.Next().ToString();
            string stateId = rnd.Next().ToString();

            IUser user = new User(userId, "John", "Doe");
            IProduct product = new Product(productId, "Black coffee", "Description", 3.99f);
            IState state = new State(stateId, product);
            dataRepository.AddUser(user);
            dataRepository.AddProduct(product);
            dataRepository.AddState(state);

            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            coffeeShopLogic.PlaceOrder(userId, stateId);
            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PlaceOrder(rnd.Next().ToString(), rnd.Next().ToString()));
        }

        [TestMethod]
        public void TestRandomPayOrder()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            Random rnd = new Random();
            string userId = rnd.Next().ToString();
            string productId = rnd.Next().ToString();
            string stateId = rnd.Next().ToString();

            IUser user = new User(userId, "John", "Doe");
            IProduct product = new Product(productId, "Black coffee", "Description", 3.99f);
            IState state = new State(stateId, product);
            dataRepository.AddUser(user);
            dataRepository.AddProduct(product);
            dataRepository.AddState(state);

            ICoffeeShopLogic coffeeShopLogic = new CoffeeShopLogic(dataRepository);

            Assert.ThrowsException<InvalidOperationException>(() => coffeeShopLogic.PayOrder(rnd.Next().ToString(), stateId));
            coffeeShopLogic.PlaceOrder(userId, stateId);
            coffeeShopLogic.PayOrder(userId, stateId);
        }
    }
}
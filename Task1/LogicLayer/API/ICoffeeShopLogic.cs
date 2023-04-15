using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using DataLayer.API;
using LogicLayer.Implementation;

namespace LogicLayer.API
{
    public abstract class ICoffeeShopLogic
    {
        public abstract void AddOrder(string userId, string stateId);

        public abstract void PayOrder(string userId, string stateId);

        public static ICoffeeShopLogic CreateLogic(IDataRepository? dataRepository = default)
        {
            return new CoffeeShopLogic(dataRepository ?? IDataRepository.CreateDataRepository());
        }
        // Other methods for handling shop operations
    }
}

using DataLayer;
using DataLayer.API;
using DataLayer.Implementation;
using LogicLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace LogicLayer.Implementation
{
    internal class CoffeeShopLogic : ICoffeeShopLogic
    {
        private IDataRepository DataRepo;

        public CoffeeShopLogic(IDataRepository dataRepo)
        {
            DataRepo = dataRepo;
        }

        public override void AddOrder(string userId, string stateId)
        {
            if (!DataRepo.IsAvailable(stateId)) throw new InvalidOperationException("Can't order a product that isn't available");
            IOrder order = new Order(stateId, userId);
            DataRepo.AddEvent(order);
            DataRepo.ChangeAvailability(stateId);
        }

        public override void PayOrder(string userId, string stateId)
        {
            if (DataRepo.IsAvailable(stateId)) throw new InvalidOperationException("Can't pay an order that doesn't exist");
            DataRepo.AddEvent(new PayOrder(stateId, userId));
            DataRepo.ChangeAvailability(stateId);
        }
    }
}

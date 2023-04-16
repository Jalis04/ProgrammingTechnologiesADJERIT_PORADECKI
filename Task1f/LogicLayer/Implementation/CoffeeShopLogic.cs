using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;
using Task1f.LogicLayer.API;

namespace Task1f.LogicLayer.Implementation
{
    internal class CoffeeShopLogic : ICoffeeShopLogic
    {
        private IDataRepository DataRepo;

        //Dependency Injection
        public CoffeeShopLogic(IDataRepository dataRepo)
        {
            DataRepo = dataRepo;
        }

        public override void PlaceOrder(string userId, string stateId)
        {
            if (!DataRepo.IsAvailable(stateId)) throw new InvalidOperationException("Cannot Order nothing");
            IEvent rent = new PlaceOrderEvent(stateId, userId);
            DataRepo.AddEvent(rent);
            DataRepo.ChangeAvailability(stateId);
        }

        public override void PayOrder(string userId, string stateId)
        {
            if (DataRepo.IsAvailable(stateId)) throw new InvalidOperationException("Cannot pay if there are no orders");
            DataRepo.AddEvent(new PayOrderEvent(stateId, userId));
            DataRepo.ChangeAvailability(stateId);
        }
    }
}

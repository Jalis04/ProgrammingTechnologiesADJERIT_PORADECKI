using DataLayer.Implementation;
using DataLayer.API;
using LogicLayer.API;

namespace LogicLayer.Implementation
{
    public class CoffeeShopLogic : ICoffeeShopLogic
    {
        private IDataRepository dataRepository;

        //Dependency Injection
        public CoffeeShopLogic(IDataRepository dataRepo)
        {
            dataRepository = dataRepo;
        }

        public override void PlaceOrder(string userId, string stateId)
        {
            if (!dataRepository.IsAvailable(stateId)) throw new InvalidOperationException("Cannot order nothing");
            IEvent rent = new PlaceOrderEvent(stateId, userId);
            dataRepository.AddEvent(rent);
            dataRepository.ChangeAvailability(stateId);
        }

        public override void PayOrder(string userId, string stateId)
        {
            if (dataRepository.IsAvailable(stateId)) throw new InvalidOperationException("Cannot pay if there are no orders");
            dataRepository.AddEvent(new PayOrderEvent(stateId, userId));
            dataRepository.ChangeAvailability(stateId);
        }
    }
}

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
            dataRepository.AddEvent("Place", "01",  stateId, userId);
            dataRepository.ChangeAvailability(stateId);
        }

        public override void PayOrder(string userId, string stateId)
        {
            if (dataRepository.IsAvailable(stateId)) throw new InvalidOperationException("Cannot pay if there are no orders");
            dataRepository.AddEvent("Pay", "01", stateId, userId);
            dataRepository.ChangeAvailability(stateId);
        }
    }
}

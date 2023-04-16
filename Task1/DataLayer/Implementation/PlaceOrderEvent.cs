using DataLayer.API;

namespace DataLayer.Implementation
{
    public class PlaceOrderEvent : IEvent
    {
        public string stateId { get; }
        public string userId { get; }

        public PlaceOrderEvent(string stateId, string userId)
        {
            this.stateId = stateId;
            this.userId = userId;
        }
    }
}

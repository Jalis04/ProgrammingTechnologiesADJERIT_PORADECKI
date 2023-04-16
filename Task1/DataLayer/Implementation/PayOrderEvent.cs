using DataLayer.API;

namespace DataLayer.Implementation
{
    public class PayOrderEvent : IEvent
    {
        public string stateId { get; }
        public string userId { get; }

        public PayOrderEvent(string stateId, string userId)
        {
            this.stateId = stateId;
            this.userId = userId;
        }
    }
}

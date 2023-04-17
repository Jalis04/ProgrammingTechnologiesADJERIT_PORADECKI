using DataLayer.API;

namespace DataLayer.Implementation
{
    public class PayOrderEvent : IEvent
    {
        public PayOrderEvent(string stateId, string userId)
        {
            this.stateId = stateId;
            this.userId = userId;
            this.eventDate = DateTime.Now;
        }

        public string stateId { get; }
        public string userId { get; }
        public DateTime eventDate { get; }
    }
}

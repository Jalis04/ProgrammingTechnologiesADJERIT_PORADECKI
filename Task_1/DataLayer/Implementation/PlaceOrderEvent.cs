using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class PlaceOrderEvent : IEvent
    {
        public PlaceOrderEvent(string eventId, string stateId, string userId)
        {
            this.eventId = eventId;
            this.stateId = stateId;
            this.userId = userId;
            this.eventDate = DateTime.Now;
        }

        public string eventId { get; set; }
        public string stateId { get; set; }
        public string userId { get; set; }
        public DateTime eventDate { get; }


    }
}

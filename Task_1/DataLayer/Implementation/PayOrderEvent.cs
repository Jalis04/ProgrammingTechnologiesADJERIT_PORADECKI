using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class PayOrderEvent : IEvent
    {
        public PayOrderEvent(int eventId, int stateId, int userId)
        {
            this.eventId = eventId;
            this.stateId = stateId;
            this.userId = userId;
            this.eventDate = DateTime.Now;
        }

        public int eventId { get; set; }
        public int stateId { get; set; }
        public int userId { get; set; }
        public DateTime eventDate { get; }
    }
}

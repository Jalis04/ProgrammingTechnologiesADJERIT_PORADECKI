namespace  DataLayer.API
{
    public interface IEvent
    {
        string eventId { get; set; }
        string stateId { get; set; }
        string userId { get; set; }
        DateTime eventDate { get; }
    }
}

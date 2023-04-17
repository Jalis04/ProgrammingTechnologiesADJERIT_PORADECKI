namespace  DataLayer.API
{
    public interface IEvent
    {
        string stateId { get; }
        string userId { get; }
        DateTime eventDate { get; }
    }
}

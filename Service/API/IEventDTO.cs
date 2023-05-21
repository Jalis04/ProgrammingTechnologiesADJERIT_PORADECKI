namespace Service.API;

public interface IEventDTO
{
    int eventId { get; set; }
    int stateId { get; set; }
    int userId { get; set; }
    DateTime eventDate { get; }
    string type { get; set; }
}

using Service.API;

namespace Service.Implementation;

internal class EventDTO : IEventDTO
{
    public int eventId { get; set; }
    public int stateId { get; set; }
    public int userId { get; set; }
    public DateTime eventDate { get; }
    public string type { get; set; }

    public EventDTO(int id, int stateId, int userId, string type)
    {
        this.eventId = id;
        this.stateId = stateId;
        this.userId = userId;
        this.eventDate = DateTime.Now;
        this.type = type;
    }
}

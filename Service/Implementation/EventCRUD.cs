using DataLayer.API;
using DataLayer.Instrumentation;
using Service.API;

namespace Service.Implementation;

internal class EventCRUD : IEventCRUD
{
    private IDataRepository _repository;

    public EventCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    public IEventDTO Map(IEvent currentEvent)
    {
        return new EventDTO(currentEvent.eventId, currentEvent.stateId, currentEvent.userId, currentEvent.type);
    }

    public async Task AddEventAsync(int id, int stateId, int userId, string type)
    {
        await this._repository.AddEventAsync(id, stateId, userId, type);
    }

    public async Task<IEventDTO> GetEventAsync(int id)
    {
        return this.Map(await this._repository.GetEventAsync(id));
    }

    public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
    {
        await this._repository.UpdateEventAsync(id, stateId, userId, type);
    }

    public async Task DeleteEventAsync(int id)
    {
        await this._repository.DeleteEventAsync(id);
    }

    public async Task<Dictionary<int, IEventDTO>> GetAllEventsAsync()
    {
        Dictionary<int, IEventDTO> result = new Dictionary<int, IEventDTO>();

        foreach (IEvent currentEvent in (await this._repository.GetAllEventsAsync()).Values)
        {
            result.Add(currentEvent.eventId, this.Map(currentEvent));
        }

        return result;
    }

    public async Task<int> GetEventsCountAsync()
    {
        return await this._repository.GetEventsCountAsync();
    }
}

using Presentation.Model.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Service.API;

namespace Presentation.Model.Implementation;

internal class EventModelOperation : IEventModelOperation
{
    private IEventCRUD _eventCRUD;

    public EventModelOperation(IEventCRUD? eventCrud = null)
    {
        this._eventCRUD = eventCrud ?? IEventCRUD.CreateEventCRUD();
    }

    private IEventModel Map(IEventDTO even)
    {
        return new EventModel(even.Id, even.StateId, even.UserId, even.Type);
    }

    public async Task AddEventAsync(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.AddEventAsync(id, stateId, userId, type);
    }

    public async Task<IEventModel> GetEventAsync(int id, string type)
    {
        return this.Map(await this._eventCRUD.GetEventAsync(id));
    }

    public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.UpdateEventAsync(id, stateId, userId, type);
    }

    public async Task DeleteEventAsync(int id)
    {
        await this._eventCRUD.DeleteEventAsync(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllEventsAsync()
    {
        Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

        foreach (IEventDTO even in (await this._eventCRUD.GetAllEventsAsync()).Values)
        {
            result.Add(even.Id, this.Map(even));
        }

        return result;
    }

    public async Task<int> GetEventsCountAsync()
    {
        return await this._eventCRUD.GetEventsCountAsync();
    }
}

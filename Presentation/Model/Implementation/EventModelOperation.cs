﻿using Presentation.Model.API;
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
        return new EventModel(even.eventId, even.stateId, even.userId, even.type);
    }

    public async Task AddAsync(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.AddEventAsync(id, stateId, userId, type);
    }

    public async Task<IEventModel> GetAsync(int id, string type)
    {
        return this.Map(await this._eventCRUD.GetEventAsync(id));
    }

    public async Task UpdateAsync(int id, int stateId, int userId, string type)
    {
        await this._eventCRUD.UpdateEventAsync(id, stateId, userId, type);
    }

    public async Task DeleteAsync(int id)
    {
        await this._eventCRUD.DeleteEventAsync(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllAsync()
    {
        Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

        foreach (IEventDTO even in (await this._eventCRUD.GetAllEventsAsync()).Values)
        {
            result.Add(even.eventId, this.Map(even));
        }

        return result;
    }

    public async Task<int> GetCountAsync()
    {
        return await this._eventCRUD.GetEventsCountAsync();
    }
}
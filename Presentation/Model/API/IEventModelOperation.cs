using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IEventModelOperation
{
    static IEventModelOperation CreateModelOperation(IEventCRUD? eventCrud = null)
    {
        return new EventModelOperation(eventCrud ?? IEventCRUD.CreateEventCRUD());
    }

    Task AddEventAsync(int id, int stateId, int userId, string type);

    Task<IEventModel> GetEventAsync(int id, string type);

    Task UpdateEventAsync(int id, int stateId, int userId, string type);

    Task DeleteEventAsync(int id);

    Task<Dictionary<int, IEventModel>> GetAllEventsAsync();

    Task<int> GetEventsCountAsync();
}

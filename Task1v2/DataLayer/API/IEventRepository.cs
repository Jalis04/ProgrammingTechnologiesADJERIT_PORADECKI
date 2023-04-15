using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.DataLayer.API
{
    public interface IEventRepository
    {
        IEnumerable<Event> GetAllEvents();
        Event GetEventById(int id);
        void AddEvent(Event newEvent);
        void UpdateEvent(Event updatedEvent);
        void DeleteEvent(int id);
    }
}

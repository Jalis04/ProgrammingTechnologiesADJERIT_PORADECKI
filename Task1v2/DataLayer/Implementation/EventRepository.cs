using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class EventRepository : IEventRepository
    {
        private readonly List<Event> _events;

        public EventRepository()
        {
            _events = new List<Event>();
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _events;
        }

        public Event GetEventById(int id)
        {
            return _events.FirstOrDefault(e => e.Id == id);
        }

        public void AddEvent(Event newEvent)
        {
            newEvent.Id = _events.Any() ? _events.Max(e => e.Id) + 1 : 1;
            _events.Add(newEvent);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            var existingEvent = _events.FirstOrDefault(e => e.Id == updatedEvent.Id);
            if (existingEvent != null)
            {
                existingEvent.Name = updatedEvent.Name;
                existingEvent.StartDate = updatedEvent.StartDate;
                existingEvent.EndDate = updatedEvent.EndDate;
                existingEvent.Description = updatedEvent.Description;
            }
        }

        public void DeleteEvent(int id)
        {
            var eventToDelete = _events.FirstOrDefault(e => e.Id == id);
            if (eventToDelete != null)
            {
                _events.Remove(eventToDelete);
            }
        }
    }
}

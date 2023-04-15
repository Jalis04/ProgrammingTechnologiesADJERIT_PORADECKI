using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class EventService
    {
        private readonly IEventRepository _eventRepository;

        public EventService(IEventRepository eventRepository)
        {
            _eventRepository = eventRepository;
        }

        public IEnumerable<Event> GetAllEvents()
        {
            return _eventRepository.GetAllEvents();
        }

        public Event GetEventById(int id)
        {
            return _eventRepository.GetEventById(id);
        }

        public void AddEvent(Event newEvent)
        {
            _eventRepository.AddEvent(newEvent);
        }

        public void UpdateEvent(Event updatedEvent)
        {
            _eventRepository.UpdateEvent(updatedEvent);
        }

        public void DeleteEvent(int id)
        {
            _eventRepository.DeleteEvent(id);
        }
    }
}

using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Event : IEvent
    {
        public DateTime Timestamp { get; }
        public string Description { get; }

        public Event(string description)
        {
            Timestamp = DateTime.Now;
            Description = description;
        }
    }
}


using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class PlaceOrderDTO : IEvent
    {
        public string eventId { get; set; }
        public string stateId { get; set; }
        public string userId { get; set; }
        public DateTime eventDate { get; }
    }
}

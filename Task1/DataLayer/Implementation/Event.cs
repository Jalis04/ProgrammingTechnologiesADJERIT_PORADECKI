using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class InvoiceCreatedEvent : IEvent
    {
        public string Id { get; set; }
        public DateTime Timestamp { get; set; }
        public decimal Amount { get; set; }
        public string ClientId { get; set; }
        

        //No implemented method yet
    }
}

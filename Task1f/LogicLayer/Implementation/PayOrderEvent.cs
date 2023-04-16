using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;

namespace Task1f.LogicLayer.Implementation
{
    internal class PayOrderEvent : IEvent
    {
        public string StateId { get; }
        public string UserId { get; }

        public PayOrderEvent(string stateId, string userId)
        {
            StateId = stateId;
            UserId = userId;
        }
    }
}

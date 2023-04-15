using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementation
{
    internal class PayOrder : IPayOrder
    {
        public PayOrder(string stateId, string userId)
        {
            StateId = stateId;
            UserId = userId;
        }

        public string StateId { get; }
        public string UserId { get; }
    }
}

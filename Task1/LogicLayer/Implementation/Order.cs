using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace LogicLayer.Implementation
{
    internal class Order : IOrder
    {
        public string StateId { get; }
        public string UserId { get; }

        public Order(string stateId, string userId)
        {
            StateId = stateId;
            UserId = userId;
        }
    }
}

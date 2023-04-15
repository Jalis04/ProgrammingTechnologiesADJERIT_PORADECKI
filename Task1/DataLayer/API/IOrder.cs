using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IOrder : IEvent
    {
        string StateId { get; }
        string UserId { get; }
    }
}

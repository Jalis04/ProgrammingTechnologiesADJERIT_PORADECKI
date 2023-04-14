using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IEvent
    {
        string Id { get; }
        DateTime Timestamp { get; }
    }

}

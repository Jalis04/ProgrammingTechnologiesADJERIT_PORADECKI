using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IState
    {
        string DrinkId { get; }
        string StateId { get; set; }

        bool Available { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1f.DataLayer.API
{
    public interface IState
    {
        string ProductId { get; }
        string StateId { get; set; }

        bool Available { get; set; }
    }
}

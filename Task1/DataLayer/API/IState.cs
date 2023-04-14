using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IState
    {
        string Id { get; }
        string Name { get; set; }
        string Description { get; set; }
    }
}

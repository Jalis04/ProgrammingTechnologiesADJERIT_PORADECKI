using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        internal Dictionary<string, ICatalog> catalogs = new();
        internal List<IEvent> events = new();
        internal List<IState> states = new();
        internal List<IUsers> users = new();
    }

}

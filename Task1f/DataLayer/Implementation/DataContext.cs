using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;
using Task1f.DataLayer.Implementation;


namespace Task1f.DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        internal Dictionary<string, IProduct> catalog = new();
        internal List<IEvent> events = new();
        internal List<IState> states = new();
        internal List<IUser> users = new();
    }
}

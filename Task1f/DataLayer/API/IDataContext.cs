using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1f.DataLayer.API
{
    public abstract class IDataContext
    {   
        //Catalog is the list of products
        Dictionary<string, IProduct> catalog = new();
        List<IEvent> events = new();
        List<IState> states = new();
        List<IUser> users = new();

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;
using Task1f.LogicLayer.Implementation;
[assembly: InternalsVisibleTo("Tests")]

namespace Task1f.LogicLayer.API
{
    public abstract class ICoffeeShopLogic
    {
        public abstract void PlaceOrder(string userId, string stateId);

        public abstract void PayOrder(string userId, string stateId);

        public static ICoffeeShopLogic CreateLogic(IDataRepository? dataRepository = default)
        {
            return new CoffeeShopLogic(dataRepository ?? IDataRepository.CreateDataRepository());
        }
    }
}

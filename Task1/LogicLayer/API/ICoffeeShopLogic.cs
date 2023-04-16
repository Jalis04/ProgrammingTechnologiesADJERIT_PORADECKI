using System.Runtime.CompilerServices;
using DataLayer.API;
using LogicLayer.Implementation;
[assembly: InternalsVisibleTo("Tests")]

namespace LogicLayer.API
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

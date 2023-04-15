using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class ShopStateRepository : IShopStateRepository
    {
        private ShopState _currentState;

        public ShopStateRepository()
        {
            _currentState = new ShopState
            {
                Id = 1,
                Status = ShopStatus.Closed,
                Products = new List<Product>()
            };
        }

        public ShopState GetCurrentState()
        {
            return _currentState;
        }

        public void SaveState(ShopState state)
        {
            _currentState = state;
        }
    }
}

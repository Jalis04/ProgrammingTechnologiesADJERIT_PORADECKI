using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class ShopStateManager : IShopStateManager
    {
        private readonly IShopStateRepository _stateRepository;

        public ShopStateManager(IShopStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        public ShopState GetCurrentState()
        {
            return _stateRepository.GetCurrentState();
        }

        public void OpenShop()
        {
            var currentState = GetCurrentState();
            currentState.Status = ShopStatus.Open;
            _stateRepository.SaveState(currentState);
        }

        public void CloseShop()
        {
            var currentState = GetCurrentState();
            currentState.Status = ShopStatus.Closed;
            _stateRepository.SaveState(currentState);
        }
    }
}

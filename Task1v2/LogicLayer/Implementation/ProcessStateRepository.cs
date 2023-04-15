using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;
using Task1v2.LogicLayer.API;

namespace Task1v2.LogicLayer.Implementation
{
    public class ProcessStateRepository : IProcessStateRepository
    {
        private ShopState _currentState;

        public ShopState GetCurrentState()
        {
            return _currentState;
        }

        public void SetCurrentState(ShopState state)
        {
            _currentState = state;
        }
    }
}

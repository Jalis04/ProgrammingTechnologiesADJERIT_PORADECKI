using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;
using Task1v2.LogicLayer.API;


namespace Task1v2.LogicLayer.Implementation
{
    public class ProcessStateService : IProcessStateService
    {
        private readonly IProcessStateRepository _processStateRepository;

        public ProcessStateService(IProcessStateRepository processStateRepository)
        {
            _processStateRepository = processStateRepository;
        }

        public ShopState GetCurrentState()
        {
            return _processStateRepository.GetCurrentState();
        }

        public void SetCurrentState(ShopState state)
        {
            _processStateRepository.SetCurrentState(state);
        }
    }
}

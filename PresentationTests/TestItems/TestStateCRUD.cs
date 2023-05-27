using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestStateCRUD : IStateCRUD
    {
        private readonly TestDataRepository _testRepository = new TestDataRepository();

        public TestStateCRUD()
        {
        }


        public async Task AddStateAsync(int id, int productId, bool available)
        {
            await _testRepository.AddStateAsync(id, productId, available);
        }

        public async Task<IStateDTO> GetStateAsync(int id)
        {
            return await this._testRepository.GetStateAsync(id);
        }

        public async Task UpdateStateAsync(int id, int productId, bool available)
        {
            await this._testRepository.UpdateStateAsync(id, productId, available);
        }

        public async Task DeleteStateAsync(int id)
        {
            await this._testRepository.DeleteStateAsync(id);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStatesAsync()
        {
            Dictionary<int, IStateDTO> result = new Dictionary<int, IStateDTO>();

            foreach (IState state in (await this._testRepository.GetAllStatesAsync()).Values)
            {
                result.Add(state.stateId, (IStateDTO)state);
            }

            return result;
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await this._testRepository.GetStatesCountAsync();
        }
    }
}

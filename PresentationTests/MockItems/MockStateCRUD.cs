using Presentation.Model.API;

namespace PresentationTests.MockItems
{
    internal class MockStateCRUD : IStateModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockStateCRUD()
        {
        }


        public async Task AddStateAsync(int id, int productId, bool available)
        {
            await _testRepository.AddStateAsync(id, productId, available);
        }

        public async Task<IStateModel> GetStateAsync(int id)
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

        public async Task<Dictionary<int, IStateModel>> GetAllStatesAsync()
        {
            Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

            foreach (IStateModel state in (await this._testRepository.GetAllStatesAsync()).Values)
            {
                result.Add(state.StateId, (IStateModel)state);
            }

            return result;
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await this._testRepository.GetStatesCountAsync();
        }
    }
}

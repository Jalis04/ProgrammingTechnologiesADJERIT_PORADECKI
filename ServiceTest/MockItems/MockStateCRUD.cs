using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockStateCRUD : IStateCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();  

        public async Task AddStateAsync(int id, int productId, bool available)
        {
            await _dataRepository.AddStateAsync(id, productId, available);   
        }

        public async Task DeleteStateAsync(int id)
        {
            await _dataRepository.DeleteStateAsync(id);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStatesAsync()
        {
            return await _dataRepository.GetAllStatesAsync();
        }

        public async Task<IStateDTO> GetStateAsync(int id)
        {
            return await _dataRepository.GetStateAsync(id);
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await _dataRepository.GetStatesCountAsync();
        }

        public async Task UpdateStateAsync(int id, int productId, bool available)
        {
            await _dataRepository.UpdateStateAsync(id, productId, available);
        }
    }
}

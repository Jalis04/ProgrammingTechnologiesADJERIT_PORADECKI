using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockEventCRUD : IEventCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddEventAsync(int id, int stateId, int userId, string type)
        {
            await _dataRepository.AddEventAsync(id, stateId, userId, type);
        }

        public async Task DeleteEventAsync(int id)
        {
            await _dataRepository.DeleteEventAsync(id);
        }

        public async Task<Dictionary<int, IEventDTO>>GetAllEventsAsync()
        {
            return await _dataRepository.GetAllEventsAsync();
        }

        public async Task<IEventDTO> GetEventAsync(int id)
        {
            return await _dataRepository.GetEventAsync(id);
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await _dataRepository.GetEventsCountAsync();
        }

        public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
        {
            await _dataRepository.UpdateEventAsync(id, stateId, userId, type);
        }
    }
}

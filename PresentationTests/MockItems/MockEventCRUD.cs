using Presentation.Model.API;

namespace PresentationTests.MockItems
{
    internal class MockEventCRUD : IEventModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockEventCRUD()
        {
        }

        public async Task AddEventAsync(int id, int stateId, int userId, string type)
        {
            await this._testRepository.AddEventAsync(id, stateId, userId, type);
        }

        public async Task<IEventModel> GetEventAsync(int id, string type)
        {
            return await this._testRepository.GetEventAsync(id);
        }

        public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
        {
            await this._testRepository.UpdateEventAsync(id, stateId, userId, type);
        }

        public async Task DeleteEventAsync(int id)
        {
            await this._testRepository.DeleteEventAsync(id);
        }

        public async Task<Dictionary<int, IEventModel>> GetAllEventsAsync()
        {
            Dictionary<int, IEventModel> result = new Dictionary<int, IEventModel>();

            foreach (IEventModel currentEvent in (await this._testRepository.GetAllEventsAsync()).Values)
            {
                result.Add(currentEvent.Id, (IEventModel)currentEvent);
            }

            return result;
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await this._testRepository.GetEventsCountAsync();
        }
    }
}

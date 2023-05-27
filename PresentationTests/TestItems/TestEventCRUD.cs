using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestEventCRUD : IEventCRUD
    {
        private readonly TestDataRepository _testRepository = new TestDataRepository();

        public TestEventCRUD()
        {
        }

        public async Task AddEventAsync(int id, int stateId, int userId, string type)
        {
            await this._testRepository.AddEventAsync(id, stateId, userId, type);
        }

        public async Task<IEventDTO> GetEventAsync(int id)
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

        public async Task<Dictionary<int, IEventDTO>> GetAllEventsAsync()
        {
            Dictionary<int, IEventDTO> result = new Dictionary<int, IEventDTO>();

            foreach (IEvent currentEvent in (await this._testRepository.GetAllEventsAsync()).Values)
            {
                result.Add(currentEvent.eventId, (IEventDTO)currentEvent);
            }

            return result;
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await this._testRepository.GetEventsCountAsync();
        }
    }
}

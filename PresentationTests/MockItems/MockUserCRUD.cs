using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.MockItems
{
    internal class MockUserCRUD: IUserModelOperation
    {
        private readonly MockDataRepository _testRepository = new MockDataRepository();

        public MockUserCRUD() { }

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            await this._testRepository.AddUserAsync(id, firstName, lastName);
        }

        public async Task<IUserModel> GetUserAsync(int id)
        {
            return await this._testRepository.GetUserAsync(id);
        }

        public async Task UpdateUserAsync(int id, string firstName, string lastName)
        {
            await this._testRepository.UpdateUserAsync(id, firstName, lastName);
        }

        public async Task DeleteUserAsync(int id)
        {
            await this._testRepository.DeleteUserAsync(id);
        }

        public async Task<Dictionary<int, IUserModel>> GetAllUsersAsync()
        {
            Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

            foreach (IUserModel user in (await this._testRepository.GetAllUsersAsync()).Values)
            {
                result.Add(user.Id, (IUserModel)user);
            }

            return result;
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await this._testRepository.GetUsersCountAsync();
        }

    }
}

using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestUserCRUD: IUserCRUD
    {
        private readonly TestDataRepository _testRepository = new TestDataRepository();

        public TestUserCRUD() { }

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            await this._testRepository.AddUserAsync(id, firstName, lastName);
        }

        public async Task<IUserDTO> GetUserAsync(int id)
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

        public async Task<Dictionary<int, IUserDTO>> GetAllUsersAsync()
        {
            Dictionary<int, IUserDTO> result = new Dictionary<int, IUserDTO>();

            foreach (IUser user in (await this._testRepository.GetAllUsersAsync()).Values)
            {
                result.Add(user.id, (IUserDTO)user);
            }

            return result;
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await this._testRepository.GetUsersCountAsync();
        }

    }
}

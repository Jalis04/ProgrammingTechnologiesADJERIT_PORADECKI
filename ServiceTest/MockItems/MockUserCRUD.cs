using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockUserCRUD : IUserCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            await this._dataRepository.AddUserAsync(id, firstName, lastName);
        }

        public async Task DeleteUserAsync(int id)
        {
            await this._dataRepository.DeleteUserAsync(id);
        }

        public async Task<Dictionary<int, IUserDTO>> GetAllUsersAsync()
        {
            return await this._dataRepository.GetAllUsersAsync();
        }

        public async Task<IUserDTO> GetUserAsync(int id)
        {
            return await this._dataRepository.GetUserAsync(id);
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await this._dataRepository.GetUsersCountAsync();
        }

        public async Task UpdateUserAsync(int id, string firstName, string lastName)
        {
            await this._dataRepository.UpdateUserAsync(id, firstName, lastName);
        }
    }
}

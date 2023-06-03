using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockDataRepository
    {
        public Dictionary<int, IUserDTO> Users = new Dictionary<int, IUserDTO>();

        public Dictionary<int, IProductDTO> Products = new Dictionary<int, IProductDTO>();

        public Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

        public Dictionary<int, IEventDTO> Events = new Dictionary<int, IEventDTO>();

        public async Task AddEventAsync(int id, int stateId, int userId, string type)
        {
            Events.Add(id, new MockEventDTO(id, stateId, userId, type));
        }

        public async Task AddProductAsync(int id, string name, string description, float price)
        {
            Products.Add(id, new MockProductDTO(id, name, description, price));
        }

        public async Task AddStateAsync(int id, int productId, bool available)
        {
            States.Add(id, new MockStateDTO(id, productId, available));
        }

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            Users.Add(id, new MockUserDTO(id, firstName, lastName));
        }

        public async Task DeleteEventAsync(int id)
        {
            Events.Remove(id);
        }

        public async Task DeleteProductAsync(int id)
        {
            Products.Remove(id);
        }

        public async Task DeleteStateAsync(int id)
        {
            States.Remove(id);
        }

        public async Task DeleteUserAsync(int id)
        {
            Users.Remove(id);
        }

        public async Task<Dictionary<int, IEventDTO>> GetAllEventsAsync()
        {
            return await Task.FromResult(Events);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProductsAsync()
        {
            return await Task.FromResult(Products);
        }

        public async Task<Dictionary<int, IStateDTO>> GetAllStatesAsync()
        {
            return await Task.FromResult(States);
        }

        public async Task<Dictionary<int, IUserDTO>> GetAllUsersAsync()
        {
            return await Task.FromResult(Users);
        }

        public async Task<IEventDTO> GetEventAsync(int id)
        {
            return await Task.FromResult(Events[id]);
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await Task.FromResult(Events.Count);
        }

        public async Task<IProductDTO> GetProductAsync(int id)
        {
            return await Task.FromResult(Products[id]);
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await Task.FromResult(Products.Count);
        }

        public async Task<IStateDTO> GetStateAsync(int id)
        {
            return await Task.FromResult(States[id]);
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await Task.FromResult(States.Count);
        }

        public async Task<IUserDTO> GetUserAsync(int id)
        {
            return await Task.FromResult(Users[id]);
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await Task.FromResult(Users.Count);
        }

        public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
        {
            Events[id].StateId = stateId;
            Events[id].UserId = userId;
            Events[id].Type = type;
        }

        public async Task UpdateProductAsync(int id, string name, string description, float price)
        {
            Products[id].ProductName = name;
            Products[id].ProductDescription = description;
            Products[id].Price = price;
        }

        public async Task UpdateStateAsync(int id, int productId, bool available)
        {
            States[id].ProductId = productId;
            States[id].Available = available;
        }

        public async Task UpdateUserAsync(int id, string firstName, string lastName)
        {
            Users[id].FirstName = firstName;
            Users[id].LastName = lastName;
        }
    }
}

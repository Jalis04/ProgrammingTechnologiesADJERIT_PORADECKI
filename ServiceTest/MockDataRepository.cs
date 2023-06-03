using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace ServiceTest
{
    internal class MockDataRepository : IDataRepository
    {
        public Dictionary<int, IUser> Users = new Dictionary<int, IUser>();

        public Dictionary<int, IProduct> Products = new Dictionary<int, IProduct>();

        public Dictionary<int, IState> States = new Dictionary<int, IState>(); 

        public Dictionary<int, IEvent> Events = new Dictionary<int, IEvent>();

        public async Task AddEventAsync(int id, int stateId, int userId, string type)
        {
            this.Events.Add(id, new MockEvent(id, stateId, userId, type));
        }

        public async Task AddProductAsync(int id, string name, string description, float price)
        {
            this.Products.Add(id, new MockProduct(id, name, description, price));
        }

        public async Task AddStateAsync(int id, int productId, bool available)
        {
            this.States.Add(id, new MockState(id, productId, available));
        }

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            this.Users.Add(id, new MockUser(id, firstName, lastName));
        }

        public async Task DeleteEventAsync(int id)
        {
            this.Events.Remove(id);
        }

        public async Task DeleteProductAsync(int id)
        {
            this.Products.Remove(id);
        }

        public async Task DeleteStateAsync(int id)
        {
            this.States.Remove(id);
        }

        public async Task DeleteUserAsync(int id)
        {
            this.Users.Remove(id);
        }

        public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
        {
            return await Task.FromResult(this.Events);
        }

        public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
        {
            return await Task.FromResult(this.Products);
        }

        public async Task<Dictionary<int, IState>> GetAllStatesAsync()
        {
            return await Task.FromResult(this.States);
        }

        public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
        {
            return await Task.FromResult(this.Users);
        }

        public async Task<IEvent> GetEventAsync(int id)
        {
            return await Task.FromResult(this.Events[id]);
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await Task.FromResult(this.Events.Count);
        }

        public async Task<IProduct> GetProductAsync(int id)
        {
            return await Task.FromResult(this.Products[id]);
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await Task.FromResult(this.Products.Count);
        }

        public async Task<IState> GetStateAsync(int id)
        {
            return await Task.FromResult(this.States[id]);
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await Task.FromResult(this.States.Count);
        }

        public async Task<IUser> GetUserAsync(int id)
        {
            return await Task.FromResult(this.Users[id]);
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await Task.FromResult(this.Users.Count);
        }

        public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
        {
            ((MockEvent)this.Events[id]).stateId = stateId;
            ((MockEvent)this.Events[id]).userId = userId;
            ((MockEvent)this.Events[id]).type = type;
        }

        public async Task UpdateProductAsync(int id, string name, string description, float price)
        {
            this.Products[id].productName = name;
            this.Products[id].productDescription = description;
            this.Products[id].price = price;
        }

        public async Task UpdateStateAsync(int id, int productId, bool available)
        {
            this.States[id].productId = productId;
            this.States[id].available = available;
        }

        public async Task UpdateUserAsync(int id, string firstName, string lastName)
        {
            this.Users[id].firstName = firstName;
            this.Users[id].lastName = lastName;
        }
    }
}

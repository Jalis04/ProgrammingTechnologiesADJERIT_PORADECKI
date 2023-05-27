using DataLayer.API;
using DataLayer.Instrumentation;
using PresentationTests;
using PresentationTests.TestItems;
using Service.API;

namespace PresentationTests;

internal class TestDataRepository
{
    public Dictionary<int, IUserDTO> Users = new Dictionary<int, IUserDTO>();

    public Dictionary<int, IProductDTO> Products = new Dictionary<int, IProductDTO>();

    public Dictionary<int, IEventDTO> Events = new Dictionary<int, IEventDTO>();

    public Dictionary<int, IStateDTO> States = new Dictionary<int, IStateDTO>();

    #region User CRUD

    public async Task AddUserAsync(int id, string firstName, string lastName)
    {
        this.Users.Add(id, new TestUserDTO(id, firstName, lastName));
    }

    public async Task<IUserDTO> GetUserAsync(int id)
    {
        return await Task.FromResult(this.Users[id]);
    }

    public async Task UpdateUserAsync(int id, string firstName, string lastName)
    {
        this.Users[id].firstName = firstName;
        this.Users[id].firstName = lastName;
    }

    public async Task DeleteUserAsync(int id)
    {
        this.Users.Remove(id);
    }

    public async Task<Dictionary<int, IUserDTO>> GetAllUsersAsync()
    {
        return await Task.FromResult(this.Users);
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await Task.FromResult(this.Users.Count);
    }

    public bool CheckIfUserExists(int id)
    {
        return this.Users.ContainsKey(id);
    }

    #endregion User CRUD


    #region Product CRUD

    public async Task AddProductAsync(int id, string name, string description, float price)
    {
        this.Products.Add(id, new TestProductDTO(id, name, description, price));
    }

    public async Task<IProductDTO> GetProductAsync(int id)
    {
        return await Task.FromResult(this.Products[id]);
    }

    public async Task UpdateProductAsync(int id, string name, string description, float price)
    {
        this.Products[id].productName = name;
        this.Products[id].productDescription = description;
        this.Products[id].price = price;
    }

    public async Task DeleteProductAsync(int id)
    {
        this.Products.Remove(id);
    }

    public async Task<Dictionary<int, IProductDTO>> GetAllProductsAsync()
    {
        return await Task.FromResult(this.Products);
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await Task.FromResult(this.Products.Count);
    }

    #endregion


    #region State CRUD

    public async Task AddStateAsync(int id, int productId, bool available)
    {
        this.States.Add(id, new TestStateDTO(id, productId, available));
    }

    public async Task<IStateDTO> GetStateAsync(int id)
    {
        return await Task.FromResult(this.States[id]);
    }

    public async Task UpdateStateAsync(int id, int productId, bool available)
    {
        this.States[id].productId = productId;
        this.States[id].available = available;
    }

    public async Task DeleteStateAsync(int id)
    {
        this.States.Remove(id);
    }

    public async Task<Dictionary<int, IStateDTO>> GetAllStatesAsync()
    {
        return await Task.FromResult(this.States);
    }

    public async Task<int> GetStatesCountAsync()
    {
        return await Task.FromResult(this.States.Count);
    }

    #endregion


    #region Event CRUD

    public async Task AddEventAsync(int id, int stateId, int userId, string type)
    {
        this.Events.Add(id, new TestEventDTO(id, stateId, userId, type));
    }

    public async Task<IEventDTO> GetEventAsync(int id)
    {
        return await Task.FromResult(this.Events[id]);
    }

    public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
    {
        ((TestEventDTO)this.Events[id]).stateId = stateId;
        ((TestEventDTO)this.Events[id]).userId = userId;
        ((TestEventDTO)this.Events[id]).type = type;
    }

    public async Task DeleteEventAsync(int id)
    {
        this.Events.Remove(id);
    }

    public async Task<Dictionary<int, IEventDTO>> GetAllEventsAsync()
    {
        return await Task.FromResult(this.Events);
    }

    public async Task<int> GetEventsCountAsync()
    {
        return await Task.FromResult(this.Events.Count);
    }

    #endregion
}
using PresentationTests;
using PresentationTests.MockItems;
using Presentation.Model.API;

namespace PresentationTests.MockItems;

internal class MockDataRepository
{
    public Dictionary<int, IUserModel> Users = new Dictionary<int, IUserModel>();

    public Dictionary<int, IProductModel> Products = new Dictionary<int, IProductModel>();

    public Dictionary<int, IEventModel> Events = new Dictionary<int, IEventModel>();

    public Dictionary<int, IStateModel> States = new Dictionary<int, IStateModel>();

    #region User CRUD

    public async Task AddUserAsync(int id, string firstName, string lastName)
    {
        this.Users.Add(id, new MockUserDTO(id, firstName, lastName));
    }

    public async Task<IUserModel> GetUserAsync(int id)
    {
        return await Task.FromResult(this.Users[id]);
    }

    public async Task UpdateUserAsync(int id, string firstName, string lastName)
    {
        this.Users[id].FirstName = firstName;
        this.Users[id].LastName = lastName;
    }

    public async Task DeleteUserAsync(int id)
    {
        this.Users.Remove(id);
    }

    public async Task<Dictionary<int, IUserModel>> GetAllUsersAsync()
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
        this.Products.Add(id, new MockProductDTO(id, name, description, price));
    }

    public async Task<IProductModel> GetProductAsync(int id)
    {
        return await Task.FromResult(this.Products[id]);
    }

    public async Task UpdateProductAsync(int id, string name, string description, float price)
    {
        this.Products[id].ProductName = name;
        this.Products[id].ProductDescription = description;
        this.Products[id].Price = price;
    }

    public async Task DeleteProductAsync(int id)
    {
        this.Products.Remove(id);
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProductsAsync()
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
        this.States.Add(id, new MockStateDTO(id, productId, available));
    }

    public async Task<IStateModel> GetStateAsync(int id)
    {
        return await Task.FromResult(this.States[id]);
    }

    public async Task UpdateStateAsync(int id, int productId, bool available)
    {
        this.States[id].ProductId = productId;
        this.States[id].Available = available;
    }

    public async Task DeleteStateAsync(int id)
    {
        this.States.Remove(id);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStatesAsync()
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
        this.Events.Add(id, new MockEventDTO(id, stateId, userId, type));
    }

    public async Task<IEventModel> GetEventAsync(int id)
    {
        return await Task.FromResult(this.Events[id]);
    }

    public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
    {
        ((MockEventDTO)this.Events[id]).StateId = stateId;
        ((MockEventDTO)this.Events[id]).UserId = userId;
        ((MockEventDTO)this.Events[id]).Type = type;
    }

    public async Task DeleteEventAsync(int id)
    {
        this.Events.Remove(id);
    }

    public async Task<Dictionary<int, IEventModel>> GetAllEventsAsync()
    {
        return await Task.FromResult(this.Events);
    }

    public async Task<int> GetEventsCountAsync()
    {
        return await Task.FromResult(this.Events.Count);
    }

    #endregion
}
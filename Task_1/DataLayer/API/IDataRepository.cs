using DataLayer.Implementation;
using System.Collections.Generic;

namespace DataLayer.API
{   //We store all data manipulation methods here for use with Dependency Injection
    public interface IDataRepository
    {
        static IDataRepository CreateDatabase(IDataContext? dataContext = null)
        {
            return new DataRepository(dataContext ?? new DataContext());
        }

        #region User CRUD
        Task AddUserAsync(int id, string firstName, string lastName);
        Task<IUser> GetUserAsync(int id);
        Task UpdateUserAsync(int id, string firstName, string lastName);
        Task DeleteUserAsync(int id);
        Task<Dictionary<int, IUser>> GetAllUsersAsync();
        Task<int> GetUsersCountAsync();
        #endregion User CRUD

        #region Product CRUD
        Task AddProductAsync(int id, string name, string description, float price);
        Task<IProduct> GetProductAsync(int id);
        Task UpdateProductAsync(int id, string name, string description, float price);
        Task DeleteProductAsync(int id);
        Task<Dictionary<int, IProduct>> GetAllProductsAsync();
        Task<int> GetProductsCountAsync();
        #endregion

        #region State CRUD
        Task AddStateAsync(int id, int productId);
        Task<IState> GetStateAsync(int id);
        Task UpdateStateAsync(int id, int productId);
        Task DeleteStateAsync(int id);
        Task<Dictionary<int, IState>> GetAllStatesAsync();
        Task<int> GetStatesCountAsync();
        #endregion

        #region Event CRUD
        Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0);
        Task<IEvent> GetEventAsync(int id, string type);
        Task UpdateEventAsync(int id, int stateId, int userId, string type);
        Task DeleteEventAsync(int id);
        Task<Dictionary<int, IEvent>> GetAllEventsAsync();
        Task<int> GetEventsCountAsync();
        #endregion
    }
}
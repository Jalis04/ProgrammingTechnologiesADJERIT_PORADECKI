using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataRepository : IDataRepository
    {
        private IDataContext _context;

        public DataRepository(IDataContext context)
        {
            this._context = context;
        }

        #region User CRUD

        public async Task AddUserAsync(int id, string firstName, string lastName)
        {
            IUser user = new User(id, firstName, lastName);

            await this._context.AddUserAsync(user);
        }

        public async Task<IUser> GetUserAsync(int id)
        {
            IUser? user = await this._context.GetUserAsync(id);

            if (user is null)
                throw new Exception("This user does not exist!");

            return user;
        }

        public async Task UpdateUserAsync(int id, string firstName, string lastName)
        {
            IUser user = new User(id, firstName, lastName);

            if (!await this.CheckIfUserExists(user.id))
                throw new Exception("This user does not exist");

            await this._context.UpdateUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            if (!await this.CheckIfUserExists(id))
                throw new Exception("This user does not exist");

            await this._context.DeleteUserAsync(id);
        }

        public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
        {
            return await this._context.GetAllUsersAsync();
        }

        public async Task<int> GetUsersCountAsync()
        {
            return await this._context.GetUsersCountAsync();
        }

        #endregion


        #region Product CRUD

        public async Task AddProductAsync(int id, string name, string description, float price)
        {
            IProduct product = new Product(id, name, description, price);

            await this._context.AddProductAsync(product);
        }

        public async Task<IProduct> GetProductAsync(int id)
        {
            IProduct? product = await this._context.GetProductAsync(id);

            if (product is null)
                throw new Exception("This product does not exist!");

            return product;
        }

        public async Task UpdateProductAsync(int id, string name, string description, float price)
        {
            IProduct product = new Product(id, name, description, price);

            if (!await this.CheckIfProductExists(product.id))
                throw new Exception("This product does not exist");

            await this._context.UpdateProductAsync(product);
        }

        public async Task DeleteProductAsync(int id)
        {
            if (!await this.CheckIfProductExists(id))
                throw new Exception("This product does not exist");

            await this._context.DeleteProductAsync(id);
        }

        public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
        {
            return await this._context.GetAllProductsAsync();
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await this._context.GetProductsCountAsync();
        }

        #endregion


        #region State CRUD

        public async Task AddStateAsync(int id, int productId)
        {
            if (!await this._context.CheckIfProductExists(productId))
                throw new Exception("This product does not exist!");

            IState state = new State(id, productId);

            await this._context.AddStateAsync(state);
        }

        public async Task<IState> GetStateAsync(int id)
        {
            IState? state = await this._context.GetStateAsync(id);

            if (state is null)
                throw new Exception("This state does not exist!");

            return state;
        }

        public async Task UpdateStateAsync(int id, int productId)
        {
            if (!await this._context.CheckIfProductExists(productId))
                throw new Exception("This product does not exist!");

            IState state = new State(id, productId);

            if (!await this.CheckIfStateExists(state.stateId))
                throw new Exception("This state does not exist");

            await this._context.UpdateStateAsync(state);
        }

        public async Task DeleteStateAsync(int id)
        {
            if (!await this.CheckIfStateExists(id))
                throw new Exception("This state does not exist");

            await this._context.DeleteStateAsync(id);
        }

        public async Task<Dictionary<int, IState>> GetAllStatesAsync()
        {
            return await this._context.GetAllStatesAsync();
        }

        public async Task<int> GetStatesCountAsync()
        {
            return await this._context.GetStatesCountAsync();
        }

        #endregion


        #region Event CRUD

        public async Task AddEventAsync(int id, int stateId, int userId, string type, int quantity = 0)
        {
            IEvent newEvent;

            IUser user = await this.GetUserAsync(userId);
            IState state = await this.GetStateAsync(stateId);
            IProduct product = await this.GetProductAsync(state.productId);

            switch (type)
            {
                case "PlacedOrder":
                    newEvent = new Event(id, stateId, userId, type);

                    if (state.available == false)
                        throw new Exception("Product unavailable, please check later!");

                    await this.UpdateStateAsync(stateId, product.id);
                    await this.UpdateUserAsync(userId, user.firstName, user.lastName);

                    break;

                case "PayedOrder":
                    newEvent = new Event(id, stateId, userId, type);

                    Dictionary<int, IEvent> events = await this.GetAllEventsAsync();
                    Dictionary<int, IState> states = await this.GetAllStatesAsync();

                    int copiesBought = 0;

                    break;
            }

            //await this._context.AddEventAsync(newEvent, type);
        }

        public async Task<IEvent> GetEventAsync(int id, string type)
        {
            IEvent? even = await this._context.GetEventAsync(id);

            if (even is null)
                throw new Exception("This event does not exist!");

            return even;
        }

        public async Task UpdateEventAsync(int id, int stateId, int userId, string type)
        {
            IEvent newEvent = new Event(id, stateId, userId, type);

            if (!await this.CheckIfEventExists(newEvent.eventId, type))
                throw new Exception("This event does not exist");

            await this._context.UpdateEventAsync(newEvent);
        }

        public async Task DeleteEventAsync(int id)
        {
            if (!await this.CheckIfEventExists(id, "PayedEvent"))
                throw new Exception("This event does not exist");

            await this._context.DeleteEventAsync(id);
        }

        public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
        {
            return await this._context.GetAllEventsAsync();
        }

        public async Task<int> GetEventsCountAsync()
        {
            return await this._context.GetEventsCountAsync();
        }

        #endregion


        #region Utils

        public async Task<bool> CheckIfUserExists(int id)
        {
            return await this._context.CheckIfUserExists(id);
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return await this._context.CheckIfProductExists(id);
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return await this._context.CheckIfStateExists(id);
        }

        public async Task<bool> CheckIfEventExists(int id, string type)
        {
            return await this._context.CheckIfEventExists(id);
        }
        #endregion
    }
}

using DataLayer.API;
using DataLayer.Instrumentation;
using System.Net.Http;

namespace DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        public DataContext()
        {

        }

        private readonly string ConnectionString =
            "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=E:\\c#\\ProgrammingTechnologiesADJERIT_PORADECKI\\Task_1\\DataLayerTests\\Instrumentation\\CoffeeShopDB.mdf;Integrated Security=True";

        #region User CRUD

        public async Task AddUserAsync(IUser user)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User entity = new Instrumentation.User()
                {
                    Id = user.id,
                    FirstName = user.firstName,
                    LastName = user.lastName,
                };

                context.Users.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IUser?> GetUserAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User? user = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.User> query =
                        from u in context.Users
                        where u.Id == id
                        select u;

                    return query.FirstOrDefault();
                });

                return user is not null ? new User(user.Id, user.FirstName, user.LastName) : null;
            }
        }

        public async Task UpdateUserAsync(IUser user)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User toUpdate = (from u in context.Users where u.Id == user.id select u).FirstOrDefault()!;

                toUpdate.Id = user.id;
                toUpdate.FirstName = user.firstName;
                toUpdate.LastName = user.lastName;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteUserAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.User toDelete = (from u in context.Users where u.Id == id select u).FirstOrDefault()!;

                context.Users.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IUser>> GetAllUsersAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IUser> usersQuery = from u in context.Users
                                               select
                                                   new User(u.Id, u.FirstName, u.LastName) as IUser;

                return await Task.Run(() => usersQuery.ToDictionary(k => k.id));
            }
        }

        public async Task<int> GetUsersCountAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Users.Count());
            }
        }

        #endregion


        #region Product CRUD

        public async Task AddProductAsync(IProduct product)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product entity = new Instrumentation.Product()
                {
                    Id = product.id,
                    ProductName = product.productName,
                    ProductDescription = product.productDescription,
                    Price = product.price,
                };

                context.Products.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IProduct?> GetProductAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product? product = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Product> query =
                        from p in context.Products
                        where p.Id == id
                        select p;

                    return query.FirstOrDefault();
                });

                return product is not null ? new Product(product.Id, product.ProductName, product.ProductDescription, (float)product.Price) : null;
            }
        }

        public async Task UpdateProductAsync(IProduct product)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product toUpdate = (from p in context.Products where p.Id == product.id select p).FirstOrDefault()!;

                toUpdate.ProductName = product.productName;
                toUpdate.ProductDescription = product.productDescription;
                toUpdate.Price = product.price;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteProductAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Product toDelete = (from p in context.Products where p.Id == id select p).FirstOrDefault()!;

                context.Products.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IProduct>> GetAllProductsAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IProduct> productQuery = from p in context.Products
                                                    select
                                                        new Product(p.Id, p.ProductName, p.ProductDescription, (float)p.Price) as IProduct;

                return await Task.Run(() => productQuery.ToDictionary(k => k.id));
            }
        }

        public async Task<int> GetProductsCountAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Products.Count());
            }
        }

        #endregion


        #region State CRUD

        public async Task AddStateAsync(IState state)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State entity = new Instrumentation.State()
                {
                    StateId = state.stateId,
                    ProductId = state.productId,
                    Availavle = state.available,
                };

                context.States.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IState?> GetStateAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State? state = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.State> query =
                        from s in context.States
                        where s.StateId == id
                        select s;

                    return query.FirstOrDefault();
                });

                return state is not null ? new State(state.StateId, state.ProductId) : null;
            }
        }

        public async Task UpdateStateAsync(IState state)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State toUpdate = (from s in context.States where s.StateId == state.stateId select s).FirstOrDefault()!;

                toUpdate.ProductId = state.productId;
                toUpdate.Availavle = state.available;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteStateAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.State toDelete = (from s in context.States where s.StateId == id select s).FirstOrDefault()!;

                context.States.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IState>> GetAllStatesAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IState> stateQuery = from s in context.States
                                                select
                                                    new State(s.StateId, s.ProductId) as IState;

                return await Task.Run(() => stateQuery.ToDictionary(k => k.stateId));
            }
        }

        public async Task<int> GetStatesCountAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.States.Count());
            }
        }

        #endregion


        #region Event CRUD

        public async Task AddEventAsync(IEvent e, string type)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.PayedOrder entity = new Instrumentation.PayedOrder()
                {
                    EventId = e.eventId,
                    StateId = e.stateId,
                    UserId = e.userId,
                    EventDate = e.eventDate,
                };

                context.PayedOrders.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IEvent?> GetEventAsync(int id, string type)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.PayedOrder? e = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.PayedOrder> query =
                        from e in context.PayedOrders
                        where e.EventId == id
                        select e;

                    return query.FirstOrDefault();
                });


                PayedOrder payedOrder = new PayedOrder();
                return (IEvent?)payedOrder;
            }

        }

        public async Task UpdateEventAsync(IEvent even)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.PayedOrder toUpdate = (from e in context.PayedOrders where e.id == even.Id select e).FirstOrDefault()!;

                toUpdate.StateId = even.stateId;
                toUpdate.UserId = even.userId;
                toUpdate.EventId = even.eventId;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteEventAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.PayedOrder toDelete = (from e in context.PayedOrders where e.id == id select e).FirstOrDefault()!;

                context.PayedOrders.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IEvent> eventQuery = from e in context.PayedOrders
                                                select
                                                    new PayedOrder() as IEvent;

                return await Task.Run(() => eventQuery.ToDictionary(k => k.eventId));
            }
        }

        public async Task<int> GetEventsCountAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.PayedOrders.Count());
            }
        }

        #endregion


        #region Utils

        public async Task<bool> CheckIfUserExists(int id)
        {
            return (await this.GetUserAsync(id)) != null;
        }

        public async Task<bool> CheckIfProductExists(int id)
        {
            return (await this.GetProductAsync(id)) != null;
        }

        public async Task<bool> CheckIfStateExists(int id)
        {
            return (await this.GetStateAsync(id)) != null;
        }

        public async Task<bool> CheckIfEventExists(int id, string type)
        {
            return (await this.GetEventAsync(id, type)) != null;
        }

        #endregion
    }
}

﻿using DataLayer.API;
using DataLayer.Instrumentation;
using System.Net.Http;

namespace DataLayer.Implementation
{
    internal class DataContext : IDataContext
    {
        public DataContext(string? connectionString = null)
        {
            if (connectionString is null)
            {
                string _projectRootDir = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName;
                string _DBRelativePath = @"DataLayer\Instrumentation\CoffeeShopDB.mdf";
                string _DBPath = Path.Combine(_projectRootDir, _DBRelativePath);
                System.Console.WriteLine(_DBPath);
                this.ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={_DBPath};Integrated Security = True; Connect Timeout = 30;";
            }
            else
            {
                this.ConnectionString = connectionString;
            }
        }

        private readonly string ConnectionString;


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

        public async Task AddEventAsync(IEvent e)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event entity = new Instrumentation.Event()
                {
                    Id = e.eventId,
                    StateId = e.stateId,
                    UserId = e.userId,
                    EventDate = e.eventDate,
                    Type = e.type

                };

                context.Events.InsertOnSubmit(entity);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<IEvent?> GetEventAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event? even = await Task.Run(() =>
                {
                    IQueryable<Instrumentation.Event> query =
                        from e in context.Events
                        where e.Id == id
                        select e;

                    return query.FirstOrDefault();
                });

                return even is not null ? new Event(even.Id, even.StateId, even.UserId, even.Type) : null;
            }

        }

        public async Task UpdateEventAsync(IEvent even)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event toUpdate = (from e in context.Events where e.Id == even.eventId select e).FirstOrDefault()!;

                toUpdate.StateId = even.stateId;
                toUpdate.UserId = even.userId;
                toUpdate.Id = even.eventId;
                toUpdate.Type = even.type;

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task DeleteEventAsync(int id)
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                Instrumentation.Event toDelete = (from e in context.Events where e.Id == id select e).FirstOrDefault()!;

                context.Events.DeleteOnSubmit(toDelete);

                await Task.Run(() => context.SubmitChanges());
            }
        }

        public async Task<Dictionary<int, IEvent>> GetAllEventsAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                IQueryable<IEvent> eventQuery = from e in context.Events
                                                select
                                                    new Event(e.Id, e.StateId, e.UserId, e.Type) as IEvent;

                return await Task.Run(() => eventQuery.ToDictionary(k => k.eventId));
            }
        }

        public async Task<int> GetEventsCountAsync()
        {
            using (CoffeeShopDataContext context = new CoffeeShopDataContext(this.ConnectionString))
            {
                return await Task.Run(() => context.Events.Count());
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

        public async Task<bool> CheckIfEventExists(int id)
        {
            return (await this.GetEventAsync(id)) != null;
        }

        #endregion
    }
}

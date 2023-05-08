using DataLayer.Implementation;
using System.Collections.Generic;

namespace DataLayer.API
{
    public interface IDataContext
    {
        public IQueryable<IUser> users { get; }
        public IQueryable<IProduct> catalog { get; }
        public IQueryable<IState> states { get; }
        public IQueryable<IEvent> payed { get; }
        public IQueryable<IEvent> placed { get; }

        public static IDataContext CreateContext(string? connectionString = null) => new DataContext(connectionString);
        Task AddCatalogAsync(IProduct catalog);
        Task AddPayedEventAsync(IEvent payed);
        Task AddPlacedEventAsync(IEvent placed);
        Task AddStateAsync(IState state);
        Task AddUserAsync(IUser user);
        Task DeleteCatalogAsync(string Id);
        Task DeletePayedEventAsync(string Id);
        Task DeletePlacedEventAsync(string Id);
        Task DeleteStateAsync(string Id);
        Task DeleteUserAsync(string Id);

    }
}

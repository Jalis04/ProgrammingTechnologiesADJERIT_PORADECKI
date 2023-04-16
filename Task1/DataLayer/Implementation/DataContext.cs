using DataLayer.API;


namespace DataLayer.Implementation
{
    public class DataContext : IDataContext
    {
        internal Dictionary<string, IProduct> catalog = new();
        internal List<IEvent> events = new();
        internal List<IState> states = new();
        internal List<IUser> users = new();
    }
}

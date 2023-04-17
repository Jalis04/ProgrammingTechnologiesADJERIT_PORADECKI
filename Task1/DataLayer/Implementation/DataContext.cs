using DataLayer.API;


namespace DataLayer.Implementation
{
    public class DataContext : IDataContext
    {
        public DataContext()
        {
            this.catalog = new Dictionary<string, IProduct>();
            this.events = new List<IEvent>();
            this.states = new List<IState>();
            this.users = new List<IUser>();
        }

        public Dictionary<string, IProduct> catalog { get; set; }
        public List<IEvent> events { get; set; }
        public List<IState> states { get; set; }
        public List<IUser> users { get; set; }

    }
}

using DataLayer.Implementation;

namespace DataLayer.API
{   //We store all data manipulation methods here for use with Dependency Injection
    public interface IDataRepository
    {
        public static IDataRepository CreateDataRepository()
        {
            return new DataRepository();
        }

        //User methods
        public void AddUser(IUser u);
        public IUser GetUser(string id);
        public IEnumerable<IUser> GetAllUsers();

        public void DeleteUser(IUser u);   
        public void DeleteUserWithId(string id);
        public bool UserExists(string id);

        //Product methods
        public void AddProduct(IProduct c);
        public IProduct GetProduct(string id);
        public IEnumerable<IProduct> GetAllProducts();
        public void DeleteProductWithId(string id);
        public void DeleteProduct(IProduct c); // If we have a catalog.
        public bool ProductExists(string id);

        //State methods
        public void AddState(IState s);
        public IState GetState(string id);
        public IEnumerable<IState> GetAllStates();
        public void DeleteState(IState s); // If we have a state
        public void DeleteStateWithId(string id);
        public bool StateExists(string id);
        public bool IsAvailable(string id);
        public void ChangeAvailability(string id);

        //Event methods

        public void AddEvent(IEvent e);
        public IEnumerable<IEvent> GetAllEvents();
        public void DeleteEvent(IEvent e);


    }
}

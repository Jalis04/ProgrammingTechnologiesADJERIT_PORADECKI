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
        public void AddUser(string id, string firstName, string lastName);
        public IUser GetUser(string id);
        public IEnumerable<IUser> GetAllUsers();

        public void DeleteUser(string id);   
        public bool UserExists(string id);

        //Product methods
        public void AddProduct(string id, string productName, string productDescription, float price);
        public IProduct GetProduct(string id);
        public IEnumerable<IProduct> GetAllProducts();
        public void DeleteProduct(string id); // If we have a catalog.
        public bool ProductExists(string id);

        //State methods
        public void AddState(string stateId, string productId);
        public IState GetState(string id);
        public IEnumerable<IState> GetAllStates();
        public void DeleteState(string id); // If we have a state
        public bool StateExists(string id);
        public bool IsAvailable(string id);
        public void ChangeAvailability(string id);

        //Event methods

        public void AddEvent(string event_type, string eventId, string stateId, string userId);
        public IEnumerable<IEvent> GetAllEvents();
        public void DeleteEvent(string id);


    }
}

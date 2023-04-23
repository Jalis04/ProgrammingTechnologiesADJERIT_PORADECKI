using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataRepository : IDataRepository
    {
        private readonly DataContext dataContext;

        public DataRepository()
        {
            dataContext = new DataContext();
        }

        public void AddUser(string id, string firstName, string lastName)
        {
            dataContext.users.Add(new User(id, firstName, lastName));
        }

        public IUser GetUser(string id)
        {
            return dataContext.users.Single(u => u.id == id);
        }

        public IEnumerable<IUser> GetAllUsers()
        {
            return dataContext.users;
        }

        public void DeleteUser(string id) //if we have a user. 
        {
            int placed = 0;
            int paid = 0;
            foreach (var e in dataContext.events.OfType<PlaceOrderEvent>())
                if (e.userId == id)
                    placed++;
            foreach (var e in dataContext.events.OfType<PayOrderEvent>())
                if (e.userId == id)
                    paid++;
            if (placed != paid)
                throw new Exception("User has an unpaid order, cannot be deleted.");
            dataContext.users.Remove(dataContext.users.Single(u => u.id == id));
        }

        public void DeleteUserWithId(string id)
        {
            int placed = 0;
            int paid = 0;
            foreach (var e in dataContext.events.OfType<PlaceOrderEvent>())
                if (e.userId == id)
                    placed++;
            foreach (var e in dataContext.events.OfType<PayOrderEvent>())
                if (e.userId == id)
                    paid++;
            if (placed != paid)
                throw new Exception("User has an unreturned book, cannot be deleted.");
            dataContext.users.Remove(dataContext.users.Single(u => u.id == id));
        }

        public bool UserExists(string id)
        {
            foreach (var user in dataContext.users)
            {
                if (user.id == id) return true;
            }
            return false;
        }

        public void AddProduct(string id, string productName, string productDescription, float price)
        {
            dataContext.catalog.Add(id, new Product(id, productName, productDescription, price));
        }

        public IProduct GetProduct(string id)
        {
            return dataContext.catalog[id];
        }

        public IEnumerable<IProduct> GetAllProducts()
        {
            return dataContext.catalog.Values;
        }

        public void DeleteProduct(string id)
        {
            foreach (var s in dataContext.catalog)
                if (s.Key == id)
                dataContext.catalog.Remove(id);
        }

        public bool ProductExists(string id)
        {
            return dataContext.catalog.ContainsKey(id);
        }

        public void AddEvent(string event_type, string eventId, string stateId, string userId)
        {
            if (event_type == "Pay")
            {
                dataContext.events.Add(new PayOrderEvent(eventId, stateId, userId));
            }
            else if (event_type == "Place")
            {
                dataContext.events.Add(new PlaceOrderEvent(eventId, stateId, userId));
            }

        }

        public IEnumerable<IEvent> GetAllEvents()
        {
            return dataContext.events;
        }

        public void DeleteEvent(string id)
        {
            foreach (var ee in dataContext.events)
                if (id == ee.eventId)
                {
                    dataContext.events.Remove(ee);
                    return;
                }

            throw new Exception("There is no such event");
        }
        public void AddState(string stateId, string productId)
        {
             dataContext.states.Add(new State(stateId, productId));
        }

        public IState GetState(string id)
        {
            return dataContext.states.Single(s => s.stateId == id);
        }

        public IEnumerable<IState> GetAllStates()
        {
            return dataContext.states;
        }

        public void DeleteState(string id) // If we have a state
        {
            foreach (var s in dataContext.states)
            {
                if (s.stateId == id)
                {
                    dataContext.states.Remove(s);

                }
            }
        }

        public bool StateExists(string id)
        {
            foreach (var state in dataContext.states)
            {
                if (state.stateId == id) return true;
            }
            return false;
        }

        public bool IsAvailable(string id)
        {
            foreach (var s in dataContext.states)
            {
                if (s.stateId == id)
                {
                    if (s.available) return true;
                }
            }
            return false;
        }

        public void ChangeAvailability(string id)
        {
            foreach (var s in dataContext.states)
            {
                if (s.stateId == id)
                {
                    if (s.available)
                    {
                        s.available = false;
                        break;
                    }
                    if (!s.available) s.available = true;
                    break;
                }
            }
        }
    }
}

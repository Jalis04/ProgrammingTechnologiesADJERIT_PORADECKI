using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.Implementation;

namespace Task1f.DataLayer.API
{   //We store all data manipulation methods here for use with Dependency Injection
    public abstract class IDataRepository
    {
        //User methods
        public abstract void AddUser(IUser u);
        public abstract IUser GetUser(string id);
        public abstract IEnumerable<IUser> GetAllUsers();

        public abstract void DeleteUser(IUser u);   
        public abstract void DeleteUserWithId(string id);
        public abstract bool UserExists(string id);

        //Product methods
        public abstract void AddProduct(IProduct c);
        public abstract IProduct GetProduct(string id);
        public abstract IEnumerable<IProduct> GetAllProducts();
        public abstract void DeleteProductWithId(string id);
        public abstract void DeleteProduct(IProduct c); // If we have a catalog.
        public abstract bool ProductExists(string id);

        //State methods
        public abstract void AddState(IState s);
        public abstract IState GetState(string id);
        public abstract IEnumerable<IState> GetAllStates();
        public abstract void DeleteState(IState s); // If we have a state
        public abstract void DeleteStateWithId(string id);
        public abstract bool StateExists(string id);
        public abstract bool IsAvailable(string id);
        public abstract void ChangeAvailability(string id);

        //Event methods

        public abstract void AddEvent(IEvent e);
        public abstract IEnumerable<IEvent> GetAllEvents();
        public abstract void DeleteEvent(IEvent e);

        public static IDataRepository CreateDataRepository(IFill? fill = default)
        {
            return new DataRepository(fill ?? new EmptyFill());
        }


    }
}

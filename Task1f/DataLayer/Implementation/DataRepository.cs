using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;
using Task1f.LogicLayer.Implementation;

namespace Task1f.DataLayer.Implementation
{
    internal class DataRepository : IDataRepository
    {
        private readonly DataContext dataContext;

        public DataRepository(IFill dataFill)
        {
            dataContext = new DataContext();
            dataFill.Fill(this);
        }

        public override void AddUser(IUser u)
        {
            dataContext.users.Add(u);
        }

        public override IUser GetUser(string id)
        {
            return dataContext.users.Single(u => u.Id == id);
        }

        public override IEnumerable<IUser> GetAllUsers()
        {
            return dataContext.users;
        }

        public override void DeleteUser(IUser u) //if we have a user. 
        {
            int placed = 0;
            int paid = 0;
            foreach (var e in dataContext.events.OfType<PlaceOrderEvent>())
                if (e.UserId == u.Id)
                    placed++;
            foreach (var e in dataContext.events.OfType<PayOrderEvent>())
                if (e.UserId == u.Id)
                    paid++;
            if (placed != paid)
                throw new Exception("User has an unpaid order, cannot be deleted.");
            dataContext.users.Remove(u);
        }

        public override void DeleteUserWithId(string id)
        {
            int placed = 0;
            int paid = 0;
            foreach (var e in dataContext.events.OfType<PlaceOrderEvent>())
                if (e.UserId == id)
                    placed++;
            foreach (var e in dataContext.events.OfType<PayOrderEvent>())
                if (e.UserId == id)
                    paid++;
            if (placed != paid)
                throw new Exception("User has an unreturned book, cannot be deleted.");
            dataContext.users.Remove(dataContext.users.Single(u => u.Id == id));
        }

        public override bool UserExists(string id)
        {
            foreach (var user in dataContext.users)
            {
                if (user.Id == id) return true;
            }
            return false;
        }

        public override void AddProduct(IProduct c)
        {
            dataContext.catalog.Add(c.id, c);
        }

        public override IProduct GetProduct(string id)
        {
            return dataContext.catalog[id];
        }

        public override IEnumerable<IProduct> GetAllProducts()
        {
            return dataContext.catalog.Values;
        }

        public override void DeleteProductWithId(string id)
        {
            foreach (var s in dataContext.states)
                if (s.ProductId == id)
                    throw new Exception("Cannot remove object. Current state is used");
            dataContext.catalog.Remove(id);
        }

        public override void DeleteProduct(IProduct c) // If we have a catalog.
        {
            foreach (var s in dataContext.states)
                if (s.ProductId == c.id)
                    throw new Exception("Cannot remove object. Current state is used");

            dataContext.catalog.Remove(c.id);
        }

        public override bool ProductExists(string id)
        {
            return dataContext.catalog.ContainsKey(id);
        }

        public override void AddEvent(IEvent e)
        {
            dataContext.events.Add(e);
        }

        public override IEnumerable<IEvent> GetAllEvents()
        {
            return dataContext.events;
        }

        public override void DeleteEvent(IEvent e)
        {
            foreach (var ee in dataContext.events)
                if (e.Equals(ee))
                {
                    dataContext.events.Remove(e);
                    return;
                }

            throw new Exception("There is no such event");
        }
        public override void AddState(IState s)
        {
            dataContext.states.Add(s);
        }

        public override IState GetState(string id)
        {
            return dataContext.states.Single(s => s.StateId == id);
        }

        public override IEnumerable<IState> GetAllStates()
        {
            return dataContext.states;
        }

        public override void DeleteState(IState s) // If we have a state
        {
            foreach (var e in dataContext.events)
                if (e.StateId == s.StateId)
                    throw new Exception("State is in use");
            dataContext.states.Remove(s);
        }

        public override void DeleteStateWithId(string id)
        {
            foreach (var e in dataContext.events)
                if (e.StateId == id)
                    throw new Exception("State is in use");
            dataContext.states.Remove(dataContext.states.Single(s => s.StateId == id));
        }

        public override bool StateExists(string id)
        {
            foreach (var state in dataContext.states)
            {
                if (state.StateId == id) return true;
            }
            return false;
        }

        public override bool IsAvailable(string id)
        {
            foreach (var s in dataContext.states)
            {
                if (s.StateId == id)
                {
                    if (s.Available) return true;
                }
            }
            return false;
        }

        public override void ChangeAvailability(string id)
        {
            foreach (var s in dataContext.states)
            {
                if (s.StateId == id)
                {
                    if (s.Available)
                    {
                        s.Available = false;
                        break;
                    }
                    if (!s.Available) s.Available = true;
                    break;
                }
            }
        }
    }
}

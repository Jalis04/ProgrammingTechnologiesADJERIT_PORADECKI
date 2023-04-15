using DataLayer.API;
using DataLayer.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementation
{
    public class CoffeeShopLogic2
    {
        private readonly ICatalog _catalog;
        private readonly List<IUser> _users;
        private readonly List<IEvent> _events;

        public CoffeeShopLogic2(ICatalog catalog, List<IUser> users, List<IEvent> events)
        {
            _catalog = catalog;
            _users = users;
            _events = events;
        }

        public void TakeOrder(IUser user, IOrder order)
        {
            // Check that the user is authorized to take orders
            if (!user.CanTakeOrders)
            {
                throw new InvalidOperationException("User is not authorized to take orders.");
            }

            // Add the order to the user's order history
            user.AddOrder(order);

            // Add an event to represent the order being taken
            var event = new OrderTakenEvent(user, order);
            _events.Add(event);
        }

        public IEnumerable<IEvent> GetEvents(DateTime startDate, DateTime endDate)
        {
            // Return all events that occurred between the start and end dates
            return _events.Where(e => e.Timestamp >= startDate && e.Timestamp <= endDate);
        }

        // Other methods for managing the catalog and user list could go here
    }

}

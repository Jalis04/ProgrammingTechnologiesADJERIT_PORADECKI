using DataLayer.API;
using DataLayer.Implementation;

namespace DataLayerTests
{
    [TestClass]
    public class DataLayerStaticTests
    {
        [TestMethod]
        public void TestUserGetSet()
        {
            IUser user = new User("01", "John", "Doe");
            Assert.AreSame(user.id, "01");
            Assert.AreSame(user.firstName, "John");
            Assert.AreSame(user.lastName, "Doe");

        }

        [TestMethod]
        public void TestDataRepositoryWithUser()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IUser user = new User("01", "John", "Doe");
            IUser user2 = new User("02", "Tom", "Eod");
            dataRepository.AddUser(user);
            dataRepository.AddUser(user2);
            IEnumerable<IUser> users = new[] { user, user2 };
            Assert.IsTrue(new HashSet<IUser>(users).SetEquals(dataRepository.GetAllUsers())); // compares two enumerables

            Assert.IsTrue(dataRepository.UserExists(user.id));
            Assert.IsFalse(dataRepository.UserExists(user.id + 1));
            Assert.AreSame(dataRepository.GetUser(user.id), user);

            dataRepository.DeleteUser(user);
            Assert.IsFalse(dataRepository.UserExists(user.id));

            dataRepository.DeleteUserWithId(user2.id);
            Assert.IsFalse(dataRepository.UserExists(user2.id));
            

        }

        [TestMethod]
        public void TestProductGetSet()
        {
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            Assert.AreSame(product.id, "01");
            Assert.AreSame(product.productName, "Black coffee");
            Assert.AreSame(product.productDescription, "Description");
        }

        [TestMethod]
        public void TestDataRepositoryWithProduct()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            IProduct product2 = new Product("02", "White coffee", "Description2", 4.49f);
            dataRepository.AddProduct(product);
            dataRepository.AddProduct(product2);
            IEnumerable<IProduct> products = new[] { product, product2 };
            Assert.IsTrue(new HashSet<IProduct>(products).SetEquals(dataRepository.GetAllProducts())); // compares two enumerables

            Assert.IsTrue(dataRepository.ProductExists(product.id));
            Assert.IsFalse(dataRepository.ProductExists(product.id + 1));
            Assert.AreSame(dataRepository.GetProduct(product.id), product);

            dataRepository.DeleteProduct(product);
            Assert.IsFalse(dataRepository.UserExists(product.id));

            dataRepository.DeleteProductWithId(product2.id);
            Assert.IsFalse(dataRepository.UserExists(product2.id));
        }

        [TestMethod]
        public void TestStateGetSet()
        {
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            IState state = new State("01", product);
            Assert.AreSame(state.stateId, "01");
            Assert.AreSame(state.productId, product.id);
            Assert.IsTrue(state.available);
        }

        [TestMethod]
        public void TestDataRepositoryWithState()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IProduct product = new Product("01", "Black coffee", "Description", 3.99f);
            IProduct product2 = new Product("02", "White coffee", "Description2", 4.49f);
            IState state = new State("01", product);
            IState state2 = new State("02", product2);
            dataRepository.AddState(state);
            dataRepository.AddState(state2);
            IEnumerable<IState> states = new[] { state, state2 };
            Assert.IsTrue(new HashSet<IState>(states).SetEquals(dataRepository.GetAllStates())); // compares two enumerables

            Assert.IsTrue(dataRepository.IsAvailable("01"));
            dataRepository.ChangeAvailability("01");
            Assert.IsFalse(dataRepository.IsAvailable("01"));

            Assert.IsTrue(dataRepository.StateExists(state.stateId));
            Assert.IsFalse(dataRepository.StateExists(state.stateId + 1));
            Assert.AreSame(dataRepository.GetState(state.stateId), state);

            dataRepository.DeleteState(state);
            Assert.IsFalse(dataRepository.UserExists(state.stateId));

            dataRepository.DeleteStateWithId(state2.stateId);
            Assert.IsFalse(dataRepository.UserExists(state2.stateId));
        }

        [TestMethod]
        public void TestEventPayOrder()
        {
            IEvent e = new PayOrderEvent("01", "01");
            Assert.AreSame(e.stateId, "01");
            Assert.AreSame(e.userId, "01");
        }

        [TestMethod]
        public void TestEventPlaceOrder()
        {
            IEvent e = new PlaceOrderEvent("01", "01");
            Assert.AreSame(e.stateId, "01");
            Assert.AreSame(e.userId, "01");
        }

        [TestMethod]
        public void TestDataRepositoryWithEvents()
        {
            IDataRepository dataRepository = IDataRepository.CreateDataRepository();
            IEvent e = new PayOrderEvent("01", "01");
            IEvent e2 = new PlaceOrderEvent("02", "03");
            dataRepository.AddEvent(e);
            dataRepository.AddEvent(e2);
            IEnumerable<IEvent> events = new[] { e, e2 };
            Assert.IsTrue(new HashSet<IEvent>(events).SetEquals(dataRepository.GetAllEvents())); // compares two enumerables
            dataRepository.DeleteEvent(e);

        }
    }
}
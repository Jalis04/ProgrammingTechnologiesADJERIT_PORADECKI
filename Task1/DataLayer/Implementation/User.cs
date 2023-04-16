using DataLayer.API;

namespace DataLayer.Implementation
{
    public class User : IUser
    {
        public User(string id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;
        }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public string id { get; set; }
    }
}

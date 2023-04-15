using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            // Initialize the user list with some sample data
            _users = new List<User>
        {
            new User { Id = 1, Name = "John Doe" },
            new User { Id = 2, Name = "Jane Smith" }
        };
        }

        public void Add(User user)
        {
            // Generate a new user ID
            int newUserId = _users.Count > 0 ? _users.Max(u => u.Id) + 1 : 1;
            user.Id = newUserId;

            // Add the user to the list
            _users.Add(user);
        }

        public void Update(User user)
        {
            // Find the user by ID
            User existingUser = GetById(user.Id);

            // Update the user's properties
            existingUser.Name = user.Name;
        }

        public void Delete(int userId)
        {
            // Find the user by ID
            User existingUser = GetById(userId);

            // Remove the user from the list
            _users.Remove(existingUser);
        }

        public List<User> GetAll()
        {
            // Return a copy of the user list
            return new List<User>(_users);
        }

        public User GetById(int userId)
        {
            // Find the user by ID
            User existingUser = _users.FirstOrDefault(u => u.Id == userId);

            // Check if the user was found
            if (existingUser == null)
            {
                throw new ArgumentException("User not found");
            }

            return existingUser;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;
using Task1v2.LogicLayer.API;
using Task1v2.DataLayer.API;

namespace Task1v2.LogicLayer.Implementation
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void AddUser(User user)
        {
            // Validate user input
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("User name cannot be empty or null");
            }

            // Add user to repository
            _userRepository.Add(user);
        }

        public void UpdateUser(User user)
        {
            // Validate user input
            if (string.IsNullOrEmpty(user.Name))
            {
                throw new ArgumentException("User name cannot be empty or null");
            }

            // Update user in repository
            _userRepository.Update(user);
        }

        public void DeleteUser(int userId)
        {
            // Delete user from repository
            _userRepository.Delete(userId);
        }

        public List<User> GetAllUsers()
        {
            // Get all users from repository
            return _userRepository.GetAll();
        }

        public User GetUserById(int userId)
        {
            // Get user by ID from repository
            return _userRepository.GetById(userId);
        }
    }
}

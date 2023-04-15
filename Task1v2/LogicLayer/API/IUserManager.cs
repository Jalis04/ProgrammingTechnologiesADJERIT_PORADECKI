using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.LogicLayer.API
{
    public interface IUserManager
    {
        void AddUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int userId);
        List<User> GetAllUsers();
        User GetUserById(int userId);
    }
}

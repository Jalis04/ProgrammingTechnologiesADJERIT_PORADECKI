using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.DataLayer.API
{
    public interface IUserRepository
    {
        void Add(User user);
        void Update(User user);
        void Delete(int userId);
        List<User> GetAll();
        User GetById(int userId);
    }
}

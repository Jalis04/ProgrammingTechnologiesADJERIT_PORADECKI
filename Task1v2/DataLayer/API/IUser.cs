using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1v2.DataLayer.API
{
    public interface IUser
    {
        int Id { get; set; }
        string Name { get; set; }
        string Email { get; set; }
        string Role { get; set; }
    }
}

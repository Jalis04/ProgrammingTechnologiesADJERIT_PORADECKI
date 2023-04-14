using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IUser
    {
        string Id { get; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
    }

}

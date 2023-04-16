using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1f.DataLayer.API
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Id { get; set; }
    }
}

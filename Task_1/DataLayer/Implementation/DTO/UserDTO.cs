using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class UserDTO : IUser
    {
        public string firstName { get; set; } = null!;
        public string lastName { get; set; } = null!;
        public string id { get; set; } = null!;
    }
}

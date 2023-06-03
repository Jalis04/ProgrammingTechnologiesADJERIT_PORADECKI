using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace ServiceTest
{
    internal class MockUser : IUser
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }

        public MockUser(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;

        }
    }
}

using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestUserDTO : IUserDTO
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public int id { get; set; }

        public TestUserDTO(int id, string firstName, string lastName)
        {
            this.id = id;
            this.firstName = firstName;
            this.lastName = lastName;

        }
    }
}

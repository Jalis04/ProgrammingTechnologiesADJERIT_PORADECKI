using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockUserDTO : IUserDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Id { get; set; }

        public MockUserDTO(int id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;

        }
    }
}

using Service.API;

namespace Service.Implementation;

internal class UserDTO : IUserDTO
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public int id { get; set; }

    public UserDTO(int id, string firstName, string lastName)
    {
        this.id = id;
        this.firstName = firstName;
        this.lastName = lastName;
        
    }
}

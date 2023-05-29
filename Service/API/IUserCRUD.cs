using Service.API;
using Service.Implementation;
using DataLayer.API;


namespace Service.API;

public interface IUserCRUD
{
    static IUserCRUD CreateUserCRUD(IDataRepository? dataRepository = null)
    {
        return new UserCRUD(dataRepository ?? IDataRepository.CreateDatabase());
    }

    Task AddUserAsync(int id, string firstName, string lastName);

    Task<IUserDTO> GetUserAsync(int id);

    Task UpdateUserAsync(int id, string firstName, string lastName);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUserDTO>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();
}

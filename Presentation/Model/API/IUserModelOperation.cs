using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IUserModelOperation
{
    static IUserModelOperation CreateModelOperation(IUserCRUD userCrud = null)
    {
        return new UserModelOperation(userCrud);
    }

    Task AddUserAsync(int id, string firstName, string lastName);

    Task<IUserModel> GetUserAsync(int id);

    Task UpdateUserAsync(int id, string firstName, string lastName);

    Task DeleteUserAsync(int id);

    Task<Dictionary<int, IUserModel>> GetAllUsersAsync();

    Task<int> GetUsersCountAsync();
}

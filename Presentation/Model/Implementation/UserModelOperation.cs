using Presentation.Model.API;
using Service.API;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Presentation.Model.Implementation;

internal class UserModelOperation : IUserModelOperation
{
    private IUserCRUD _userCRUD;

    public UserModelOperation(IUserCRUD? userCrud)
    {
        this._userCRUD = userCrud ?? IUserCRUD.CreateUserCRUD();
    }

    private IUserModel Map(IUserDTO user)
    {
        return new UserModel(user.Id, user.FirstName, user.LastName);
    }

    public async Task AddUserAsync(int id, string firstName, string lastName)
    {
        await this._userCRUD.AddUserAsync(id, firstName, lastName);
    }

    public async Task<IUserModel> GetUserAsync(int id)
    {
        return this.Map(await this._userCRUD.GetUserAsync(id));
    }

    public async Task UpdateUserAsync(int id, string firstName, string lastName)
    {
        await this._userCRUD.UpdateUserAsync(id, firstName, lastName);
    }

    public async Task DeleteUserAsync(int id)
    {
        await this._userCRUD.DeleteUserAsync(id);
    }

    public async Task<Dictionary<int, IUserModel>> GetAllUsersAsync()
    {
        Dictionary<int, IUserModel> result = new Dictionary<int, IUserModel>();

        foreach (IUserDTO user in (await this._userCRUD.GetAllUsersAsync()).Values)
        {
            result.Add(user.Id, this.Map(user));
        }

        return result;
    }

    public async Task<int> GetUsersCountAsync()
    {
        return await this._userCRUD.GetUsersCountAsync();
    }
}

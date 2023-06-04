using Service.API;
using System;

namespace Presentation.Model.API;

public interface IUserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }
}

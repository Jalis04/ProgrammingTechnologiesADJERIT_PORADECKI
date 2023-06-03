using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IStateModelOperation
{
    static IStateModelOperation CreateModelOperation(IStateCRUD? stateCrud = null)
    {
        return new StateModelOperation(stateCrud ?? IStateCRUD.CreateStateCRUD());
    }

    Task AddStateAsync(int stateid, int productId, bool available);

    Task<IStateModel> GetStateAsync(int stateid);

    Task UpdateStateAsync(int stateid, int productId, bool available);

    Task DeleteStateAsync(int stateid);

    Task<Dictionary<int, IStateModel>> GetAllStatesAsync();

    Task<int> GetStatesCountAsync();
}

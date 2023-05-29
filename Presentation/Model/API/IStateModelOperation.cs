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

    Task AddAsync(int stateid, int productId, bool available);

    Task<IStateModel> GetAsync(int stateid);

    Task UpdateAsync(int stateid, int productId, bool available);

    Task DeleteAsync(int stateid);

    Task<Dictionary<int, IStateModel>> GetAllAsync();

    Task<int> GetCountAsync();
}

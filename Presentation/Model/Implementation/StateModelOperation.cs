using Presentation.Model.API;
using Service.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation;

internal class StateModelOperation : IStateModelOperation
{
    private IStateCRUD _stateCrud;

    public StateModelOperation(IStateCRUD? stateCrud = null)
    {
        this._stateCrud = stateCrud ?? IStateCRUD.CreateStateCRUD();
    }

    private IStateModel Map(IStateDTO state)
    {
        return new StateModel(state.stateId, state.productId, state.available);
    }

    public async Task AddAsync(int stateId, int productId, bool available)
    {
        await this._stateCrud.AddStateAsync(stateId, productId, available);
    }

    public async Task<IStateModel> GetAsync(int stateId)
    {
        return this.Map(await this._stateCrud.GetStateAsync(stateId));
    }

    public async Task UpdateAsync(int stateId, int productId, bool available)
    {
        await this._stateCrud.UpdateStateAsync(stateId, productId, available);
    }

    public async Task DeleteAsync(int stateId)
    {
        await this._stateCrud.DeleteStateAsync(stateId);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllAsync()
    {
        Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

        foreach (IStateDTO state in (await this._stateCrud.GetAllStatesAsync()).Values)
        {
            result.Add(state.stateId, this.Map(state));
        }

        return result;
    }

    public async Task<int> GetCountAsync()
    {
        return await this._stateCrud.GetStatesCountAsync();
    }
}

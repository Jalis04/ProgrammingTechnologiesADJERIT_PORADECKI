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
        return new StateModel(state.StateId, state.ProductId, state.Available);
    }

    public async Task AddStateAsync(int stateId, int productId, bool available)
    {
        await this._stateCrud.AddStateAsync(stateId, productId, available);
    }

    public async Task<IStateModel> GetStateAsync(int stateId)
    {
        return this.Map(await this._stateCrud.GetStateAsync(stateId));
    }

    public async Task UpdateStateAsync(int stateId, int productId, bool available)
    {
        await this._stateCrud.UpdateStateAsync(stateId, productId, available);
    }

    public async Task DeleteStateAsync(int stateId)
    {
        await this._stateCrud.DeleteStateAsync(stateId);
    }

    public async Task<Dictionary<int, IStateModel>> GetAllStatesAsync()
    {
        Dictionary<int, IStateModel> result = new Dictionary<int, IStateModel>();

        foreach (IStateDTO state in (await this._stateCrud.GetAllStatesAsync()).Values)
        {
            result.Add(state.StateId, this.Map(state));
        }

        return result;
    }

    public async Task<int> GetStatesCountAsync()
    {
        return await this._stateCrud.GetStatesCountAsync();
    }
}

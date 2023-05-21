using Service.API;
using Service.Implementation;
using DataLayer.API;

namespace Service.API;

public interface IStateCRUD
{
    static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository)
    {
        return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase());
    }

    Task AddStateAsync(int id, int productId, int quantity);

    Task<IStateDTO> GetStateAsync(int id);

    Task UpdateStateAsync(int id, int productId, int quantity);

    Task DeleteStateAsync(int id);

    Task<Dictionary<int, IStateDTO>> GetAllStatesAsync();

    Task<int> GetStatesCountAsync();
}

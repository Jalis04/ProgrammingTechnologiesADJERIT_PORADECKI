using Service.API;
using Service.Implementation;
using DataLayer.API;

namespace Service.API;

public interface IStateCRUD
{
    static IStateCRUD CreateStateCRUD(IDataRepository? dataRepository = null)
    {
        return new StateCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddStateAsync(int id, int productId, bool available);

    Task<IStateDTO> GetStateAsync(int id);

    Task UpdateStateAsync(int id, int productId, bool available);

    Task DeleteStateAsync(int id);

    Task<Dictionary<int, IStateDTO>> GetAllStatesAsync();

    Task<int> GetStatesCountAsync();
}

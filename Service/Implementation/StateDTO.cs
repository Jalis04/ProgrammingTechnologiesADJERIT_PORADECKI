using Service.API;

namespace Service.Implementation;

internal class StateDTO : IStateDTO
{
    public int productId { get; }
    public int stateId { get; set; }

    public bool available { get; set; } 

    public StateDTO(int id, int productId, bool quantity)
    {
        this.stateId = id;
        this.productId = productId;
        this.available = available;
    }
}

using Service.API;

namespace Service.Implementation;

internal class StateDTO : IStateDTO
{
    public int productId { get; set; }
    public int stateId { get; set; }

    public bool available { get; set; } 

    public StateDTO(int id, int productId, bool available)
    {
        this.stateId = id;
        this.productId = productId;
        this.available = available;
    }
}

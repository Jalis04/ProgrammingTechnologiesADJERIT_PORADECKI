using Service.API;

namespace Service.Implementation;

internal class StateDTO : IStateDTO
{
    public int productId { get; }
    public int stateId { get; set; }

    //bool available { get; set; }
    public int available { get; set; } //db does not support bool

    public StateDTO(int id, int productId, int quantity)
    {
        this.stateId = id;
        this.productId = productId;
        this.available = quantity;
    }
}

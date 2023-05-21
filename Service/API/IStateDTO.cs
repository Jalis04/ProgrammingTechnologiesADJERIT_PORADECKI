namespace Service.API;

public interface IStateDTO
{
    int productId { get; }
    int stateId { get; set; }

    //bool available { get; set; }
    int available { get; set; } //db does not support bool
}

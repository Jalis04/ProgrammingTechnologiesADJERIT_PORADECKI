namespace Service.API;

public interface IStateDTO
{
    int productId { get; set; }
    int stateId { get; set; }

    bool available { get; set; } 
}

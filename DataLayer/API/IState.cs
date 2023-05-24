namespace DataLayer.API
{
    public interface IState
    {
        int productId { get; }
        int stateId { get; set; }

        bool available { get; set; }
    }
}

namespace DataLayer.API
{
    public interface IState
    {
        string productId { get; }
        string stateId { get; set; }

        bool available { get; set; }
    }
}

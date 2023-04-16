using DataLayer.API;

namespace DataLayer.Implementation
{
    public class State : IState
    {
        private readonly IProduct product;

        public State(string stateId, IProduct product)
        {
            this.stateId = stateId;
            this.product = product;
            available = true;
        }

        public string productId => product.id;
        public string stateId { get; set; }

        public bool available { get; set; }
    }
}

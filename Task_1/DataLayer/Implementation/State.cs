using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class State : IState
    {

        public State(string stateId, string productId)
        {
            this.stateId = stateId;
            this.productId = productId;
            available = true;
        }

        public string productId { get; }
        public string stateId { get; set; }

        public bool available { get; set; }
    }
}

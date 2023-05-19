using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class State : IState
    {

        public State(int stateId, int productId)
        {
            this.stateId = stateId;
            this.productId = productId;
            available = true;
        }

        public int productId { get; }
        public int stateId { get; set; }

        public bool available { get; set; }
    }
}

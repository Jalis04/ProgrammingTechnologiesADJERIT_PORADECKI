using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockStateDTO : IStateDTO
    {
        public int ProductId { get; set; }
        public int StateId { get; set; }

        public bool Available { get; set; }

        public MockStateDTO(int id, int productId, bool available)
        {
            this.StateId = id;
            this.ProductId = productId;
            this.Available = available;
        }
    }
}

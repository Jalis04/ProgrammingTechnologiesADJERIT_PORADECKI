using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockProductDTO : IProductDTO
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public float Price { get; set; }

        public MockProductDTO(int id, string productName, string productDescription, float price)
        {
            this.Id = id;
            this.ProductName = productName;
            this.ProductDescription = productDescription;
            this.Price = price;
        }
    }
}

using Service.API;

namespace Service.Implementation;

internal class ProductDTO : IProductDTO
{
    public int Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDescription { get; set; }
    public float Price { get; set; }

    public ProductDTO(int id, string productName, string productDescription, float price)
    {
        this.Id = id;
        this.ProductName = productName;
        this.ProductDescription = productDescription;
        this.Price = price;
    }
}

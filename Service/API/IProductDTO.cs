namespace Service.API;

public interface IProductDTO
{
    int Id { get; set; }
    string ProductName { get; set; }
    string ProductDescription { get; set; }
    float Price { get; set; }
}

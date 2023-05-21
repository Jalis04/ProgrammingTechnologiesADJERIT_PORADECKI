namespace Service.API;

public interface IProductDTO
{
    int id { get; set; }
    string productName { get; set; }
    string productDescription { get; set; }
    float price { get; set; }
}

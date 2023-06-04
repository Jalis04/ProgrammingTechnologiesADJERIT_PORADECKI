using Service.API;
using Service.Implementation;
using DataLayer.API;

namespace Service.API;

public interface IProductCRUD
{
    static IProductCRUD CreateProductCRUD(IDataRepository? dataRepository = null)
    {
        return new ProductCRUD(dataRepository ?? IDataRepository.CreateDatabase(ConnectionString.GetConnectionString()));
    }

    Task AddProductAsync(int id, string productName, string productDescription, float price);

    Task<IProductDTO> GetProductAsync(int id);

    Task UpdateProductAsync(int id, string productName, string productDescription, float price);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProductDTO>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();
}

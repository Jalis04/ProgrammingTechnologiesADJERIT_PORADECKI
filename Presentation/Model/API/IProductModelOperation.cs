using System.Collections.Generic;
using System.Threading.Tasks;
using Presentation.Model.Implementation;
using Service.API;

namespace Presentation.Model.API;

public interface IProductModelOperation
{
    static IProductModelOperation CreateModelOperation(IProductCRUD? productCrud = null)
    {
        return new ProductModelOperation(productCrud ?? IProductCRUD.CreateProductCRUD());
    }

    Task AddProductAsync(int id, string name, string description, float price);

    Task<IProductModel> GetProductAsync(int id);

    Task UpdateProductAsync(int id, string name, string description, float price);

    Task DeleteProductAsync(int id);

    Task<Dictionary<int, IProductModel>> GetAllProductsAsync();

    Task<int> GetProductsCountAsync();
}

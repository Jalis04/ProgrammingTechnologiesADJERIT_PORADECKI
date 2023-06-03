using Presentation.Model.API;
using Service.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation;

internal class ProductModelOperation : IProductModelOperation
{
    private IProductCRUD _productCRUD;

    public ProductModelOperation(IProductCRUD? productCrud = null)
    {
        this._productCRUD = productCrud ?? IProductCRUD.CreateProductCRUD();
    }

    private IProductModel Map(IProductDTO product)
    {
        return new ProductModel(product.Id, product.ProductName, product.ProductDescription, product.Price);
    }

    public async Task AddProductAsync(int id, string name, string description, float price)
    {
        await this._productCRUD.AddProductAsync(id, name, description, price);
    }

    public async Task<IProductModel> GetProductAsync(int id)
    {
        return this.Map(await this._productCRUD.GetProductAsync(id));
    }

    public async Task UpdateProductAsync(int id, string name, string description, float price)
    {
        await this._productCRUD.UpdateProductAsync(id, name, description, price);
    }

    public async Task DeleteProductAsync(int id)
    {
        await this._productCRUD.DeleteProductAsync(id);
    }

    public async Task<Dictionary<int, IProductModel>> GetAllProductsAsync()
    {
        Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

        foreach (IProductDTO product in (await this._productCRUD.GetAllProductsAsync()).Values)
        {
            result.Add(product.Id, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await this._productCRUD.GetProductsCountAsync();
    }
}

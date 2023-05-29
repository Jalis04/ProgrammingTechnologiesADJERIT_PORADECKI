using DataLayer.API;
using Service.API;

namespace Service.Implementation;

internal class ProductCRUD : IProductCRUD
{
    private IDataRepository _repository;

    public ProductCRUD(IDataRepository repository)
    {
        this._repository = repository;
    }

    private IProductDTO Map(IProduct product)
    {
        return new ProductDTO(product.id, product.productName, product.productDescription, product.price);
    }

    public async Task AddProductAsync(int id, string productName, string productDescription, float price)
    {
        await this._repository.AddProductAsync(id, productName, productDescription, price);
    }

    public async Task<IProductDTO> GetProductAsync(int id)
    {
        return this.Map(await this._repository.GetProductAsync(id));
    }

    public async Task UpdateProductAsync(int id, string productName, string productDescription, float price)
    {
        await this._repository.UpdateProductAsync(id, productName, productDescription, price);
    }

    public async Task DeleteProductAsync(int id)
    {
        await this._repository.DeleteProductAsync(id);
    }

    public async Task<Dictionary<int, IProductDTO>> GetAllProductsAsync()
    {
        Dictionary<int, IProductDTO> result = new Dictionary<int, IProductDTO>();

        foreach (IProduct product in (await this._repository.GetAllProductsAsync()).Values)
        {
            result.Add(product.id, this.Map(product));
        }

        return result;
    }

    public async Task<int> GetProductsCountAsync()
    {
        return await this._repository.GetProductsCountAsync();
    }
}

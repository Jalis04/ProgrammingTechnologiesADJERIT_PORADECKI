using DataLayer.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestProductCRUD : IProductCRUD
    {
        private readonly TestDataRepository _repository = new TestDataRepository();

        public TestProductCRUD()
        {
        }

        public async Task AddProductAsync(int id, string productName, string productDescription, float price)
        {
            await this._repository.AddProductAsync(id, productName, productDescription, price);
        }

        public async Task<IProductDTO> GetProductAsync(int id)
        {
            return await this._repository.GetProductAsync(id);
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
                result.Add(product.id, (IProductDTO)product);
            }

            return result;
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await this._repository.GetProductsCountAsync();
        }
    }
}

using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class MockProductCRUD : IProductModelOperation
    {
        private readonly MockDataRepository _repository = new MockDataRepository();

        public MockProductCRUD()
        {
        }

        public async Task AddProductAsync(int id, string productName, string productDescription, float price)
        {
            await this._repository.AddProductAsync(id, productName, productDescription, price);
        }

        public async Task<IProductModel> GetProductAsync(int id)
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

        public async Task<Dictionary<int, IProductModel>> GetAllProductsAsync()
        {
            Dictionary<int, IProductModel> result = new Dictionary<int, IProductModel>();

            foreach (IProductModel product in (await this._repository.GetAllProductsAsync()).Values)
            {
                result.Add(product.Id, (IProductModel)product);
            }

            return result;
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await this._repository.GetProductsCountAsync();
        }
    }
}

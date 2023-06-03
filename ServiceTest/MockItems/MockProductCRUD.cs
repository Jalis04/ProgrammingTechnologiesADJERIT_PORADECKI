using Service.API;

namespace ServiceTest.MockItems
{
    internal class MockProductCRUD : IProductCRUD
    {
        private MockDataRepository _dataRepository = new MockDataRepository();

        public async Task AddProductAsync(int id, string productName, string productDescription, float price)
        {
            await _dataRepository.AddProductAsync(id, productName, productDescription, price);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _dataRepository.DeleteProductAsync(id);
        }

        public async Task<Dictionary<int, IProductDTO>> GetAllProductsAsync()
        {
            return await _dataRepository.GetAllProductsAsync();
        }

        public async Task<IProductDTO> GetProductAsync(int id)
        {
            return await _dataRepository.GetProductAsync(id);
        }

        public async Task<int> GetProductsCountAsync()
        {
            return await _dataRepository.GetProductsCountAsync();
        }

        public async Task UpdateProductAsync(int id, string productName, string productDescription, float price)
        {
            await _dataRepository.UpdateProductAsync(id, productName, productDescription, price);
        }
    }
}

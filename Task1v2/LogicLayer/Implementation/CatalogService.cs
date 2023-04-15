using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;
using Task1v2.LogicLayer.API;

namespace Task1v2.LogicLayer.Implementation
{
    public class CatalogService
    {
        private readonly ICatalogRepository _catalogRepository;

        public CatalogService(ICatalogRepository catalogRepository)
        {
            _catalogRepository = catalogRepository;
        }

        public void AddGood(Product good)
        {
            // Add the good to the catalog
            _catalogRepository.Add(good);
        }

        public void UpdateGood(Product good)
        {
            // Update the good in the catalog
            _catalogRepository.Update(good);
        }

        public void DeleteGood(string goodId)
        {
            // Remove the good from the catalog
            _catalogRepository.Delete(goodId);
        }

        public List<Product> GetAllGoods()
        {
            // Get all goods from the catalog
            return _catalogRepository.GetAll();
        }

        public Product GetGoodById(string goodId)
        {
            // Get a specific good from the catalog
            return _catalogRepository.GetById(goodId);
        }
    }
}

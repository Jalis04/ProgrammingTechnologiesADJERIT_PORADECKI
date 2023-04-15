using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;
using Task1v2.LogicLayer.API;
using Task1v2.DataLayer.API;

namespace Task1v2.LogicLayer.Implementation
{
    public class CatalogRepository : ICatalogRepository
    {
        private readonly Dictionary<string, Product> _catalog;

        public CatalogRepository()
        {
            // Initialize the catalog with some sample data
            _catalog = new Dictionary<string, Product>
        {
            { "coffee1", new Product { Id = "coffee1", Name = "Dark Roast", Price = 3.5 } },
            { "coffee2", new Product { Id = "coffee2", Name = "Latte", Price = 4.9 } }
        };
        }

        public void Add(Product good)
        {
            // Add the good to the catalog
            _catalog.Add(good.Id, good);
        }

        public void Update(Product good)
        {
            // Find the good by ID
            Product existingGood = GetById(good.Id);

            // Update the good's properties
            existingGood.Name = good.Name;
            existingGood.Price = good.Price;
        }

        public void Delete(string goodId)
        {
            // Remove the good from the catalog
            _catalog.Remove(goodId);
        }

        public List<Product> GetAll()
        {
            // Return a copy of the catalog
            return new List<Product>(_catalog.Values);
        }

        public Product GetById(string goodId)
        {
            // Find the good by ID
            Product existingGood;
            if (!_catalog.TryGetValue(goodId, out existingGood))
            {
                throw new ArgumentException("Product not found");
            }

            return existingGood;
        }
    }
}

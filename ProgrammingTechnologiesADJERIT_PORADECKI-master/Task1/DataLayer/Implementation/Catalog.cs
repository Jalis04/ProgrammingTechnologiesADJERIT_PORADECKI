using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Catalog : ICatalog
    {
        private readonly List<Product> _products;

        public Catalog()
        {
            _products = new List<Product>();
        }

        public IEnumerable<Product> GetProducts()
        {
            return _products;
        }

        public Product GetProductById(int id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            product.Id = _products.Count + 1;
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var index = _products.FindIndex(p => p.Id == product.Id);
            if (index != -1)
            {
                _products[index] = product;
            }
        }

        public void RemoveProduct(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product != null)
            {
                _products.Remove(product);
            }
        }
    }

}

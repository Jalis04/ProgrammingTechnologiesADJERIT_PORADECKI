using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class Catalog : ICatalog
    {
        private readonly List<Product> _products;

        public Catalog()
        {
            _products = new List<Product>();
        }

        //-----------------------
        public IEnumerable<Product> GetAllProducts()
        {
            return _products;
        }

        public Product GetProductById(string id)
        {
            return _products.FirstOrDefault(p => p.Id == id);
        }

        public void AddProduct(Product product)
        {
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.Id);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                //existingProduct.Description = product.Description;
                existingProduct.Price = product.Price;
            }
        }

        public void DeleteProduct(Product product)
        {
            _products.Remove(product);
        }
    }

}

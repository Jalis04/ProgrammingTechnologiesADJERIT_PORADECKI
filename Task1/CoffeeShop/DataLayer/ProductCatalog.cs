using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DataLayer
{
    public class ProductCatalog
    {
        private List<Product> products;

        public ProductCatalog()
        {
            products = new List<Product>();
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            products.Remove(product);
        }

        // Other methods for manipulating the product catalog

    }
}

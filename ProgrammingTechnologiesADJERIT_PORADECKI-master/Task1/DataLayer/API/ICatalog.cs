using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface ICatalog
    {
        IEnumerable<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }
}

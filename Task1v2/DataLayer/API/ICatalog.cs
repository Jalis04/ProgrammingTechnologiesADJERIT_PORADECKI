using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.DataLayer.API
{
    public interface ICatalog
    {
        IEnumerable<Product> GetAllProducts();
        Product GetProductById(string id);
        void AddProduct(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
    }
}

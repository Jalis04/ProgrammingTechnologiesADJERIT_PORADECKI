using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.LogicLayer.API
{
    public interface ICatalogRepository
    {
        void Add(Product good);
        void Update(Product good);
        void Delete(string goodId);
        List<Product> GetAll();
        Product GetById(string goodId);
    }
}

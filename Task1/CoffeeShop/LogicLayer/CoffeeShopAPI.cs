using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoffeeShop.DataLayer;

namespace CoffeeShop.LogicLayer
{
    public class CoffeeShopAPI
    {
        private CoffeeShopLogic logic;
        public CoffeeShopAPI()
        {
            logic = new CoffeeShopLogic();
        }
        public void AddProduct(Product product)
        {
            logic.AddProduct(product);
        }
        public void RemoveProduct(Product product)
        {
            logic.RemoveProduct(product);
        }
        public void RegisterInvoice(Invoice invoice)
        {
            logic.RegisterInvoice(invoice);
        }
        public void UpdateLibraryStatus(string status)
        {
            logic.UpdateLibraryStatus(status);
        }
        public void UpdateInventoryStatus(string status)
        {
            logic.UpdateInventoryStatus(status);
        }

        public int GetProductCount()
        {
            throw new NotImplementedException();
        }

        public Product GetProductByName(string v)
        {
            throw new NotImplementedException();
        }
        // Other methods for handling shop operations
    }
}

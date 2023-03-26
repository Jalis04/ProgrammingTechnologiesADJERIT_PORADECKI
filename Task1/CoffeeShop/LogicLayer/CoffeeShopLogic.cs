using CoffeeShop.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.LogicLayer
{
    public class CoffeeShopLogic
    {
        private ProductCatalog catalog;
        private List<Invoice> invoices;
        private string libraryStatus;
        private string inventoryStatus;

        public CoffeeShopLogic()
        {
            catalog = new ProductCatalog();
            invoices = new List<Invoice>();
            libraryStatus = "Closed"; //example statuses
            inventoryStatus = "Closed";
        }

        public void AddProduct(Product product)
        {
            catalog.AddProduct(product);
        }

        public void RemoveProduct(Product product)
        {
            catalog.RemoveProduct(product);
        }

        public void RegisterInvoice(Invoice invoice)
        {
            invoices.Add(invoice);
        }

        public void UpdateLibraryStatus(string status)
        {
            libraryStatus = status;
        }

        public void UpdateInventoryStatus(string status)
        {
            inventoryStatus = status;
        }

        // Other methods for handling shop operations
    }
}

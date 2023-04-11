using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer.Implementation
{
    public class CoffeeShopLogic
    {
        private Catalog catalog;
        private List<Invoice> invoices;
        private string coffeeShopStatus;
        private string inventoryStatus;

        public CoffeeShopLogic()
        {
            catalog = new Catalog();
            invoices = new List<Invoice>();
            coffeeShopStatus = "Closed"; //example statuses
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
            coffeeShopStatus = status;
        }

        public void UpdateInventoryStatus(string status)
        {
            inventoryStatus = status;
        }

        // Other methods for handling shop operations
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;

namespace Task1f.DataLayer.Implementation
{
    internal class Product : IProduct
    {
        public string id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }

        public Product(string id, string productName, string productDescription)
        {
            this.id = id;
            this.productName = productName;
            this.productDescription = productDescription;
        }
    }
}

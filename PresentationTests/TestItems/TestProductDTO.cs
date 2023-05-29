using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestProductDTO : IProductDTO
    {
        public int id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public float price { get; set; }

        public TestProductDTO(int id, string productName, string productDescription, float price)
        {
            this.id = id;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;
        }
    }
}

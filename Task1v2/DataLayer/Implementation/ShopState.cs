using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;

namespace Task1v2.DataLayer.Implementation
{
    public class ShopState
    {
        public int Id { get; set; }
        public ShopStatus Status { get; set; }
        public IEnumerable<Product> Products { get; set; }
    }
}

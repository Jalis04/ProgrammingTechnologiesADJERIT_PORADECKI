using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1f.DataLayer.API
{
    public interface IProduct
    {
        string id { get; set; }
        string productName { get; set; }
        string productDescription { get; set; }
    }

}

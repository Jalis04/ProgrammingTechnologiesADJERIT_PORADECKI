using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IProduct
    {   
        //represents drinks in the coffee shop
        string Id { get; }
        string Name { get; }
        string Description { get; }
        double Price { get; }
        int Quantity { get; set; }
    }

}

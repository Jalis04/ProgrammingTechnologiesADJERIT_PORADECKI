using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Product : IProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; }
        public double Price { get; set; }
        public int Quantity { get; set; }

        public Product(string id, string name, string description, double price, int quantity)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Quantity = quantity;
        }
    }

}
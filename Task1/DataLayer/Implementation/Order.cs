using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class Order : IOrder
    {
        public int Id { get; }
        public IUser User { get; }
        public IProduct Product { get; }
        public DateTime CreatedAt { get; }
        public double TotalPrice { get; }

        public Order(int id, IUser user, IProduct product)
        {
            Id = id;
            User = user;
            Product = product;
            CreatedAt = DateTime.Now;
            TotalPrice = product.Price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeShop.DataLayer
{
    public class Product
    {
        private string _name;
        private string _description;
        private double _price;
        //other properties of product
        public Product(string name, string description, double price)
        {
            _name = name;
            _description = description;
            _price = price;
        }
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        public double Price
        {
            get { return _price; }
            set { _price = value; }
        }
    }
}

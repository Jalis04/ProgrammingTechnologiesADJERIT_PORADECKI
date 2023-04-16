﻿using DataLayer.API;

namespace   DataLayer.Implementation
{
    public class Product : IProduct
    {
        public string id { get; set; }
        public string productName { get; set; }
        public string productDescription { get; set; }
        public float price { get; set; }


        public Product(string id, string productName, string productDescription, float price)
        {
            this.id = id;
            this.productName = productName;
            this.productDescription = productDescription;
            this.price = price;

        }
    }
}
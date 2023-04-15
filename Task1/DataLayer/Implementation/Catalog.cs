using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace DataLayer.Implementation
{
    internal class Catalog : ICatalog
    {
        public Catalog(string id, string name, string desc)
        {
            ProductName = name;
            Description = desc;
            Id = id;
        }

        public string ProductName { get; set; }

        public string Description { get; set; }

        public string Id { get; set; }
    }

}

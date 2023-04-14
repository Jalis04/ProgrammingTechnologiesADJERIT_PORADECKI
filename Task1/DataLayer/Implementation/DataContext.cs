using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.API;

namespace DataLayer.Implementation
{
    public class DataContext : IDataContext
    {
        public ICatalog Catalog { get; }
        public IList<Client> Clients { get; }
        public IList<Invoice> Invoices { get; }
        public string ProcessState { get; set; }

        public DataContext()
        {
            Catalog = new Catalog();
            Clients = new List<Client>();
            Invoices = new List<Invoice>();
            ProcessState = "Open";
        }
    }

}

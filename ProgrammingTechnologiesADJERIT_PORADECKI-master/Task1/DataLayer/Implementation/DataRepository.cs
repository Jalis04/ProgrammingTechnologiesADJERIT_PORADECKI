using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace DataLayer.Implementation
{
    public class DataRepository : IDataRepository
    {
        private readonly ICatalog _catalog;
        private readonly IList<Client> _clients;
        private readonly IList<Invoice> _invoices;
        private string _processState;

        public DataRepository(ICatalog catalog, IList<Client> clients, IList<Invoice> invoices, string processState)
        {
            _catalog = catalog;
            _clients = clients;
            _invoices = invoices;
            _processState = processState;
        }

        public ICatalog Catalog => _catalog;

        public IList<Client> Clients => _clients;

        public IList<Invoice> Invoices => _invoices;

        public string ProcessState
        {
            get => _processState;
            set => _processState = value;
        }

        public void SaveChanges()
        {   //METHOD NOT NEEDED, JUST EXPERIMENTAL
            // Implementation of saving changes to the data repository
            // Serialize the catalog, clients, invoices, and process state to JSON strings
            string catalogJson = JsonConvert.SerializeObject(Catalog);
            string clientsJson = JsonConvert.SerializeObject(Clients);
            string invoicesJson = JsonConvert.SerializeObject(Invoices);
            string processStateJson = JsonConvert.SerializeObject(ProcessState);

            // Write the JSON strings to a file
            using (StreamWriter file = File.CreateText("data.json"))
            {
                file.WriteLine(catalogJson);
                file.WriteLine(clientsJson);
                file.WriteLine(invoicesJson);
                file.WriteLine(processStateJson);
            }
        }
    }

}

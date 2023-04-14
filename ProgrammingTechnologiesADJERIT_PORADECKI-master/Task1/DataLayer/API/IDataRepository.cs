using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.API
{
    public interface IDataRepository
    {
        ICatalog Catalog { get; }
        IList<Client> Clients { get; }
        IList<Invoice> Invoices { get; }
        string ProcessState { get; set; }

        void SaveChanges();
    }

}

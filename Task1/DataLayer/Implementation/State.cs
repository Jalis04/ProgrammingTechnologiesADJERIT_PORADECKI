using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class State : IState
    {
        private readonly ICatalog catalog;

        public State(string stateId, ICatalog catalog)
        {
            StateId = stateId;
            this.catalog = catalog;
            Available = true;
        }

        public string DrinkId => catalog.Id;
        public string StateId { get; set; }

        public bool Available { get; set; }
    }

}

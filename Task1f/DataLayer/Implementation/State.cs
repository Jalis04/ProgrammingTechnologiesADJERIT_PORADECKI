using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;

namespace Task1f.DataLayer.Implementation
{
    internal class State : IState
    {
        private readonly IProduct product;

        public State(string stateId, IProduct product)
        {
            StateId = stateId;
            this.product = product;
            Available = true;
        }

        public string ProductId => product.id;
        public string StateId { get; set; }

        public bool Available { get; set; }
    }
}

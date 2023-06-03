using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.MockItems
{
    internal class MockStateDTO : IStateModel
    {
        public int ProductId { get; set; }
        public int StateId { get; set; }

        public bool Available { get; set; }

        public MockStateDTO(int id, int productId, bool available)
        {
            this.StateId = id;
            this.ProductId = productId;
            this.Available = available;
        }
    }
}

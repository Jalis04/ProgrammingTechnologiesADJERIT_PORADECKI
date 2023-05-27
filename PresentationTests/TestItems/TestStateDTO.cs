using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestStateDTO : IStateDTO
    {
        public int productId { get; set; }
        public int stateId { get; set; }

        public bool available { get; set; }

        public TestStateDTO(int id, int productId, bool available)
        {
            this.stateId = id;
            this.productId = productId;
            this.available = available;
        }
    }
}

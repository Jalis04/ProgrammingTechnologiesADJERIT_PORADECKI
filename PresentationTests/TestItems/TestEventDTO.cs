using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class TestEventDTO : IEventDTO
    {
        public int eventId { get; set; }
        public int stateId { get; set; }
        public int userId { get; set; }
        public DateTime eventDate { get; }
        public string type { get; set; }

        public TestEventDTO(int id, int stateId, int userId, string type)
        {
            this.eventId = id;
            this.stateId = stateId;
            this.userId = userId;
            this.eventDate = DateTime.Now;
            this.type = type;
        }
    }
}

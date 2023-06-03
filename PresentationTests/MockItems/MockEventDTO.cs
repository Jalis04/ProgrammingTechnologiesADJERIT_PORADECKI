using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationTests.TestItems
{
    internal class MockEventDTO : IEventModel
    {
        public int Id { get; set; }
        public int StateId { get; set; }
        public int UserId { get; set; }
        public DateTime EventDate { get; set; }
        public string Type { get; set; }

        public MockEventDTO(int id, int stateId, int userId, string type)
        {
            this.Id = id;
            this.StateId = stateId;
            this.UserId = userId;
            this.EventDate = DateTime.Now;
            this.Type = type;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    public class State : IState
    {
        public string Id { get; }
        public string Name { get; set; }
        public string Description { get; set; }

        public State(string id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }
    }

}

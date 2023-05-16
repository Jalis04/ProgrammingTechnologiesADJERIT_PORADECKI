using DataLayer.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class StateDTO : IState
    {
        public string productId { get; init; }
        public string stateId { get; set; }
        public bool available { get; set; }
    }
}

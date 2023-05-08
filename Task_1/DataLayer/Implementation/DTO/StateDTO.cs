using DataLayer.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class StateDTO
    {
        string productId { get; init; }
        string stateId { get; set; }
        bool available { get; set; }
    }
}

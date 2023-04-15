using DataLayer.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implementation
{
    internal class VoidFIll : IFill
    {
        public override void Fill(IDataRepository dataRepository)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1f.DataLayer.API;

namespace Task1f.DataLayer.Implementation
{
    internal class EmptyFill : IFill
    {
        public override void Fill(IDataRepository dataRepository)
        {
        }
    }
}

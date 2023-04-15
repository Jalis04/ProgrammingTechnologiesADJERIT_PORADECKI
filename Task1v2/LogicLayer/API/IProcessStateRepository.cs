using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.API;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.LogicLayer.API
{
    public interface IProcessStateRepository
    {
        ShopState GetCurrentState();
        void SetCurrentState(ShopState state);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1v2.DataLayer.Implementation;

namespace Task1v2.DataLayer.API
{
    public interface IShopStateManager
    {
        ShopState GetCurrentState();
        void OpenShop();
        void CloseShop();
    }
}

using Delegates_Practice.CheckoutAssets;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice
{
    internal class Shopping
    {

        public void start(ItemsManager inventoryManager, DisplayHandler displayHandler, Cart cart)
        {

            displayHandler.DisplayShopping(cart, inventoryManager);
        }
    }
}

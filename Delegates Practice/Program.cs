
using Delegates_Practice.CheckoutAssets;
using Delegates_Practice.PaymentStrategy;
using System.Xml.Schema;
using System.Diagnostics;


namespace Delegates_Practice
{
    class Program
    {
        static bool isDebug;
        static void Main(string[] args)
        {
            DisplayHandler displayHandler = new DisplayHandler();
            ItemsManager inventoryManager = new ItemsManager();
            Cart shoppingCart = new Cart();
            bool isDebug = displayHandler.DisplayDebug();




            Shopping shopping = new Shopping();
            shopping.start(inventoryManager, displayHandler, shoppingCart);
            Checkout checkout = new Checkout();
            checkout.start(inventoryManager, shoppingCart, displayHandler, isDebug);
        }


    }
}



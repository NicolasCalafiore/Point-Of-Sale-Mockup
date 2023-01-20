
using Delegates_Practice.CheckoutAssets;
using Delegates_Practice.PaymentStrategy;
using System.Xml.Schema;
using System.Diagnostics;
using Delegates_Practice.CheckoutAssets.Taxes.Taxes;

namespace Delegates_Practice
{
    class Program
    {
        static bool isDebug;
        static void Main(string[] args)
        {
            DisplayHandler displayHandler = new DisplayHandler();                   // Handles What is Displayed on Console
            ItemsManager inventoryManager = new ItemsManager();                     // Handles what items are abled to be purchased (add custom items here)
            Cart shoppingCart = new Cart();                                         // Handles what the user chooses to purchase (handles price, tax status, etc.)

           


            bool isDebug = displayHandler.DisplayDebug();                           // Enables Debug Outputs
            Shopping shopping = new Shopping();                                     // Creates new shopping simulation
            shopping.start(inventoryManager, displayHandler, shoppingCart);         // Starts new shopping simulation (loop until head to checkout)
            Checkout checkout = new Checkout();                                     // Starts new checkout simulation
            checkout.start(inventoryManager, shoppingCart, displayHandler, isDebug);// Starts the checkout simulation (Payment Information & Processing)
        }

        
    }
}



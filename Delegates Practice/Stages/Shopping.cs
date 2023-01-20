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

        public void start(ItemsManager inventoryManager, DisplayHandler displayHandler, Cart shoppingCart)
        {

            String input = string.Empty;
            while (true)
            {
                displayHandler.DisplayShoppingSelection(shoppingCart, inventoryManager);                            // Displays List of Selection (Items)
                input = Console.ReadLine();                                                                         // Gets the items index




                if (input == "X" || input == "x") break;                                                                            // Exits the shopping segment
                for (int i = 0; i < 40; i++) Console.WriteLine("\n");                                               // Spacing Between Selection Menus
                try { shoppingCart.AddItemToCart(inventoryManager.getSelectedItem(Int32.Parse(input))); }           // If a valid item is selected the ID is passed to match the Index
                catch (Exception) { Console.WriteLine("Invalid Selection"); }
                
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");



        }

    }
}

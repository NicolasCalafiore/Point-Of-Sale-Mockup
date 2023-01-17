using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.Assets
{
    internal class MenuSelection
    {
        ItemsManager itemManager;
        Cart cart;
        public MenuSelection(ItemsManager itemManager, Cart cart) {
            this.itemManager = itemManager;
            this.cart = cart;
        }


        public void DisplayShopping()
        {
            String input = string.Empty;
            while (true)
            {

            Console.WriteLine("Select Items to Add to Cart          Total Items: {0}   Untaxed Price: ${1}",
                cart.getItemCount(), cart.getAccumulatedPrice());

            int selectionID = 1;
            foreach(Items i in itemManager.getItems()){
                Console.WriteLine("{3} {0} {2}{1} ", i.getDisplayTitle().PadRight(20), i.getDisplayPrice(), " $", 
                    "[" + selectionID++ + "]");
            }
                Console.WriteLine("\n");
                Console.WriteLine("[X] Head to Checkout");

                input = Console.ReadLine();
                if (input == "X") break;
                try { cart.AddItemToCart(itemManager.getSelectedItem(Int32.Parse(input))); }
                catch (Exception) { Console.WriteLine("Invalid Selection"); }
                for (int i = 0; i < 40; i++) Console.WriteLine("\n");                            // Spacing Between Selection
            }

        }

        public void DisplayPayment()
        {
            Console.WriteLine("For Tax Purposes Select The State You Are Located In");
            Console.WriteLine("Select your state");
            Console.WriteLine("(1) FL");
            Console.WriteLine("(2) CT");
            Console.WriteLine("(3) NY");
            Console.WriteLine("(4) CA");
            Console.WriteLine("(5) MT");
            Console.WriteLine("(6) NV");
            Console.WriteLine("(7) KY");
            Console.WriteLine("(8) VT");
            Console.WriteLine("(9) MS");
            Console.WriteLine("(10) NM");

        }
    }
}

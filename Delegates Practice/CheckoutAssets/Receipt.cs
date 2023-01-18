using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.CheckoutAssets
{
    internal class Receipt
    {
        Cart shoppingCart;
        double taxAmount;
        List<string> paymentDetails;
        bool DebugModeEnabled;
        public Receipt(Cart shoppingCart, double taxAmount, List<string> paymentDetails, bool DebugModeEnabled) {
            this.shoppingCart = shoppingCart;
            this.taxAmount = taxAmount;
            this.paymentDetails = paymentDetails;
            this.DebugModeEnabled = DebugModeEnabled;
        }

        public void PrintReceipt()
        {
            for (int i = 0; i <= 10; i++) Console.WriteLine("\n");

            Console.WriteLine("RECEIPT");
            Console.WriteLine("-----------------------------------------");
            foreach (Items i in shoppingCart.ItemsGetItems())
            {
                Console.Write("{0}             ${1}", i.getDisplayTitle().PadRight(20), i.getDisplayPriceString());
                if (DebugModeEnabled) Console.WriteLine("          DEBUG ITEM TAX STATUS: " + i.isTaxableItem()); else { Console.WriteLine(""); }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Subtotal: ${0}", shoppingCart.getAccumulatedPrice());
            Console.WriteLine("Sales Tax: ${0}", taxAmount.ToString("0.00"));
            Console.WriteLine("Total: ${0}", (shoppingCart.getAccumulatedPrice() + taxAmount).ToString("0.00"));  //Entire purchase price + taxAmount
            Console.WriteLine("");
            Console.WriteLine("*****************************************");
            Console.WriteLine("*            CHARGE INFORMATION         *");
            Console.WriteLine("*****************************************");
            for (int i = 0; i < paymentDetails.Count; i++)
            {
                Console.WriteLine(paymentDetails[i] + " " + paymentDetails[i+1]);
                i++;
            }

            Console.WriteLine("\n");
        }
    }
}

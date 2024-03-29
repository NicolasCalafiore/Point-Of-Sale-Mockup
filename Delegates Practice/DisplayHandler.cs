﻿using Microsoft.VisualBasic.FileIO;
using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.CheckoutAssets;
using System.Diagnostics;
using Delegates_Practice.PaymentAssets.PaymentObjects;

namespace Delegates_Practice
{
    internal class DisplayHandler
    {
        //ItemsManager inventoryManager;
        //Cart shoppingCart;
        //public static bool debugModeEnabled = false;


        public DisplayHandler() {
            //this.inventoryManager = itemManager;
            //this.shoppingCart = cart;
        }

        public bool DisplayDebug()
        { 
            Console.WriteLine("Debug Y/N?");
            String isDebugChar = Console.ReadLine();
            if (isDebugChar == "Y") { /*debugModeEnabled = true;*/  return true;  }
            else return false;
        }

        public void DisplayShoppingSelection(Cart shoppingCart, ItemsManager inventoryManager)
        {
            Console.WriteLine("Select Items to Add to Cart          Total Items: {0}   Untaxed Price: ${1}",        // Title
               shoppingCart.getItemCount(), shoppingCart.getAccumulatedPrice());

            int selectionID = 1;
            foreach (Items i in inventoryManager.getItems())
            {                                                             // Loads the List of the variety of items and iterates through each
                Console.WriteLine("{0} {1} {2}{3} ", "[" + selectionID++ + "]", i.getDisplayTitle().PadRight(20), " $", i.getDisplayPriceString());    // ID - Title - Price
            }
            Console.WriteLine("\n");
            Console.WriteLine("[X] Head to Checkout");
        }

        public string DisplayClientState()
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
            return Console.ReadLine();
        }

        public void DisplayPaymentMethod(IPaymentStrategy[] paymentProcessingRegistry)  // Forms of Payment
        {



            foreach (IPaymentStrategy i in paymentProcessingRegistry)
            {

                Console.WriteLine("({0}): {1}", i.getTenderID(), i.getTenderName());
            }
        }               


                                                          

        public void DisplayPaymentDetails(IPaymentStrategy paymentInstructions)
        {
            paymentInstructions.GetPaymentDetails();
        }

        public void PrintReceipt(Cart shoppingCart, double taxAmount, List<string> paymentDetails, bool debugModeEnabled)
        {

            for (int i = 0; i <= 10; i++) Console.WriteLine("\n");

            Console.WriteLine("RECEIPT");
            Console.WriteLine("-----------------------------------------");
            foreach (Items i in shoppingCart.ItemsGetItems())
            {
                Console.Write("{0}             ${1}", i.getDisplayTitle().PadRight(20), i.getDisplayPriceString());
                if (debugModeEnabled) Console.WriteLine("          DEBUG ITEM TAX STATUS: " + i.isTaxableItem()); else { Console.WriteLine(""); }
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

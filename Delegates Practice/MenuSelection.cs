using Microsoft.VisualBasic.FileIO;
using Delegates_Practice;
using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.CheckoutAssets;
using System.Diagnostics;

namespace Delegates_Practice
{
    internal class MenuSelection
    {
        ItemsManager itemManager;
        Cart cart;
        public static bool isDebug = false;


        public MenuSelection(ItemsManager itemManager, Cart cart) {
            this.itemManager = itemManager;
            this.cart = cart;
        }

        public void DisplayDebug()
        {

            Console.WriteLine("Debug Y/N?");
            String isDebugChar = Console.ReadLine();
            if (isDebugChar == "Y") isDebug = true;
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
                    Console.WriteLine("{0} {1} {2}{3} ", "[" + selectionID++ + "]", i.getDisplayTitle().PadRight(20),  " $", i.getDisplayPriceString());
                }
                    Console.WriteLine("\n");
                    Console.WriteLine("[X] Head to Checkout");

                    input = Console.ReadLine();
                    if (input == "X") break;
                    try { cart.AddItemToCart(itemManager.getSelectedItem(Int32.Parse(input))); }
                    catch (Exception) { Console.WriteLine("Invalid Selection"); }
                    for (int i = 0; i < 40; i++) Console.WriteLine("\n");                            // Spacing Between Selection
            }
            Console.WriteLine("\n");
            Console.WriteLine("\n");
        }

        public void DisplayClientState()
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

        public void DisplayPaymentMethod()
        {
            Console.WriteLine("Choose Payment Method");
            Console.WriteLine("1. Credit Card");
            Console.WriteLine("2. PayPal");
            Console.WriteLine("3. Gift Card");
        }

        public Tuple<IPaymentStrategy, IPaymentMethodStrategy> DisplayPaymentCollections(int option, IPaymentMethodStrategy _payment, IPaymentStrategy _strategy)
        {

            switch (option)                                     //Depending on what was chosen at Menu Selection (1-Credit 2-PayPal 3-Gift)
            {
                case 1: _strategy = new PayWithCreditStrategy(); _payment = new PaymentTypes.CreditCardDetails(); break;    //Assigns Payment Process interfance to CreditCard
                case 2: _strategy = new PayWithPayPal(); _payment = new PaymentTypes.PayPalDetails(); break;                //Assigns Payment Process interfance to PayPal
                case 3: _strategy = new PayWithGiftCard(); _payment = new PaymentTypes.GiftCardDetails(); break;            //Assigns Payment Process interfance to Gift
            }
            Tuple<IPaymentStrategy, IPaymentMethodStrategy> My_Tuple2 = new Tuple<IPaymentStrategy, IPaymentMethodStrategy>(_strategy, _payment);

            return My_Tuple2;
        }

        public void DisplayPaymentDetails(IPaymentMethodStrategy _payment)
        {
            _payment.GetPaymentDetails();
        }

        public void PrintReceipt(Cart cart, double taxes, List<string> details)
        {

            for (int i = 0; i <= 10; i++) Console.WriteLine("\n");

            Console.WriteLine("RECEIPT");
            Console.WriteLine("-----------------------------------------");
            foreach (Items i in cart.ItemsGetItems())
            {
                Console.Write("{0}             ${1}", i.getDisplayTitle().PadRight(20), i.getDisplayPriceString());
                if (isDebug) Console.WriteLine("          DEBUG ITEM TAX STATUS: " + i.isTaxableItem()); else { Console.WriteLine(""); }
            }
            Console.WriteLine("\n");
            Console.WriteLine("Subtotal: ${0}", cart.getAccumulatedPrice());
            Console.WriteLine("Sales Tax: ${0}", taxes.ToString("0.00"));
            Console.WriteLine("Total: ${0}", (cart.getAccumulatedPrice() + taxes).ToString("0.00"));  //Entire purchase price + taxes
            Console.WriteLine("");
            Console.WriteLine("*****************************************");
            Console.WriteLine("*            CHARGE INFORMATION         *");
            Console.WriteLine("*****************************************");
            for (int i = 0; i < details.Count; i++)
            {
                Console.WriteLine(details[i] + " " + details[i+1]);    
                i++;
            }

            Console.WriteLine("\n");

        }
    }


}

using Delegates_Practice.CheckoutAssets;
using Delegates_Practice.CheckoutAssets.Taxes;
using Delegates_Practice.PaymentAssets.PaymentObjects;
using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice
{
    class Checkout
    {
        IPaymentStrategy _paymentProcessingStrategy;
        String userInput;

        IPaymentStrategy[] paymentProcessingRegistry = new IPaymentStrategy[] { new PayWithCreditStrategy(),
                new PayWithGiftCard(), new PayWithPayPal(), new PayWithCash()};



        public Checkout()
        {
        
        }
        public void start(ItemsManager itemManager, Cart shoppingCart, DisplayHandler displayHandler, bool isDebug)
        {

           
            userInput = displayHandler.DisplayClientState();
            Func<double, bool, double> taxDelegate = TaxHandler.AssignTaxDelegate(userInput);
            for (int i = 0; i < 40; i++) Console.WriteLine("\n");
            double taxes = TaxHandler.CalculateTaxes(shoppingCart, taxDelegate, isDebug);
            List<string> details = processPayment(Int32.Parse(userInput), shoppingCart.getAccumulatedPrice() + taxes, displayHandler);
            Receipt receipt = new Receipt(shoppingCart, taxes, details, isDebug);
            receipt.PrintReceipt();
            string a = Console.ReadLine();
        }
        public List<string> processPayment(int option, double total, DisplayHandler menu)
        {
            menu.DisplayPaymentMethod(paymentProcessingRegistry);                                // Displays form of tender (Gift Card - Credit Card ?)
            userInput = Console.ReadLine();
            
            IPaymentStrategy paymentInstructions = AssignPaymentStrategy(Int32.Parse(userInput), _paymentProcessingStrategy, paymentProcessingRegistry);
            // Dependant on type of tender the Strategy for payment paymentDetails & payment processing is returned

                                                 
            menu.DisplayPaymentDetails(paymentInstructions);                                       // Displays Tender Specific information requests
            List<string> details = paymentInstructions.RetrievePaymentDetails(total);                   // Retrieves Tender Information
            paymentInstructions.Pay(total);                                             // Tender-Specific Proccesing method
            return details;                                                             // Details are returned for the receipt
        }
        public static IPaymentStrategy AssignPaymentStrategy(int option,  IPaymentStrategy _paymentProcessingStrategy, IPaymentStrategy[] paymentProcessingRegistry)
        {

            foreach(IPaymentStrategy i in paymentProcessingRegistry)
            {
                if (i.getTenderID() == option) { _paymentProcessingStrategy = i; break; } 
            }

            return _paymentProcessingStrategy;
        }
    }
}

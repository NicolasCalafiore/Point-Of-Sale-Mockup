
using Delegates_Practice.CheckoutAssets;
using Delegates_Practice;
using Delegates_Practice.PaymentStrategy;
using System.Xml.Schema;
using System.Diagnostics;

namespace Delegates_Practice
{
    class Program
    {
        static IPaymentMethodStrategy _payment;                         // Interface for all objects representing forms of payment (Gift Card, Credit Card, PayPal)
        static IPaymentStrategy _strategy;                              // Interface for all objects representing forms of payment (Gift Card, Credit Card, PayPal)
        static String input;

        static void Main(string[] args)
        {

            ItemsManager itemManager = new ItemsManager();              // Manages the Items Objects
            Cart cart = new Cart();                                     // Stores Cart Information
            MenuSelection menu = new MenuSelection(itemManager, cart);  // Manages what is displayed


            menu.DisplayDebug();                                        //Enables/Disables Debug

            menu.DisplayShopping();                                     // User is prompted with selection of Items. Selected Items are added to the cart. Loop until exit.
                                   
            menu.DisplayClientState();                                  // Displays Selection of States to choose from
            input = Console.ReadLine();
            Func<double, double> taxDelegate = Taxes.AssignTaxDelegate(input);          // Assigns the correct delegate to decide which tax policy will be applied dependant on state



            for (int i = 0; i < 40; i++) Console.WriteLine("\n");                       // Padding

            double taxes = Taxes.CalculateTaxes(cart, taxDelegate);                     // Calculates all taxable objects and returns tax amount;
            List<string> details = processPayment(Int32.Parse(input), cart.getAccumulatedPrice() + taxes, menu);        //Processes payment

            menu.PrintReceipt(cart, taxes, details);                    // Prints Receipt

        }


        static List<string> processPayment(int option, double total, MenuSelection menu)
        {

            menu.DisplayPaymentMethod();                                // Displays form of tender (Gift Card - Credit Card ?)
            input = Console.ReadLine();                 

            Tuple<IPaymentStrategy, IPaymentMethodStrategy> paymentInstructions = menu.DisplayPaymentCollections(Int32.Parse(input), _payment, _strategy);
                                                                                        // Dependant on type of tender the Strategy for payment details & payment processing is returned
            _strategy = paymentInstructions.Item1;                                      // Contains Strategy for Processing (Tender-Specific Proccesing method)
            _payment = paymentInstructions.Item2;                                       // Contains Strategy for Display Insructions (What Information is Necessary respective to tender)
            menu.DisplayPaymentDetails(_payment);                                       // Displays Tender Specific information requests
            List<string> details = _payment.RetrievePaymentDetails();                   // Retrieves Tender Information
            _strategy.Pay(total, _payment);                                             // Tender-Specific Proccesing method
            return details;                                                             // Details are returned for the receipt

        }

    }

}



using Delegates_Practice.CheckoutAssets;
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
        IPaymentMethodDisplayStrategy _paymentInformationDisplayStrategy;
        IPaymentStrategy _paymentProcessingStrategy;
        String userInput;     
     
        public Checkout()
        {
        
        }
        public void start(ItemsManager itemManager, Cart shoppingCart, DisplayHandler displayHandler, bool isDebug)
        {
           
            userInput = displayHandler.DisplayClientState();
            Func<double, bool, double> taxDelegate = Taxes.AssignTaxDelegate(userInput);
            for (int i = 0; i < 40; i++) Console.WriteLine("\n");
            double taxes = Taxes.CalculateTaxes(shoppingCart, taxDelegate, isDebug);
            List<string> details = processPayment(Int32.Parse(userInput), shoppingCart.getAccumulatedPrice() + taxes, displayHandler);
            Receipt receipt = new Receipt(shoppingCart, taxes, details, isDebug);
            receipt.PrintReceipt();
            string a = Console.ReadLine();
        }
        public List<string> processPayment(int option, double total, DisplayHandler menu)
        {
            menu.DisplayPaymentMethod();                                // Displays form of tender (Gift Card - Credit Card ?)
            userInput = Console.ReadLine();
            
            Tuple<IPaymentStrategy, IPaymentMethodDisplayStrategy> paymentInstructions = AssignPaymentStrategy(Int32.Parse(userInput), _paymentInformationDisplayStrategy, _paymentProcessingStrategy);
            // Dependant on type of tender the Strategy for payment paymentDetails & payment processing is returned

            _paymentProcessingStrategy = paymentInstructions.Item1;                                      // Contains Strategy for Processing (Tender-Specific Proccesing method)
            _paymentInformationDisplayStrategy = paymentInstructions.Item2;                                       // Contains Strategy for Display Insructions (What Information is Necessary respective to tender)
            menu.DisplayPaymentDetails(_paymentInformationDisplayStrategy);                                       // Displays Tender Specific information requests
            List<string> details = _paymentInformationDisplayStrategy.RetrievePaymentDetails();                   // Retrieves Tender Information
            _paymentProcessingStrategy.Pay(total, _paymentInformationDisplayStrategy);                                             // Tender-Specific Proccesing method
            return details;                                                             // Details are returned for the receipt
        }
        public static Tuple<IPaymentStrategy, IPaymentMethodDisplayStrategy> AssignPaymentStrategy(int option, IPaymentMethodDisplayStrategy _paymentInformationDisplayStrategy, IPaymentStrategy _paymentProcessingStrategy)
        {
            switch (option)
            {
                case 1: _paymentProcessingStrategy = new PayWithCreditStrategy(); _paymentInformationDisplayStrategy = new PaymentTypes.CreditCardDetails(); break;    //Assigns Payment Process interfance to CreditCard
                case 2: _paymentProcessingStrategy = new PayWithPayPal(); _paymentInformationDisplayStrategy = new PaymentTypes.PayPalDetails(); break;                //Assigns Payment Process interfance to PayPal
                case 3: _paymentProcessingStrategy = new PayWithGiftCard(); _paymentInformationDisplayStrategy = new PaymentTypes.GiftCardDetails(); break;            //Assigns Payment Process interfance to Gift
            }
            Tuple<IPaymentStrategy, IPaymentMethodDisplayStrategy> My_Tuple2 = new Tuple<IPaymentStrategy, IPaymentMethodDisplayStrategy>(_paymentProcessingStrategy, _paymentInformationDisplayStrategy);

            return My_Tuple2;
        }
    }
}

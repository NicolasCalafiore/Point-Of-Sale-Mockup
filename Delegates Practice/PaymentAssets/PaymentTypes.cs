using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.PaymentStrategy;

namespace Delegates_Practice.CheckoutAssets
{
    internal class PaymentTypes
    {

        public class CreditCardDetails : IPaymentMethodDisplayStrategy
        {

            string CardNumber;
            string ExpirationDate;
            string SecurityCode;

            public override void GetPaymentDetails()
            {
                Console.WriteLine("Enter Card Number:");
                CardNumber = Console.ReadLine();
                Console.WriteLine("Enter Expiration Date (MM/YY):");
                ExpirationDate = Console.ReadLine();
                Console.WriteLine("Enter Security Code:");
                SecurityCode = Console.ReadLine();
            }
            public override List<string> RetrievePaymentDetails()
            {
                List<string> ret = new List<string>
                {
                    "Card Number:",
                    CardNumber,
                    "ExpirationDate:",
                    ExpirationDate,
                    "ExpirationDate:",
                    SecurityCode
                };
                return ret;

            }

            public string getCardNumber()
            {
                return CardNumber;
            }


        }




        public class GiftCardDetails : IPaymentMethodDisplayStrategy
        {
            public string GiftCardNumber2;

            public override void GetPaymentDetails()
            {
                Console.WriteLine("Enter Gift Card Number:");
                GiftCardNumber2 = Console.ReadLine();

            }

            public override List<string> RetrievePaymentDetails()
            {
                List<string> ret = new List<string>
                {
                    "Gift Card Number:",
                    GiftCardNumber2
                };
                return ret;
            }
        }




        public class PayPalDetails : IPaymentMethodDisplayStrategy
        {
            public string PayPalAddress;
            public string PayPalPass;

            public override void GetPaymentDetails()
            {
                Console.WriteLine("Enter PayPal Address:");
                PayPalAddress = Console.ReadLine();
                Console.WriteLine("Enter PayPal Password:");
                PayPalPass = Console.ReadLine();

            }

            public override List<string> RetrievePaymentDetails()
            {
                List<string> ret = new List<string>
                {
                    "PayPalAddress:",
                    PayPalAddress,
                    "PayPalAddress:",
                    PayPalPass
                };

                return ret;
            }
        }

    }
}

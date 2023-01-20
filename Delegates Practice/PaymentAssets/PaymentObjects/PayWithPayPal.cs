using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.PaymentStrategy;

namespace Delegates_Practice.PaymentAssets.PaymentObjects
{
    internal class PayWithPayPal : IPaymentStrategy
    {
        public string PayPalAddress;
        public string PayPalPass;
        readonly int TenderID = 3;
        readonly string TenderName = "PayPal";

        public override int getTenderID()
        {
            return TenderID;
        }
        public override string getTenderName()
        {
            return TenderName;
        }

        public override List<string> Pay(double amount)
        {
            List<string> details = RetrievePaymentDetails(amount);
            Console.WriteLine("PAYMENT PROCESS METHOD: PAYPAL");
            return details;
        }



        public override void GetPaymentDetails()
        {
            Console.WriteLine("Enter PayPal Address:");
            PayPalAddress = Console.ReadLine();
            Console.WriteLine("Enter PayPal Password:");
            PayPalPass = Console.ReadLine();

        }

        public override List<string> RetrievePaymentDetails(double amount)
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

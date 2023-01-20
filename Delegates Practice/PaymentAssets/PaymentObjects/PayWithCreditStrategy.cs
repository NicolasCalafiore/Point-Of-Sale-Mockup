using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.PaymentStrategy;

namespace Delegates_Practice.PaymentAssets.PaymentObjects
{
    internal class PayWithCreditStrategy : IPaymentStrategy
    {
        string CardNumber;
        string ExpirationDate;
        string SecurityCode;
        readonly int TenderID = 1;
        readonly string TenderName = "Credit Card";

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
            Console.WriteLine("PAYMENT PROCESS METHOD: CREDIT CARD");
            return details;
        }

        public override void GetPaymentDetails()
        {
            Console.WriteLine("Enter Card Number:");
            CardNumber = Console.ReadLine();
            Console.WriteLine("Enter Expiration Date (MM/YY):");
            ExpirationDate = Console.ReadLine();
            Console.WriteLine("Enter Security Code:");
            SecurityCode = Console.ReadLine();
        }
        public override List<string> RetrievePaymentDetails(double amount)
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
    }
}

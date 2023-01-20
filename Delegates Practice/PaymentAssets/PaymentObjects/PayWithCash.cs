using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentAssets.PaymentObjects
{
    internal class PayWithCash : IPaymentStrategy
    {
        string amountSTR;
        int amountINT;
        readonly int TenderID = 4;
        readonly string TenderName = "Cash";
        public override void GetPaymentDetails()
        {
            Console.WriteLine("Enter Amount:");
            amountSTR = Console.ReadLine();
            amountINT = Int32.Parse(amountSTR);
        }

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
            Console.WriteLine("PAYMENT PROCESS METHOD: GIFT CARD");
            return details;
        }

        public override List<string> RetrievePaymentDetails(double amount)
        {
            List<string> details = new List<string>();
            details.Add("Cash Amount:");
            details.Add("$" + amountSTR);
            details.Add("Change:");
            details.Add("$" + (amountINT - amount).ToString("0.00"));

            return details;
            throw new NotImplementedException();
        }
    }
}

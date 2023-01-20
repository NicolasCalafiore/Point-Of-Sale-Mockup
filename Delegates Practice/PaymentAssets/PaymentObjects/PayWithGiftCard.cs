using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Delegates_Practice.PaymentStrategy;

namespace Delegates_Practice.PaymentAssets.PaymentObjects
{
    internal class PayWithGiftCard : IPaymentStrategy
    {
        public string GiftCardNumber2;
        readonly int TenderID = 2;
        readonly string TenderName = "Gift Card";

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

        public override void GetPaymentDetails()
        {
            Console.WriteLine("Enter Gift Card Number:");
            GiftCardNumber2 = Console.ReadLine();

        }

        public override List<string> RetrievePaymentDetails(double amount)
        {
            List<string> ret = new List<string>
                {
                    "Gift Card Number:",
                    GiftCardNumber2
                };
            return ret;
        }
    }
}

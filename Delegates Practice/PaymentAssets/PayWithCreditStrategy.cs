using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentStrategy
{
    internal class PayWithCreditStrategy : IPaymentStrategy
    {
        public PayWithCreditStrategy() {

        }  
        public override List<string> Pay(double amount, IPaymentMethodDisplayStrategy Payment)
        {
            List<string> details = Payment.RetrievePaymentDetails();
            Console.WriteLine("PAYMENT PROCESS METHOD: CREDIT CARD");
            return details;
        }
    }
}

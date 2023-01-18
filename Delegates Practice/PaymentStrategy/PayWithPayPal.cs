using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentStrategy
{
    internal class PayWithPayPal : IPaymentStrategy
    {
        public override List<string> Pay(double amount, IPaymentMethodStrategy Payment)
        {
            List<string> details = Payment.RetrievePaymentDetails();
            return details;
        }
    }
}

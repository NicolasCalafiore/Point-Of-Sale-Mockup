using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentStrategy
{
    abstract class IPaymentMethodDisplayStrategy
    {
        public abstract void GetPaymentDetails();
        public abstract List<string> RetrievePaymentDetails();
    }
}

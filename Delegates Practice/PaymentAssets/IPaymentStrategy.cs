using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentStrategy
{
    abstract class IPaymentStrategy
    {
        public abstract List<string> Pay(double amount, IPaymentMethodDisplayStrategy Payment);
    }
}

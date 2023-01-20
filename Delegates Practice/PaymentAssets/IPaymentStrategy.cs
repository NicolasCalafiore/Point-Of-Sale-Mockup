using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.PaymentStrategy
{
    abstract class IPaymentStrategy
    {
        public abstract int getTenderID();
        public abstract string getTenderName();
        public abstract List<string> Pay(double amount);

        public abstract void GetPaymentDetails();
        public abstract List<string> RetrievePaymentDetails(double amount);
    }
}

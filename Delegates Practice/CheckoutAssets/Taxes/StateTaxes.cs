using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.CheckoutAssets.Taxes.Taxes
{
    internal class StateTaxes
    {
        public static double NewMexicoTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return total * .0784;
        }
        public static double MissouriTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0707");
            return total * .0707;
        }
        public static double VermontTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0624");
            return total * .0624;
        }
        public static double KentuckyTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .06");
            return total * .06;
        }
        public static double NevadaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0823");
            return total * .0823;
        }
        public static double MontanaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0749");
            return total * .0749;
        }
        public static double NewYorkTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0852");
            return total * .0852;
        }
        public static double PlaceHolder(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: ERROR");
            return -1;
        }
        public static double FloridaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .07");
            return total * .07;
        }

        public static double CaliforniaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return total * .0882;
        }

        public static double ConnecticutTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return total + total * .0637;
        }
    }
}

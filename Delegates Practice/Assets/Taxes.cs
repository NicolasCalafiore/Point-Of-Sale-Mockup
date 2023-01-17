using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.Assets
{
    internal class Taxes
    {
        public static double CalculateTaxes(Cart cart, TaxDelegate taxDelegate)
        {
            double taxableAmount = 0;
            foreach (Items i in cart.ItemsGetItems())
            {
                if (i.isTaxableItem()) taxableAmount += i.getDisplayPrice();
            }
            return Math.Round(taxDelegate(taxableAmount), 2);

        }
        public static double NewMexicoTax(double total)
        {
            return (total * .0784);
        }
        public static double MissouriTax(double total)
        {
            return (total * .0707);
        }
        public static double VermontTax(double total)
        {
            return (total * .0624);
        }
        public static double KentuckyTax(double total)
        {
            return (total * .06);
        }
        public static double NevadaTax(double total)
        {
            return (total * .0823);
        }
        public static double MontanaTax(double total)
        {
            return (total * .0749);
        }
        public static double NewYorkTax(double total)
        {
            return (total * .0852);
        }
        public static double PlaceHolder(double total)
        {

            return -1;
        }
        public static double FloridaTax(double total)
        {
            return (total * .07);
        }

        public static double CaliforniaTax(double total)
        {
            return (total * .0882);
        }

        public static double ConnecticutTax(double total)
        {
            return total + (total * .0637);
        }
    }
}

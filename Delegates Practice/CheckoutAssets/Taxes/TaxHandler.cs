using Delegates_Practice.CheckoutAssets.Taxes.Taxes;
using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.CheckoutAssets.Taxes
{
    internal class TaxHandler
    {



        public static Func<double, bool, double> AssignTaxDelegate(string input)  // Assigns proper tax delegate to respective state
        {
            switch (input)
            {
                case "1": return StateTaxes.FloridaTax;
                case "2": return StateTaxes.CaliforniaTax;
                case "3": return StateTaxes.NewYorkTax;
                case "4": return StateTaxes.CaliforniaTax;
                case "5": return StateTaxes.MontanaTax;
                case "6": return StateTaxes.NevadaTax;
                case "7": return StateTaxes.KentuckyTax;
                case "8": return StateTaxes.VermontTax;
                case "9": return StateTaxes.MissouriTax;
                case "10": return StateTaxes.NewMexicoTax;
            }

            return StateTaxes.PlaceHolder;
        }
        public static double CalculateTaxes(Cart cart, Func<double, bool, double> taxDelegate, bool debugModeEnabled)
        {
            double taxableAmount = 0;
            foreach (Items i in cart.ItemsGetItems())
            {
                if (debugModeEnabled) Console.WriteLine("DEBUG EVALUATING: " + i.getDisplayTitle());
                if (debugModeEnabled) Console.WriteLine("DEBUG ITEM TAX STATUS: " + i.isTaxableItem());
                if (i.isTaxableItem()) taxableAmount += i.getDisplayPriceDouble();  // If item is taxable the taxable amount is added to a taxable price-pool
                if (debugModeEnabled) Console.WriteLine("DEBUG CURRENT TAX POOL: $" + taxableAmount.ToString("0.00"));
                if (debugModeEnabled) Console.WriteLine("");

            }


            return taxDelegate(taxableAmount, debugModeEnabled);   // Taxable price pool is sent to respective delegate to calculate amount of taxAmount due


        }
       
    }
}

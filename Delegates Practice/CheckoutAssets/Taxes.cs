using Delegates_Practice.PaymentStrategy;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.CheckoutAssets
{
    internal class Taxes
    {



        public static Func<double, bool, double> AssignTaxDelegate(String input)  // Assigns proper tax delegate to respective state
        {
            switch (input)                                              
            {
                case ("1"): return Taxes.FloridaTax; 
                case ("2"): return Taxes.CaliforniaTax;
                case ("3"): return Taxes.NewYorkTax; 
                case ("4"): return Taxes.CaliforniaTax; 
                case ("5"): return Taxes.MontanaTax;
                case ("6"): return Taxes.NevadaTax;
                case ("7"): return Taxes.KentuckyTax; 
                case ("8"): return Taxes.VermontTax; 
                case ("9"): return Taxes.MissouriTax; 
                case ("10"):return Taxes.NewMexicoTax; 
            }

            return Taxes.PlaceHolder;
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
        public static double NewMexicoTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return (total * .0784);
        }
        public static double MissouriTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0707");
            return (total * .0707);
        }
        public static double VermontTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0624");
            return (total * .0624);
        }
        public static double KentuckyTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .06");
            return (total * .06);
        }
        public static double NevadaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0823");
            return (total * .0823);
        }
        public static double MontanaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0749");
            return (total * .0749);
        }
        public static double NewYorkTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0852");
            return (total * .0852);
        }
        public static double PlaceHolder(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: ERROR");
            return -1;
        }
        public static double FloridaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .07");
            return (total * .07);
        }

        public static double CaliforniaTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return (total * .0882);
        }

        public static double ConnecticutTax(double total, bool debugModeEnabled)
        {
            if (debugModeEnabled) Console.WriteLine("DEBUG STATE TAX APPLIED: .0784");
            return total + (total * .0637);
        }
    }
}

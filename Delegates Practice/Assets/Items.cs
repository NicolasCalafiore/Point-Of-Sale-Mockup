using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.Assets
{
    internal class Items
    {
        String displayTitle;
        double displayPrice;
        bool isTaxable;
        public Items(String displayTitle, double displayPrice, bool isTaxable) {
            this.displayTitle = displayTitle;
            this.displayPrice = displayPrice;  
            this.isTaxable= isTaxable;  
        }  

        public String getDisplayTitle() { return displayTitle; }
        public double getDisplayPrice() { return displayPrice; }
        public bool isTaxableItem()
        {
            return isTaxable;
        }
    }
}

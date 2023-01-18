using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Delegates_Practice.CheckoutAssets
{
    internal class Cart
    {
        List<Items> items = new List<Items>();
        int itemCount = 0;
        double accumlatedPrice = 0;
        public Cart() {}

        public void AddItemToCart(Items item)
        {
            items.Add(item);
            Console.WriteLine("{0} was added to the shoppingCart", item.getDisplayTitle());
            itemCount++;
            accumlatedPrice += item.getDisplayPriceDouble();
            accumlatedPrice = Math.Round(accumlatedPrice, 2); 
        }

        public double getAccumulatedPrice() { return accumlatedPrice; }
        public int getItemCount() { return items.Count; }

        public List<Items> ItemsGetItems() { return items; }




    }
}

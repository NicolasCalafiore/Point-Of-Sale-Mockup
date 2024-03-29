﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delegates_Practice.CheckoutAssets
{
    internal class ItemsManager
    {
        static List<Items> items = new List<Items>();  
        public ItemsManager() {                                 // ALL ITEMS FOR SALE ADD HERE
            items.Add(new Items("Cereal", 3.99, true));
            items.Add(new Items("Fruits", 3.59, false));
            items.Add(new Items("Candy", .79, true));
            items.Add(new Items("Shirts", 12.99, true));
            items.Add(new Items("Pants", 14.99, true));
            items.Add(new Items("Soda", 2.00, true));
            items.Add(new Items("Water", 1.79, false));
            items.Add(new Items("Baby Diapers", 17.99, false));
            items.Add(new Items("Toy", 8.99, true));
            items.Add(new Items("Hat", 6.59, true));
            items.Add(new Items("Pencils", 3.59, true));
            items.Add(new Items("Sweater", 21.99, true));
            items.Add(new Items("Vegtables", 1.29, false));
            items.Add(new Items("Chips", 4.49, true));
            items.Add(new Items("Hot Dogs", 2.29, false));
        }

        public List<Items> getItems(){ return items; }
        public Items getSelectedItem(int index)
        {
            return items[index - 1];    
        }

        
    }
}

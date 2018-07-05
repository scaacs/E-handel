using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2___E_handel
{
    public class Product
    {
        // "itemNR": productData[i++].innerText, "itemName": productData[i++].innerText, "itemPrice": productData[i++].innerText, "itemQuant":
        public string itemName { get; set; }
        public double itemPrice { get; set; }
        public int itemNR { get; set; }
        public int itemQuant { get; set; }
    }
}
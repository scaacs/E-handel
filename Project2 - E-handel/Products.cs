using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project2___E_handel
{
    public class Products
    {
        public string ProductName { get; set; }
        public double Price { get; set; }
        public int ArticleNr { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }

        public Products(string productName, double price, int articleNr, string description, string category)
        {
            ProductName = productName;
            Price = price;
            ArticleNr = articleNr;
            Description = description;
            Category = category;
        }
    }
}
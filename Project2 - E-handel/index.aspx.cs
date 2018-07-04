using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2___E_handel
{
    public class Product
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string ID { get; set; }

        public Product(string name, string price, string id)
        {
            Name = name;
            Price = price;
            ID = id;
        }
    }
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<Products> products = SQL.GetAllProducts();

            string table = "<table><thead><tr><th>Artikelnummer</th><th>Produktnamn</th><th>Pris</th><th></th></tr></thead><tbody>";

            for (int i = 0; i < products.Count; i++)
            {
                string buyButton = $"<td><input type='button' onclick=\"AddToCart({ products[i].ArticleNr}, '{products[i].ProductName}', {products[i].Price});\" value='Köp' /></td>";
                table += $"<tr><td>{products[i].ArticleNr }</td><td>{products[i].ProductName}</td><td>{products[i].Price}</td>"+buyButton+"</tr>";
            }

            table += "</tbody></table>";
            Products.Text = table;
        }
    }
}
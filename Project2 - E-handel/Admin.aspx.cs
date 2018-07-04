using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Project2___E_handel
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                foreach (var p in SQL.GetAllProducts())
                {
                    ListBoxProducts.Items.Add($"Art nr. {p.ArticleNr} {p.ProductName} {p.Price}:-,  {p.Category},  { p.Description}");
                }

            }
        }

        protected void ListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxProducts.SelectedIndex >= 0)
            {
                var p = SQL.GetAllProducts()[ListBoxProducts.SelectedIndex];

                TextBoxProductName.Text = p.ProductName;
                TextBoxPrice.Text = Convert.ToString(p.Price);
                TextBoxArtNr.Text = Convert.ToString(p.ArticleNr);
                TextBoxCategory.Text = p.Category;
                TextBoxDescription.Text = p.Description;
            }
        }
        protected void ClearAndUpdate()
        {
            ListBoxProducts.Items.Clear();
            foreach (var p in SQL.GetAllProducts())
            {
                ListBoxProducts.Items.Add($"Art nr. {p.ArticleNr} {p.ProductName} {p.Price}:-,  {p.Category},  { p.Description}");
            }
            TextBoxProductName.Text = "";
            TextBoxPrice.Text = "";
            TextBoxArtNr.Text = "";
            TextBoxCategory.Text = "";
            TextBoxDescription.Text = "";
        }

        protected void ButtonCreateProduct_Click(object sender, EventArgs e)
        {
            string productName = TextBoxProductName.Text;
            double price = Convert.ToDouble(TextBoxPrice.Text);
            string category = TextBoxCategory.Text;
            string description = TextBoxDescription.Text;

            SQL.AddProduct(productName, price, description, category);
            ClearAndUpdate();
        }

        protected void ButtonUpdate_Click(object sender, EventArgs e)
        {
            if (ListBoxProducts.SelectedIndex >= 0)
            {
                var p = SQL.GetAllProducts()[ListBoxProducts.SelectedIndex];

                string newProductName = TextBoxProductName.Text;
                string newCategory = TextBoxCategory.Text;
                double newPrice = Convert.ToDouble(TextBoxPrice.Text);
                string newDescription = TextBoxDescription.Text;
                int artNr = p.ArticleNr;

                SQL.UpdateProduct(artNr, newProductName, newPrice, newDescription, newCategory);
                ClearAndUpdate();
            }
        }

        protected void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (ListBoxProducts.SelectedIndex >= 0)
            {
                var p = SQL.GetAllProducts()[ListBoxProducts.SelectedIndex];
                int artNr = p.ArticleNr;
                SQL.DeleteProduct(artNr);
                ClearAndUpdate();
            }
        }
    }
}
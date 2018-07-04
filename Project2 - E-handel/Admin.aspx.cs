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
                    ListBoxProducts.Items.Add($"Artnr. {p.ArticleNr} {p.ProductName}, {p.Price}:-");
                }

            }
        }

        protected void ListBoxProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ListBoxProducts.SelectedIndex >= 0)
            {
                //var p = SQL.GetAllProducts()[ListBoxProducts.SelectedIndex];

                //TextBoxFirstname.Text = p.Firstname;
                //TextBoxLastname.Text = p.Lastname;
                //TextBoxSSN.Text = p.SSN;


            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Newtonsoft;


namespace Project2___E_handel
{
    public partial class Login : System.Web.UI.Page
    {
        bool payButtonIsCliked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["shoppingCart"] != null)
            {
                if (payButtonIsCliked)
                {
                    Random random = new Random();
                    int orderNumber = random.Next(1, 10000);
                    float totalSum = 0;

                    for (int i = 0; i < length; i++)
                    {
                    //JSONLiteral.Text = JsonConvert.(dfgsdfgdfgdfg);
                    totalSum +=  something....

                    string firstName = Session["firstName"] != null ? Request.Form["email"].ToString() : "";
                    string lastName = Session["lastName"] != null ? Request.Form["email"].ToString() : "";
                    string email = Session["email"] != null ? Request.Form["email"].ToString() : "";
                    string password = Session["password"] != null ? Request.Form["email"].ToString() : "";
                    string street = Session["street"] != null ? Request.Form["email"].ToString() : "";
                    string zipcode = Request["zipcode"] != null ? Request.Form["email"].ToString() : "";
                    string city = Request["city"] != null ? Request.Form["email"].ToString() : "";
                    string security = Request["security"] != null ? Request.Form["email"].ToString() : "";

                    string connectionAddress = "Data Source =.; Initial Catalog = Hwhy; Integrated Security = True";
                    SqlConnection connection = new SqlConnection(connectionAddress);
                    SqlCommand myCmd = new SqlCommand("AddToOrderHistory", connection);
                    myCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    myCmd.Parameters.AddWithValue("@FirstName", firstName);
                    myCmd.Parameters.AddWithValue("@LastName", lastName);
                    myCmd.Parameters.AddWithValue("@Email", email);
                    myCmd.Parameters.AddWithValue("@Password", password);
                    myCmd.Parameters.AddWithValue("@Street", street);
                    myCmd.Parameters.AddWithValue("@Zipcode", zipcode);
                    myCmd.Parameters.AddWithValue("@City", city);
                    myCmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    myCmd.Parameters.AddWithValue("@ArtNbr", orderNumber);
                    myCmd.Parameters.AddWithValue("@ProdName", prodName);
                    myCmd.Parameters.AddWithValue("@NumberOfItems",numberOfItems);
                    myCmd.Parameters.AddWithValue("@Price", price);
                    myCmd.Parameters.AddWithValue("@TotalSum", price);


                    try
                    {
                        connection.Open();
                        myCmd.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        connection.Close();
                    }
                    }
                }
            }
        }


        private void btnPayment_Click(object sender, EventArgs e)
        {
            payButtonIsCliked = true;
        }
    }
}
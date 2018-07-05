using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Newtonsoft.Json;


namespace Project2___E_handel
{
    public partial class Payment : System.Web.UI.Page
    {
        bool payButtonIsCliked;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Form["action"] != null && Request.Form["action"].ToString().Equals("postOrder"))
            {
                cart.Text = "";
                numberOfItems.Text = $"<h4 class='d - flex justify - content - between align - items - center mb - 3'><span class='text - muted'>Din kundvagn</span><span class='badge badge-secondary badge - pill'>0</span></h4>";
            }

            if (Request.Form["action"] != null && Request.Form["action"].ToString().Equals("addOrder"))
            {
                string shoppingCartJSON = Request["productInfo"] != null ? Request.Form["productInfo"].ToString() : "";

                if (shoppingCartJSON.Length > 0)
                {
                    List<Product> shoppingCart = JsonConvert.DeserializeObject<List<Product>>(shoppingCartJSON);

                    string firstName = Request["firstName"] != null ? Request.Form["firstName"].ToString() : "";
                    string lastName = Request["lastName"] != null ? Request.Form["lastName"].ToString() : "";
                    string email = Request["email"] != null ? Request.Form["email"].ToString() : "";
                    string street = Request["street"] != null ? Request.Form["street"].ToString() : "";
                    string zipcode = Request["zipcode"] != null ? Request.Form["zipcode"].ToString() : "";
                    string city = Request["city"] != null ? Request.Form["city"].ToString() : "";

                    Random random = new Random(); // Behöver egentligen lägga in bättre koll på OrderNr så det inte blir dubbletter
                    int orderNumber = random.Next(1, 100000);

                    // SQL Connection & SQL Command
                    string connectionAddress = "Data Source =.; Initial Catalog = Hwhy; Integrated Security = True";
                    SqlConnection connection = new SqlConnection(connectionAddress);
                    SqlCommand myCmd = new SqlCommand("AddToOrderHistory", connection);
                    myCmd.CommandType = System.Data.CommandType.StoredProcedure;

                    // Adding first values
                    myCmd.Parameters.AddWithValue("@FirstName", firstName);
                    myCmd.Parameters.AddWithValue("@LastName", lastName);
                    myCmd.Parameters.AddWithValue("@Email", email);
                    myCmd.Parameters.AddWithValue("@Street", street);
                    myCmd.Parameters.AddWithValue("@Zipcode", zipcode);
                    myCmd.Parameters.AddWithValue("@City", city);

                    double totalSum = 0;
                    string listOfItems = "";
                    for (int i = 0; i < shoppingCart.Count; i++)
                    {
                        listOfItems += $"<li class='list-group-item d-flex justify-content-between lh-condensed'><div><h6 class='my-0'>{shoppingCart[i].itemName.ToString()}</h6><small class='text-muted'></small></div><span class='text-muted'>{shoppingCart[i].itemPrice.ToString()}</span></li>";
                        totalSum += Convert.ToDouble(shoppingCart[i].itemPrice.ToString()) * Convert.ToInt32(shoppingCart[i].itemQuant);
                    }

                    cart.Text = listOfItems;
                    cart.Text += $"<li class='list-group-item d-flex justify-content-between'><span>Total(SEK)</span><strong>{totalSum}</strong></li>";

                    numberOfItems.Text = $"<h4 class='d - flex justify - content - between align - items - center mb - 3'><span class='text - muted'>Din kundvagn</span><span class='badge badge-secondary badge - pill'>{shoppingCart.Count}</span></h4>";


                    //for (int i = 0; i < shoppingCart.Count; i++)
                    //{
                    //    cart.Text = $"<li>{i}</li>";


                    //    //var obj = { "itemNR": productData[i++].innerText, "itemName": productData[i++].innerText, "itemPrice": productData[i++].innerText, "itemQuant": productData[i++].innerText };

                    //    //    myCmd.Parameters.AddWithValue("@OrderNumber", orderNumber);
                    //    //    myCmd.Parameters.AddWithValue("@ArtNbr", );
                    //    //    myCmd.Parameters.AddWithValue("@ProdName", prodName);
                    //    //    myCmd.Parameters.AddWithValue("@NumberOfItems", numberOfItems);
                    //    //    myCmd.Parameters.AddWithValue("@Price", price);

                    //    //myCmd.Parameters.AddWithValue("@TotalSum", totalSum);

                    //    //try
                    //    //{
                    //    //    connection.Open();
                    //    //    myCmd.ExecuteNonQuery();
                    //    //}
                    //    //catch (Exception ex)
                    //    //{
                    //    //    throw ex;
                    //    //}
                    //    //finally
                    //    //{
                    //    //    connection.Close();
                    //    //}
                    //}
                }
            }
            else
            {
                cart.Text = "";
            }
        }
    }
}
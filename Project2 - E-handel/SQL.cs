using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Project2___E_handel
{
    public class SQL
    {
        public static string connectionString = @"Data Source=.;Initial Catalog=Hwhy;Integrated Security=True";

        public static List<Products> GetAllProducts()
        {
            List<Products> products = new List<Products>();

            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("select * from Products", myConnection);

            try
            {
                myConnection.Open();

                SqlDataReader myReader = myCommand.ExecuteReader();

                while (myReader.Read())
                {

                    string productName = myReader["ProductName"].ToString();
                    int articleNr = Convert.ToInt32(myReader["ArticleNumber"].ToString());
                    double price = Convert.ToDouble(myReader["Price"].ToString());
                    string category = myReader["Category"].ToString();
                    string description = myReader["Descrip"].ToString();

                    products.Add(new Products(productName, price, articleNr, description, category));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
            return products;

        }
        public static int AddProduct(string productName, double price, string description, string category)
        {
            int articleNr = 0;

            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("AddProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter ProductNameP = new SqlParameter("@Productname", System.Data.SqlDbType.VarChar);
            ProductNameP.Value = productName;
            myCommand.Parameters.Add(ProductNameP);

            SqlParameter PriceP = new SqlParameter("@Price", System.Data.SqlDbType.Float);
            PriceP.Value = price;
            myCommand.Parameters.Add(PriceP);

            SqlParameter DescriptionP = new SqlParameter("@Description", System.Data.SqlDbType.VarChar);
            DescriptionP.Value = description;
            myCommand.Parameters.Add(DescriptionP);

            SqlParameter CategoryP = new SqlParameter("@Category", System.Data.SqlDbType.VarChar);
            CategoryP.Value = category;
            myCommand.Parameters.Add(CategoryP);

            SqlParameter ArticleNrP = new SqlParameter("@ArtNbr", System.Data.SqlDbType.Int);
            ArticleNrP.Direction = System.Data.ParameterDirection.Output;
            myCommand.Parameters.Add(ArticleNrP);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                articleNr = Convert.ToInt32(ArticleNrP.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
            return articleNr;
        }
        public static int UpdateProduct(int articleNr, string productName, double price, string description, string category)
        {
            int succes = 2;

            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("UpdateProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter ProductNameP = new SqlParameter("@Productname", System.Data.SqlDbType.VarChar);
            ProductNameP.Value = productName;
            myCommand.Parameters.Add(ProductNameP);

            SqlParameter PriceP = new SqlParameter("@Price", System.Data.SqlDbType.Float);
            PriceP.Value = price;
            myCommand.Parameters.Add(PriceP);

            SqlParameter DescriptionP = new SqlParameter("@Description", System.Data.SqlDbType.VarChar);
            DescriptionP.Value = description;
            myCommand.Parameters.Add(DescriptionP);
            
            SqlParameter CategoryP = new SqlParameter("@Category", System.Data.SqlDbType.VarChar);
            CategoryP.Value = category;
            myCommand.Parameters.Add(CategoryP);

            SqlParameter ArticleNrP = new SqlParameter("@ArtNbr", System.Data.SqlDbType.Int);
            ArticleNrP.Value = articleNr;
            myCommand.Parameters.Add(ArticleNrP);

            SqlParameter SuccesP = new SqlParameter("@SUCCEED", System.Data.SqlDbType.Int);
            SuccesP.Direction = System.Data.ParameterDirection.Output;
            myCommand.Parameters.Add(SuccesP);
            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                succes = Convert.ToInt32(SuccesP.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
            return succes;
        }
        public static int DeleteProduct(int articleNr)
        {
            int succes = 2;
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("DeleteProduct", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter ArticleNrP = new SqlParameter("@ArtNbr", System.Data.SqlDbType.Int);
            ArticleNrP.Value = articleNr;
            myCommand.Parameters.Add(ArticleNrP);

            SqlParameter SuccesP = new SqlParameter("@SUCCEED", System.Data.SqlDbType.Int);
            SuccesP.Direction = System.Data.ParameterDirection.Output;
            myCommand.Parameters.Add(SuccesP);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                succes = Convert.ToInt32(SuccesP.Value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }
            return succes;
        }
        public static void CreateUser(int security, string firstName, string lastName, string email, string password, string ssn, string street, string zipcode, string city)
        {
            SqlConnection myConnection = new SqlConnection(connectionString);
            SqlCommand myCommand = new SqlCommand("AddUser", myConnection);
            myCommand.CommandType = System.Data.CommandType.StoredProcedure;

            SqlParameter SecurityP = new SqlParameter("@Security", System.Data.SqlDbType.Int);
            SecurityP.Value = security;
            myCommand.Parameters.Add(SecurityP);

            SqlParameter FirstnameP = new SqlParameter("@FirstName", System.Data.SqlDbType.VarChar);
            FirstnameP.Value = firstName;
            myCommand.Parameters.Add(FirstnameP);

            SqlParameter LastnameP = new SqlParameter("@LastName", System.Data.SqlDbType.VarChar);
            LastnameP.Value = lastName;
            myCommand.Parameters.Add(LastnameP);

            SqlParameter EmailP = new SqlParameter("@Email", System.Data.SqlDbType.VarChar);
            EmailP.Value = email;
            myCommand.Parameters.Add(EmailP);

            SqlParameter PasswordP = new SqlParameter("@Password", System.Data.SqlDbType.VarChar);
            PasswordP.Value = password;
            myCommand.Parameters.Add(PasswordP);

            SqlParameter SSNP = new SqlParameter("@SSN", System.Data.SqlDbType.VarChar);
            SSNP.Value = ssn;
            myCommand.Parameters.Add(SSNP);

            SqlParameter streetP = new SqlParameter("@Street", System.Data.SqlDbType.VarChar);
            streetP.Value = street;
            myCommand.Parameters.Add(streetP);

            SqlParameter zipcodeP = new SqlParameter("@Zipcode", System.Data.SqlDbType.VarChar);
            zipcodeP.Value = zipcode;
            myCommand.Parameters.Add(zipcodeP);

            SqlParameter cityP = new SqlParameter("@City", System.Data.SqlDbType.VarChar);
            cityP.Value = city;
            myCommand.Parameters.Add(cityP);

            try
            {
                myConnection.Open();
                myCommand.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                myConnection.Close();
            }

        }

    }
}
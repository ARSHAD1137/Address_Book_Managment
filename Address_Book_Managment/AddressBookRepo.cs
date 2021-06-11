using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Address_Book_Managment
{
    public class Salary
    {
        private static SqlConnection ConnectionSetup()
        {
            return new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Address_book;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public int UpdateContactPerson(ContactModel contactModel)
        {
            SqlConnection ContactConnection = ConnectionSetup();
            int salary = 0;
            try
            {
                using (ContactConnection)
                {
                    string id = "2";
                    //string id=Console.ReadLine();
                    string query = @"select * from Address_book where id=" + Convert.ToInt32(id);
                    ContactModel displayModel = new ContactModel();
                    SqlCommand command = new SqlCommand("spUpdateContactPerson", ContactConnection);
                    command.CommandType = System.Data.CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", ContactModel.Contact_Id);
                    command.Parameters.AddWithValue("@address", ContactModel.Contact_Address);
                    command.Parameters.AddWithValue("@city", ContactModel.Contact_City);
                    command.Parameters.AddWithValue("@state", ContactModel.Contact_State);
                    command.Parameters.AddWithValue("@zipCode", ContactModel.Contact_ZipCode);
                    ContactConnection.Open();
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            displayModel.Contact_Id = Convert.ToInt32(dr["Contact_Id"]);
                            displayModel.Contact_Address = dr["Contact_Address"].ToString();
                            displayModel.Contact_City = dr["Contact_City"].ToString();
                            displayModel.Contact_State = dr["Contact_State"].ToString();
                            displayModel.Contact_ZipCode = Convert.ToInt32(dr["Contact_ZipCode"]);
                            
                            Console.WriteLine(displayModel.Contact_Id + " " + displayModel.Contact_Address + " " + displayModel.Contact_City+" "+displayModel.Contact_State+" "+displayModel.Contact_ZipCode);
                            Console.WriteLine("\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            finally
            {
                ContactConnection.Close();
            }
            return salary;
        }
    }

}

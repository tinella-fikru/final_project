using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject.model
{
    internal class AdminClass
    {

        static private List<AdminClass> Aclass = new List<AdminClass>();


        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactInfo { get; set; }
        public string DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }


        public void save()
        {
            Aclass.Add(this);
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
               
                
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string gen;

                string Query = "exec ADDEMP @fname,@lname,@contactInfo,@dob,@email,@occupation,@gender;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", this.firstName);
                cmd.Parameters.AddWithValue("@lname", this.lastName);
                cmd.Parameters.AddWithValue("@contactInfo", this.contactInfo);
                cmd.Parameters.AddWithValue("@dob", this.DateOfBirth);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@occupation", this.Occupation);
                cmd.Parameters.AddWithValue("@gender", this.Gender);

                var result = cmd.ExecuteNonQuery();
             
                MessageBox.Show("Successfully Saved!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };


        }
        static public List<AdminClass> GetAllProducts()
        {
            List<AdminClass> Bclass = new List<AdminClass>();
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from employee;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    AdminClass ac = new AdminClass();

                    ac.id = (int)sdr["employeeID"];
                    ac.firstName = (string)sdr["firstName"];
                    ac.lastName = (string)sdr["lastName"];
                    ac.contactInfo = (string)sdr["ContactInfo"];
                    ac.DateOfBirth = (string)sdr["DOB"];
                    ac.Email = (string)sdr["email"];
                    ac.Occupation = (string)sdr["Occupation"];
                    ac.Gender = (string)sdr["gender"];



                    Bclass.Add(ac);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };
            return Bclass;
        }
        public static AdminClass findOne(string name)
        {
            List<AdminClass> Bclass = new List<AdminClass>();
            SqlConnection connection;
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            connection = new SqlConnection(connectionString);
            string Query = "select * from employee;";
            try
            {

                connection.Open();
                MessageBox.Show("connection successful!!!");


                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    AdminClass ac = new AdminClass();
                    ac.id = (int)sdr["employeeID"];
                    ac.firstName = (string)sdr["firstName"];
                    ac.lastName = (string)sdr["lastName"];
                    ac.contactInfo = (string)sdr["ContactInfo"];
                    ac.DateOfBirth = (string)sdr["DOB"];
                    ac.Email = (string)sdr["email"];
                    ac.Occupation = (string)sdr["Occupation"];
                    ac.Gender = (string)sdr["gender"];
                    Bclass.Add(ac);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();
            };
            return Bclass.Find(c => c.firstName == name);
        }
        public static void update(string id,string fn,string ln, string cont, string date, string email,string occup,string gender)
        {
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec UPDATEEMP @fname,@lname,@contactInfo,@dob,@email,@occupation,@gender,@id;";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", fn);
                cmd.Parameters.AddWithValue("@lname",ln);
                cmd.Parameters.AddWithValue("@contactInfo", cont);
                cmd.Parameters.AddWithValue("@dob", date);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@occupation", occup);
                cmd.Parameters.AddWithValue("@gender", gender);
                cmd.Parameters.AddWithValue("@id", id);

                var result = cmd.ExecuteNonQuery();
             
                MessageBox.Show("Successfully Updated!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };



        }

        public static void delete(string id)
        {
            string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
               
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string Query = "exec DELETEEMP @id;";
                SqlCommand cmd = new SqlCommand(Query, connection);
                
                cmd.Parameters.AddWithValue("@id", id);

                var result = cmd.ExecuteNonQuery();
                
                MessageBox.Show("Successfully Deleted!!!");
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                connection.Close();
            };
        }


    }
}

 

    
 
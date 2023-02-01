using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
namespace FinalProject.model
{
    internal class Class1
    {
        static private List<Class1> class1 = new List<Class1>();
        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }
        public string emailextension { get; set; }
        public string contactInfo { get; set; }


        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;";



        public void save()
        {
            class1.Add(this);

            SqlConnection connection = new SqlConnection(connectionString);
            try
            {

                connection.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = connection;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "sp_ins";
               
                cmd.Parameters.AddWithValue("@fn", this.firstName);
               
                cmd.Parameters.AddWithValue("@ln", this.lastName);
            

                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@ci", this.contactInfo);
                cmd.Parameters.AddWithValue("@password", this.Password);

                SqlParameter o = new SqlParameter();
                o.ParameterName = "@id";
                o.SqlDbType = SqlDbType.Int;
                o.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(o);

                cmd.ExecuteNonQuery();
                this.id = int.Parse(o.Value.ToString());
                MessageBox.Show("Successfully Signed up!!!");

                string query2 = "exec sp_insert @email,@password,@id";

                SqlCommand cmd2 = new SqlCommand(query2, connection);
                cmd2.Parameters.AddWithValue("@id", id);
                cmd2.Parameters.AddWithValue("@password", this.Password);
                cmd2.Parameters.AddWithValue("@email", this.Email);
                cmd2.ExecuteNonQuery();


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


        public static Class1 findpass(string email, string ci)
        {
            List<Class1> temp = new List<Class1>();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string Query = "select * from sign_up_info;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 cc = new Class1();
                    cc.id = (int)sdr["id"];
                    cc.Email = (string)sdr["email"];
                    cc.contactInfo = (string)sdr["contactInfo"];
                    temp.Add(cc);
                }
                connection.Close();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
            return temp.Find(c1 => c1.Email == email && c1.contactInfo == ci);
        }

        public static Class1 findOne(string email, string password)
        {
            List<Class1> temp = new List<Class1>();
            try
            {

                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();

                string Query = "select * from login;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 c1 = new Class1();
                    c1.id = (int)sdr["id"];
                    c1.Email = (string)sdr["email"];
                    c1.Password = (string)sdr["password"];
                    temp.Add(c1);
                }
                connection.Close();

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            };
            return temp.Find(c1 => c1.Email == email && c1.Password == password);
        }
    
    }


}




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace FinalProject.model
{
    internal class Class1
    {


        static private List<Class1> class1 = new List<Class1>();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }

        public int phone { get; set; }




        public void save()
        {
            try
            {
                class1.Add(this);
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "insert into sign_up values(@name,@email,@phone,@password);";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@name", this.Name);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@phone", this.phone);
                cmd.Parameters.AddWithValue("@password", this.Password);

                var result = cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Signed up!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };


        }


        public static Class1 findOne(string email,string password)
        {
            List<Class1> temp = new List<Class1>();
            try
            {
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select email,password from sign_up ;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    string em, pwd;


                    em = (string)sdr["email"];

                    pwd = (string)sdr["password"];

                    

                    if (em==email && pwd == password)
                    {

                        MainPage screen = new MainPage();
                        screen.Show();
                        //this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Incorrect Email or Password");
                    }
                   
                }

                connection.Close();

            }


            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return temp.Find(c => c.Email == email);
        }



        public static List<Class1> getAllProducts()
        {

            List<Class1> temp = new List<Class1>();
            try
            {
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");

                string Query = "select * from employee;";
                SqlCommand cmd = new SqlCommand(Query, connection);

                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())

                {
                    Class1 c = new Class1();

                    c.Name = (string)sdr[0];
                    c.Email = (string)sdr[1];
                    c.phone = (int)sdr[2];
                    c.Password = (string)sdr[3];



                    temp.Add(c);
                }
                connection.Close();
            }



            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return temp;
        }


    }
}




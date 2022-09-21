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
        static private List<AdminClass> Bclass = new List<AdminClass>();

        public int id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string contactInfo { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Occupation { get; set; }
        public string Gender { get; set; }


        public void save()
        {
            try
            {
                Aclass.Add(this);
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                MessageBox.Show("connection successful!!!");
                string gen;
                
                string Query = "insert into employee values(@fname,@lname,@contactInfo,@dob,@email,@occupation,@gender);";

                SqlCommand cmd = new SqlCommand(Query, connection);
                cmd.Parameters.AddWithValue("@fname", this.firstName);
                cmd.Parameters.AddWithValue("@lname", this.lastName);
                cmd.Parameters.AddWithValue("@contactInfo", this.contactInfo);
                cmd.Parameters.AddWithValue("@dob", this.DateOfBirth);
                cmd.Parameters.AddWithValue("@email", this.Email);
                cmd.Parameters.AddWithValue("@occupatiion", this.Occupation);
                cmd.Parameters.AddWithValue("@gender", this.Gender);

                var result = cmd.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Successfully Signed up!!!");



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };


        }
        static public List<AdminClass> GetAllProducts()
        {
            try
            {
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_projejct;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
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
                    ac.DateOfBirth = (DateTime)sdr["DOB"];
                    ac.Email = (string)sdr["email"];
                    ac.Occupation = (string)sdr["Occupation"];
                    ac.Gender = (string)sdr["gender"];



                    Bclass.Add(ac);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return Bclass;
        }
        public static AdminClass findOne(string name)
        {
            try
            {
                string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_projejct;Integrated Security=true;";
                SqlConnection connection = new SqlConnection(connectionString);
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
                    ac.DateOfBirth = (DateTime)sdr["DOB"];
                    ac.Email = (string)sdr["email"];
                    ac.Occupation = (string)sdr["Occupation"];
                    ac.Gender = (string)sdr["gender"];



                    Bclass.Add(ac);
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            };
            return Bclass.Find(c => c.firstName == name);

        }


            

        }

 }
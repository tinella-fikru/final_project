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
        /*string sc = "Data Source=TINELLA\\SQLEXPRESS;Database=final_project;Integrated Security=true;";
        SqlConnection con = new SqlConnection("Data Source=TINELLA\\SQLEXPRESS;Database=final_project;Integrated Security=true;");
        SqlCommand cmd = new SqlCommand("select * from sign_up");
        con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                Console.WriteLine("\t{0}",sdr.GetString(0));
            }
    con.Close();*/
        string path = "server=TINELLA\\SQLEXPRESS; Database=final_project;Integrated Security=true;";// ConfigurationManager.ConnectionStrings["dbcs"].ConnectionString;
        SqlConnection con;
        public Class1()
        {
            MessageBox.Show("U r here");
            con = new SqlConnection();
            //try
            {
                con.ConnectionString = path;
                con.Open();
                MessageBox.Show("connection is successful");
                con.Close();
                MessageBox.Show("U r here again");
            }
            //catch(SqlException ex)
            //{ 
            //    MessageBox.Show(ex.Message); 
            //}
            //finally { con.Close(); }
        }

        static private List<Class1> class1 = new List<Class1>();

        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string confirmPassword { get; set; }

        public int phone { get; set; }




        public void save()
        {
            class1.Add(this);
            MessageBox.Show("Successfully Signed In!!!");
        }
        public static Class1 findOne(string name)
        {
            return class1.Find(c => c.Name == name);
        }

        public static List<Class1> getAllProducts()
        {
            return class1;
        }
    }
}
/*
string constring = "datasource=TINELLA\\SQLEXPRESS; database=final_project;integrated security=true;";
string query = "insert into sign_up values("'+txt_fn+'","'+txt_email+'","+txt_phone+'","'+txt_password+'")";
            using (Sqlconnection con = new SQLConnection(constring))
{
    SqlCommand cmd = new SqlCommand(query, con);
    con.Open();
    int rowsAffected = cmd.ExecuteNonQuery();
    if (rowsAffected > 0)
        MessageBox.Show("Save Successful")
            }*/
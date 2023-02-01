using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FinalProject
{
    public partial class SeeOrders : Form
    {
        int id;
        public string bridename { set; get; }
        public string bridelname { set; get; }
        public string groomname { set; get; }
        public string groomlname { set; get; }
        public string package { set; get; }
        public string guests { set; get; }
        public string weddingDate { set; get; }
        public string royal { set; get; }
        public string premium { set; get; }
        public string simple { set; get; }
        public string luxury { set; get; }
        public string basic { set; get; }
        public string custom { set; get; }

        public SeeOrders(int id)
        {
            InitializeComponent();
            this.id = id;
        }
        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;";
        private void SeeOrders_Load(object sender, EventArgs e)
        {
           
            // int ID = id;
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("select groomName,brideName,packageName,guests,weddingdate from weddingInfos where userId='"+id+"'", connection);
                cmd.Parameters.AddWithValue("id", id);
                SqlDataReader reader;
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {

                    label1.Text = reader["brideName"].ToString();
                    label2.Text = reader["groomName"].ToString();
                    label3.Text = reader["guests"].ToString();
                    label4.Text = reader["packageName"].ToString();
                    label5.Text = reader["Weddingdate"].ToString();
                }
                else
                {
                    MessageBox.Show("You have not booked anything yet");
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


        }

        private void label11_Click(object sender, EventArgs e)
        {
            this.Close();
            contact_us c = new contact_us();
            c.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {
            this.Close();
            loggedIn l = new loggedIn(id);
                l.Show();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace FinalProject
{
    public partial class revenue : Form
    {
        public revenue()
        {
            InitializeComponent();
            label5.Text = GetTotInc();
            label3.Text =GetTotCust();
            label2.Text = GetTotEmp();
            label7.Text = GetTotWedd();
            label10.Text = GetVat();
            label12.Text=GetProf();
        }

        public static string connectionString = @"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;";

        private void guna2CustomGradientPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        private string GetTotInc()
        {
        
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select total from revenue ";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }
        private string GetTotCust()
        {
             SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select dbo.totCust()";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }
        private string GetTotEmp()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select dbo.totEmp()";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }
        private string GetTotWedd()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select dbo.totalWedd()";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }
        private string GetVat()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select vat from revenue";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }

        private string GetProf()
        {
            SqlConnection con = new SqlConnection(connectionString);
            con.Open();
            string Query = "select dbo.calcProfit()";
            SqlCommand cmd = new SqlCommand(Query, con);

            string t = cmd.ExecuteScalar().ToString();

            con.Close();
            return t;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {
            this.Close();
            adminHomePage a=new adminHomePage();
            a.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void revenue_Load(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2CustomGradientPanel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

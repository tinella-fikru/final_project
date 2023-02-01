using FinalProject.model;
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
using System.Configuration;

namespace FinalProject
{
    public partial class custom : Form
    {
        int id;
        public custom(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        { 
           Class2 c=new Class2();
            c.selected(id, checkedListBox1);
          
            this.Close();

            }
        

        private void custom_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Class2 c = new Class2();
            c.selected(id, checkedListBox1);
            SqlConnection con = new SqlConnection(@"Data Source=TINELLA\SQLEXPRESS; Initial catalog=fp;Integrated Security=true;");
            con.Open();
            string Query = "select dbo.priceCalc(@id)";
            SqlCommand cmd3 = new SqlCommand(Query, con);
            cmd3.Parameters.AddWithValue("@id", id);
            label4.Text = cmd3.ExecuteScalar().ToString();


            con.Close();
        }
    } }


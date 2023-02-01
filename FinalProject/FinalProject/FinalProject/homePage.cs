using FinalProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace FinalProject
{
    public partial class homePage : Form
    {
        public homePage()
        {
           this. DoubleBuffered = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            
        }


          private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            signup form1 = new signup();
            form1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void adminLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            admin_login form1 = new admin_login();
            form1.Show();
        }

        private void contactInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            contact_us form1 = new contact_us();           
            form1.Show();
        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            about_us form1 = new about_us();
            form1.Show();
        }

      /*  private void servicesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            Services s = new Services();
            s.Show();
        }*/

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();
            }
            signup sign = new signup();
            sign.Show();
        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {

           /* SqlConnection connection = new SqlConnection(@"Data Source=TINELLA\SQLEXPRESS; Initial catalog=final_project;Integrated Security=true;");
            SqlDataAdapter sda = new SqlDataAdapter("select * from login where email ='"+guna2TextBox3.Text +"' and password ='"+guna2TextBox4.Text+"'",connection);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if(dt.Rows.Count > 0)
            {
               
            }*/
            if (guna2CheckBox1.Checked== true)
            {
                Properties.Settings.Default.Email = guna2TextBox3.Text;
                Properties.Settings.Default.Password = guna2TextBox4.Text;
                Properties.Settings.Default.Save();
            }
            if (guna2CheckBox1.Checked == false)
            {
                Properties.Settings.Default.Email = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Save();
            }

            if (guna2TextBox3.Text == "" && guna2TextBox4.Text == "")
            {
                MessageBox.Show("No information entered.");
            }
            else
            {
                var log = Class1.findOne(guna2TextBox3.Text, guna2TextBox4.Text);
                if (log == null)
                {
                    MessageBox.Show("You entered incorrect information try again ");
                }
                else
                {
                    {
                        if (ActiveMdiChild != null)
                        {
                            ActiveMdiChild.Close();
                        }
                        loggedIn l=new loggedIn(log.id);
                        l.Show();
                        /*
                        Services s = new Services(log.id);
                        s.Show();*/
                    }
                }
            }
            
        }

        private void pn_login_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ControlBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }

        private void homePage_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Email != String.Empty)
            {
                guna2TextBox3.Text = Properties.Settings.Default.Email;
                guna2TextBox4.Text = Properties.Settings.Default.Password;
            }
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
           if( ActiveMdiChild != null)
           {
                ActiveMdiChild.Close();
            }
            
            Fp fp = new Fp();
            fp.Show();
        }

        private void guna2CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}


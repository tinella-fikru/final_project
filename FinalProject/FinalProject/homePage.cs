using FinalProject.model;
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
    public partial class homePage : Form
    {
        public homePage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            { 

                MainPage screen = new MainPage();
                screen.Show();
                this.Hide();
            }
        }


          private void signUpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != null)
            {
                ActiveMdiChild.Close();


            }


            Form1 form1 = new Form1();
          //  form1.MdiParent = this;
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
            //  form1.MdiParent = this;
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

    }
}


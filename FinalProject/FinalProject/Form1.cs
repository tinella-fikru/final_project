using FinalProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();

            Regex r = new Regex(@"^([^0-9]*)$");

            if (txt_phone.Text.Length == 10)
            {

            }
            else
            {
                errorProvider1.SetError(txt_phone, "Please enter 10 digits ");
            }

            if (string.IsNullOrEmpty(txt_password.Text))
            {
                errorProvider1.SetError(txt_password, "Password is required ");


            }
            if (string.IsNullOrEmpty(txt_cp.Text))
            {
                errorProvider1.SetError(txt_cp, " enter your Password again ");


            }


            if (string.IsNullOrEmpty(txt_email.Text))
            {
                errorProvider1.SetError(txt_email, "Your Email is required");
            }

           

            
            else if (!r.IsMatch(txt_fn.Text))
            {
                errorProvider1.SetError(txt_fn, "Your Name should'nt contain numbers");

            }
            if (txt_password.Text != txt_cp.Text)
            {
                MessageBox.Show("Please re-enter your password correctly!!!");
            }
            

            else
            {
                try
                {
                    Class1 c = new Class1
                    {
                        Name = (txt_fn.Text),
                        Email = (txt_email.Text),
                        phone = int.Parse(txt_phone.Text),
                        Password = (txt_password.Text),
                        




                    };
                    c.save();
                   
                    Panel screen = new Panel();
                    screen.Show();
                    this.Hide();

                }
                catch (Exception)
                {
                    MessageBox.Show("Type mismatch");
                };
                       
            }
           
        }


       

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
    
}


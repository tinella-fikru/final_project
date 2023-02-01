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
    public partial class signup : Form
    {
        public signup()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }


       

        private void button2_Click_1(object sender, EventArgs e)
        {
            System.Environment.Exit(0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {
            bool errorcheck = true;
            errorProvider1.Clear();
            //MessageBox.Show(txt_cp.Text.ToString() + " " + txt_password.Text);

            Regex r = new Regex(@"^([^0-9]*)$");
            if (txt_fn.Text == "" || txt_ln.Text == "" || txt_email.Text == "" || txt_phone.Text == "" || txt_password.Text == "") {
                MessageBox.Show("Please enter all information");
                errorcheck = false;
            }
            if (guna2ComboBox1.SelectedItem == null)
            {
                errorProvider1.SetError(guna2ComboBox1, "Please select one");
                errorcheck = false;
            }

            if (txt_phone.Text.Length != 10)
            {
                errorProvider1.SetError(txt_phone, "Please enter 10 digits ");
                errorcheck = false;
            }
            if (string.IsNullOrEmpty(txt_password.Text))
            {
                errorProvider1.SetError(txt_password, "Password is required ");
                errorcheck = false;
            }
                if (string.IsNullOrEmpty(txt_cp.Text))
                {
                    errorcheck = false;
                    errorProvider1.SetError(txt_cp, " enter your Password again ");
                   
                }

            if (txt_cp.Text != txt_password.Text)
            {
                errorcheck = false;
                errorProvider1.SetError(txt_cp, "Password Mismatch!!");
                MessageBox.Show("Please re-enter your password correctly!!!");
            }

            if (string.IsNullOrEmpty(txt_email.Text))
                    errorProvider1.SetError(txt_email, "Your Email is required");
                if (string.IsNullOrEmpty(guna2ComboBox1.Text))
                    errorProvider1.SetError(guna2ComboBox1, "Your required to select one email adress extension");
                if (string.IsNullOrEmpty(txt_fn.Text))
                    errorProvider1.SetError(txt_fn, "First name is required");
                if (!r.IsMatch(txt_fn.Text))
                    errorProvider1.SetError(txt_fn, "First Name should'nt contain numbers");
                if (string.IsNullOrEmpty(txt_ln.Text))
                    errorProvider1.SetError(txt_ln, "Last name is required");
                if (!r.IsMatch(txt_fn.Text))
                    errorProvider1.SetError(txt_fn, "Last name should'nt contain numbers");          
            else if(errorcheck == true)
            {
                try
                {
                    Class1 c = new Class1
                    {
                        firstName = (txt_fn.Text),
                        lastName = (txt_ln.Text),
                        Email = (txt_email.Text)+ (guna2ComboBox1.Text),
                        contactInfo = (txt_phone.Text),
                        Password = (txt_password.Text)
                    };
                    c.save();
                }
                catch (Exception)
                {
                    MessageBox.Show("Type mismatch");
                };

            }

        }

        private void label10_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            homePage home = new homePage();
            home.Show();
        }

        private void txt_phone_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_cp_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_email_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
    



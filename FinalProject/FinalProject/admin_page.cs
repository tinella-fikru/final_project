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
    public partial class admin_page : Form
    {
        public admin_page()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            errorProvider1.Clear();

            Regex r = new Regex(@"^([^0-9]*)$");
            Regex r2 = new Regex(@"[+][0-9]$");

            if (textBox4.Text.Length == 10)
            {

            }
            else
            {
                errorProvider1.SetError(textBox4, "Please enter 10 digits ");
            }

            if (string.IsNullOrEmpty(textBox2.Text))
            {
                errorProvider1.SetError(textBox2, " First Name is required ");
            }
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                errorProvider1.SetError(textBox3, " Last name is required ");
            }
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                errorProvider1.SetError(textBox4, "Your Contact info is required");
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                errorProvider1.SetError(textBox7, "Your Email is required");
            }
            else if (!r.IsMatch(textBox2.Text))
                errorProvider1.SetError(textBox2, "Your Name should'nt contain numbers");

            
            else if (!r.IsMatch(textBox3.Text))
                errorProvider1.SetError(textBox3, "Your Name should'nt contain numbers");


            



            else
            {
                string gen;
                if (radioButton1.Checked)
                    gen = radioButton1.ToString();
                else
                    gen = radioButton2.ToString();

                try
                {
                    AdminClass ac = new AdminClass()
                    {
                        firstName = textBox2.Text,
                        lastName = textBox3.Text,
                        contactInfo = textBox4.Text,
                        DateOfBirth = dateTimePicker1.Value,
                        Email = textBox7.Text,
                        Occupation = textBox8.Text,
                        Gender = gen
                    };


                    ac.save();

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

        private void button5_Click(object sender, EventArgs e)
        {
            var product = AdminClass.findOne(textBox9.Text);
            if (product == null)
            {
                MessageBox.Show("Hi");
            }
            else
            {
                label9.Text = product.id.ToString();
                textBox2.Text = product.firstName;
                textBox3.Text = product.lastName;
                textBox4.Text = product.contactInfo;
                //textBox5.Text = product.DateOfBirth;
                textBox7.Text = product.Email;
                textBox8.Text = product.Occupation;
            }

        }
    }
}

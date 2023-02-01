using FinalProject.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class employee_page : Form
    {
        public employee_page()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AdminClass.GetAllProducts();
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
                errorProvider1.SetError(textBox4, "Contact info is required");
            }
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                errorProvider1.SetError(textBox7, "Email is required");
            }
            else if (!r.IsMatch(textBox2.Text))
                errorProvider1.SetError(textBox2, "Name should'nt contain numbers");

            
            else if (!r.IsMatch(textBox3.Text))
                errorProvider1.SetError(textBox3, "Name should'nt contain numbers");


            else
            {
                string gen;
                if (radioButton1.Checked)
                    gen = radioButton1.Text;
                else
                    gen = radioButton2.Text;

                try
                {
                    AdminClass ac = new AdminClass()
                    {
                        firstName = textBox2.Text,
                        lastName = textBox3.Text,
                        contactInfo = textBox4.Text,
                        DateOfBirth =dateTimePicker1.Value.ToString(),
                        Email = textBox7.Text,
                        Occupation = comboBox1.Text,
                        Gender = gen
                    };


                    ac.save();
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource=AdminClass.GetAllProducts();
                    

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
                MessageBox.Show("Employee doesn't Exist");
            }
            else
            {
                label9.Text = product.id.ToString();
                textBox2.Text = product.firstName;
                textBox3.Text = product.lastName;
                textBox4.Text = product.contactInfo;
                dateTimePicker1.Value = DateTime.Parse(product.DateOfBirth);
                textBox7.Text = product.Email;
                comboBox1.Text = product.Occupation;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string gen;
            if (radioButton1.Checked)
                gen = radioButton1.Text;
            else
                gen = radioButton2.Text;
            AdminClass.update(label9.Text, textBox2.Text, textBox3.Text, textBox4.Text,dateTimePicker1.Text, textBox7.Text, comboBox1.Text,gen);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AdminClass.GetAllProducts();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AdminClass.delete(label9.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = AdminClass.GetAllProducts();
        }

        private void admin_page_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            adminHomePage form1 = new adminHomePage();
            form1.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

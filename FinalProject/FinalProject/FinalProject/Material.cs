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

namespace FinalProject
{
    public partial class Material : Form
    {
        public Material()
        {
            InitializeComponent();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = booking.GetAllProducts();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            //int i = int.Parse(textBox_search.Text);
            var product = booking.findOne(int.Parse(textBox_search.Text));
            if (product == null)
            {
                
                MessageBox.Show("Customer doesn't Exist");
            }
            else
            {
                label7.Text = product.id.ToString();
                textBox_fn.Text = product.groomName;
                textBox_ln.Text = product.brideName;
                dateTimePicker1.Value = DateTime.Parse(product.weddingDate.ToString());
                textBox_ng.Text = product.guests.ToString();
                //dateTimePicker1.Value = DateTime.Parse(product.weddingDate);
                
            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            booking.update(int.Parse(label7.Text),textBox_fn.Text,textBox_ln.Text, int.Parse(textBox_ng.Text), comboBox1.SelectedItem.ToString(),dateTimePicker1.Value);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = booking.GetAllProducts();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            
            booking.delete(label7.Text);
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = booking.GetAllProducts();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            adminHomePage home = new adminHomePage();
            home.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

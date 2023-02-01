using FinalProject.model;
using FinalProject.serviceForms;
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
    public partial class Services : Form
    {
        //int id;
        public Services()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            //this.id=id;
        }
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle= FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForms.Controls.Add(childForm);
            panelForms.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            
            
        }

        private void Services_Load(object sender, EventArgs e)
        {

        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            openChildForm(new catering());
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            openChildForm(new beauty());
           }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            openChildForm(new decor());
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            openChildForm(new photography());
        }
        private void guna2Button2_Click(object sender, EventArgs e)
        {
            openChildForm(new dj());
        }

        private void guna2Button1_Click_2(object sender, EventArgs e)
        {
           /* homePage s = new homePage();
            s.Show();*/
            this.Close();

        }
        
       
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.Close();
            MainPage m = new MainPage();
            m.Show();
          
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {/*
            this.Close();
            signInfo s=new signInfo();
            s.Show();*/
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            openChildForm(new venue());
        }

        private void guna2ControlBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

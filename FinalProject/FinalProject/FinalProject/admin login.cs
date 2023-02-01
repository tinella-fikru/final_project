using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalProject
{
    public partial class admin_login : Form
    {
        public admin_login()
        {
            this.DoubleBuffered = true;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void button2_Click(object sender, EventArgs e)
        {
          System.Environment.Exit(0);
        }
        [DllImport("user32.dll", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user.Dll",EntryPoint ="SendMessage")]
        private extern static void SendMessage(System.IntPtr hWind,int wMeg,int wParam,int lParam);
        private void admin_login_Load(object sender, EventArgs e)
        {

        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
        ReleaseCapture();
        SendMessage(Handle, 0x112, 0xf012, 0);

        }
        private void guna2GradientButton1_Click(object sender,EventArgs e)
        {
            if(guna2TextBox1.Text=="admin" && guna2TextBox2.Text == "admin")
            {
                adminHomePage screen=new adminHomePage();
                screen.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Incorrect infomation");
            }
        }
        private void guna2GradientButton2_Click(object sender,EventArgs e)
        {
            System.Environment.Exit(0);
        }
    }
}

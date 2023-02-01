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
    public partial class loggedIn : Form
    {
        int id;
        public loggedIn(int id)
        {
            this.DoubleBuffered = true;
            InitializeComponent();
            this.id = id;
        }

       /* private void guna2CircleButton1_Click(object sender, EventArgs e)
        {
            Services s = new Services();
            s.Show();
        }

        private void guna2CircleButton2_Click(object sender, EventArgs e)
        {
            signInfo si = new signInfo(id);
            si.Show();
        }*/

        private void guna2GradientCircleButton1_Click(object sender, EventArgs e)
        {
            Services s = new Services();
            s.Show();
        }

        private void guna2GradientCircleButton2_Click(object sender, EventArgs e)
        {
            signInfo si = new signInfo(id);
            si.Show();
        }

        private void loggedIn_Load(object sender, EventArgs e)
        {

        }

        private void guna2GradientCircleButton3_Click(object sender, EventArgs e)
        {
          
        }

        private void guna2GradientCircleButton3_Click_1(object sender, EventArgs e)
        {
            SeeOrders s = new SeeOrders(id);
            this.Hide();
            s.Show();
        }
    }
}

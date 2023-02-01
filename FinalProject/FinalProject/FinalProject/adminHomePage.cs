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
    public partial class adminHomePage : Form
    {
        public adminHomePage()
        {
            InitializeComponent();
        }

        private void employeeManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            employee_page emp = new employee_page();
            emp.Show();
        }

        private void bookingManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            Material mat = new Material();
            mat.Show();
        }

        

        private void adminHomePage_Load(object sender, EventArgs e)
        {

        }

        private void logOutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            admin_login ad = new admin_login();
            ad.Show();
        }

        private void revenueManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveForm != null)
            {
                ActiveForm.Close();
            }
            revenue r = new revenue();
            r.Show();
        }
    }
}

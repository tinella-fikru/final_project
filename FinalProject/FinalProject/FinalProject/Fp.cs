using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace FinalProject
{
    public partial class Fp : Form
    {
        string randomCode;
        public static string to;
        public Fp()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string from, pass, messageBody;
            Random rand = new Random();
            randomCode = (rand.Next(9999999)).ToString();
            MailMessage message = new MailMessage();
            to = (txtemail.Text).ToString();
            from = "tinellafikrunimane@gmail.com";
            pass = "rebrkvcncjwoufos";
            messageBody = "your OTP is " + randomCode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messageBody;
            message.Subject = "password reseting code";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);
            try
            {
                smtp.Send(message);
                MessageBox.Show("code sent successfully");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtemail.Text == "" && txtverifypwd.Text == "")
            {
                MessageBox.Show("No information entered.");
            }
            if (randomCode == (txtverifypwd.Text).ToString())
            {
                to = txtemail.Text;
                resetpwd rp = new resetpwd();
                this.Hide();
                rp.Show();
            }
            else
            {
                MessageBox.Show("Wrong Password");
            }
        }

        private void txtemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void Fp_Load(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HOTTEL
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
        private void Email_Leave(object sender, EventArgs e)
        {
            if (Email.Text == "")
                Email.Text = "Email";
        }

        private void Email_Click(object sender, EventArgs e)
        {
            if (Email.Text == "Email")
                Email.Text = "";
        }

        private void Password_Leave(object sender, EventArgs e)
        {
            if (Password.Text == "")
                Password.Text = "Password";
        }

        private void Password_Click(object sender, EventArgs e)
        {
            if (Password.Text == "Password")
                Password.Text = "";
        }

        private void Password_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (Email.Text == "adil@gmail.com" && Password.Text == "adil123")
            {
                Form1 a = new Form1();
                a.Visible = true;
                this.Close();

            }
                
            else
                MessageBox.Show("Les Données est incorrect  !");
        }
    }
}

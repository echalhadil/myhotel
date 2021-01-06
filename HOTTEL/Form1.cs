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
    public partial class Form1 : Form
    {
        public static int i = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Client_Click(object sender, EventArgs e)
        {
            Clients c = new Clients();
            c.Visible = true;
            this.Hide();
            
        }

        private void Reservation_Click(object sender, EventArgs e)
        {
            Reservations r = new Reservations();
           
            r.Visible = true;
            this.Hide();
        }

        private void Chambres_Click(object sender, EventArgs e)
        {
            Chambres ch = new Chambres();

            ch.Visible = true;
            this.Hide();

        }

        private void Restaurant_Click(object sender, EventArgs e)
        {
            Restaurant Rest = new Restaurant();

            Rest.Visible = true;
            this.Hide();


        }

        private void RoomService_Click(object sender, EventArgs e)
        {
            Services Rest = new Services();

            Rest.Visible = true;
            this.Hide();

        }

        private void Facture_Click(object sender, EventArgs e)
        {
            factures Rest = new factures();

            Rest.Visible = true;
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (i==1) {
                panel5.Visible = false;
            }
            else if (i == 0)
            {
                panel5.Visible = true;
            }

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
                panel5.Visible = false;
                i = 1;
            }
            else
                MessageBox.Show("Les Données est incorrect  !");
        }
    }
}

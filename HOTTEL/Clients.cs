using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace HOTTEL
{
    public partial class Clients : Form
    {
        private DataSet ds = new DataSet();
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private SqlDataAdapter Chambre_adapter;
        int i = 0;
        String id = "";
        public Clients()
        {
            InitializeComponent();
        }

        private void Clients_Load(object sender, EventArgs e)
        {
            SqlDataAdapter Chambre_adapter = new SqlDataAdapter("SELECT * FROM CLIENT", conn);
            Chambre_adapter.Fill(ds, "Clients");
            ClientsG.DataSource = ds;
            ClientsG.DataMember = "Clients";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchValue_TextChanged(object sender, EventArgs e)
        {
            if (SearchValue.Text != "CIN , Nom")
            {
                i++;
                Chambre_adapter = new SqlDataAdapter("SELECT * FROM CLIENT WHERE CIN LIKE '%" + SearchValue.Text + "%' or Nom LIKE '%" + SearchValue.Text + "%' or  Prenom LIKE '%" + SearchValue.Text + "%'", conn);
                Chambre_adapter.Fill(ds, "Clients" + i.ToString());
                ClientsG.DataSource = ds;
                ClientsG.DataMember = "Clients" + i.ToString();
            }
            else
            {
                ClientsG.DataSource = ds;
                ClientsG.DataMember = "Clients";

            }
        }

        private void SearchValue_Click(object sender, EventArgs e)
        {
            if (SearchValue.Text == "CIN , Nom")
                SearchValue.Text = "";
        }

        private void SearchValue_Leave(object sender, EventArgs e)
        {
            if (SearchValue.Text == "")
                SearchValue.Text = "CIN , Nom";
        }

        private void Retour_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Visible = true;
        }

        private void Button5_Click(object sender, EventArgs e)
        {

        }

        private void SupprimerC_Click(object sender, EventArgs e)
        {
          
            int i;
            i = ClientsG.CurrentCell.RowIndex;
            ClientsG.Rows.RemoveAt(i);
            
                MessageBox.Show("le Client est bien supprimer !");
            //}
        }
        private void Button4_Click(object sender, EventArgs e)
        {

            int i;
            i = ClientsG.CurrentCell.RowIndex;

            AjouterP.Visible = true;
            AccueilP.Visible = false;

            button4.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
           




            ////////
            Nom.Text = ClientsG.Rows[i].Cells[1].Value.ToString();
            Prenom.Text = ClientsG.Rows[i].Cells[2].Value.ToString();
            DateNaissance.Text = Convert.ToDateTime(ClientsG.Rows[i].Cells[3].Value).ToString("dd-MM-yyyy");
            CIN.Text = ClientsG.Rows[i].Cells[4].Value.ToString();
            Sexe.Text = ClientsG.Rows[i].Cells[5].Value.ToString();
            Telephone.Text = ClientsG.Rows[i].Cells[6].Value.ToString();
            Email.Text = ClientsG.Rows[i].Cells[7].Value.ToString();
            Address.Text = ClientsG.Rows[i].Cells[8].Value.ToString();
            
        }

        private void AjouterP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnregistrerReservation_Click(object sender, EventArgs e)
        {
            MessageBox.Show("modifier avec seccess !");
            AjouterP.Visible = false;
            AccueilP.Visible = true;
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            AccueilP.Visible = true;

            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            AccueilP.Visible = true;
        }
    }
}

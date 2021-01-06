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
    public partial class Services : Form
    {
        int i = 0;
        private SqlDataAdapter services_adapter;
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private DataSet ds = new DataSet();
        public Services()
        {
            InitializeComponent();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            services_adapter = new SqlDataAdapter("SELECT NomEmploye,PrenomEmploye,ServiceLibelle ,idClient='1003' from EMPLOYE E,SERVICES S WHERE E.IdService= S.IdService and s.IdService = 2", conn);
            services_adapter.Fill(ds, "services");
            ServicesG.DataSource = ds;
            ServicesG.DataMember = "services";
        }

        private void SearchValue_TextChanged(object sender, EventArgs e)
        {
            if (SearchValue.Text != "Nom d'Employe")
            {
                i++;
                services_adapter = new SqlDataAdapter("SELECT NomEmploye,PrenomEmploye,ServiceLibelle ,idClient='1003' from EMPLOYE E,SERVICES S WHERE E.IdService= S.IdService AND s.IdService =2 AND NomEmploye LIKE'%" + SearchValue.Text + " %'", conn);
                services_adapter.Fill(ds, "services" + i.ToString());
                ServicesG.DataSource = ds;
                ServicesG.DataMember = "services" + i.ToString();
            }
            else
            {
                ServicesG.DataSource = ds;
                ServicesG.DataMember = "services";

            }
        }

        private void SearchValue_Leave(object sender, EventArgs e)
        {
            if (SearchValue.Text == "")
                SearchValue.Text = "Nom d'Employe";
        }


        private void SearchValue_Click(object sender, EventArgs e)
        {
            if (SearchValue.Text == "Nom d'Employe")
                SearchValue.Text = "";

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int i = ServicesG.CurrentCell.RowIndex;
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            Nom.Text = ServicesG.Rows[i].Cells[0].Value.ToString();
            Prenom.Text = ServicesG.Rows[i].Cells[1].Value.ToString();
            NomDeService.Text = ServicesG.Rows[i].Cells[2].Value.ToString();
            IdClient.Text = ServicesG.Rows[i].Cells[3].Value.ToString();
        }

        private void AjouterR_Click(object sender, EventArgs e)
        {
            Nom.Text = "Nom";
            Prenom.Text = "Prenom";
            NomDeService.Text = "Nom De Service";
            IdClient.Text = "Id De Client";
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            AjouterR.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            
        }

        private void RAnnuler_Click(object sender, EventArgs e)
        {
            int i;
            i = ServicesG.CurrentCell.RowIndex;
            ServicesG.Rows.RemoveAt(i);
            MessageBox.Show("service est bien supprimer !");
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Nom.Text = "Nom";
            Prenom.Text = "Prenom";
            NomDeService.Text = "Nom De Service";
            IdClient.Text = "Id De Client";
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            ModifierCh.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            ModifierCh.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void EnregistrerChambre_Click(object sender, EventArgs e)
        {
            if (Nom.Text == "Nom" || Prenom.Text == "Prenom" || NomDeService.Text == "Nom De Service" || IdClient.Text == "Id De Client")
            {
                MessageBox.Show("Tout Les Champes est Obligatoire ! ");
            }
            else
            {
                MessageBox.Show("enregistre aves seccess ! ");
                ModifierCh.Visible = true;
                AjouterP.Visible = false;
            }
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Visible = true;
        }

        private void Nom_Leave(object sender, EventArgs e)
        {
            if (Nom.Text == "")
                Nom.Text = "Nom";
        }

        private void Nom_Click(object sender, EventArgs e)
        {
            if (Nom.Text == "Nom")
                Nom.Text = "";
        }

        private void Prenom_Leave(object sender, EventArgs e)
        {
            if (Nom.Text == "")
                Nom.Text = "Pre,om";
        }

        private void Prenom_Click(object sender, EventArgs e)
        {
            if (Nom.Text == "Prenom")
                Nom.Text = "";
        }
    }
}

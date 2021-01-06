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
    public partial class factures : Form
    {
        int i = 0;
        private SqlDataAdapter Facture_adapter;
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private DataSet ds = new DataSet();
        public factures()
        {
            InitializeComponent();
        }

        private void Factures_Load(object sender, EventArgs e)
        {
            Facture_adapter = new SqlDataAdapter("SELECT * FROM FACTURE", conn);
            Facture_adapter.Fill(ds, "factures");
            FacturesG.DataSource = ds;
            FacturesG.DataMember = "factures";

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void AjouterR_Click(object sender, EventArgs e)
        {
            IdFacture.Text = "Id De Facture";
            Montant.Text = "Montant";
            IdClient.Text = "Montant";
            IdChambre.Text = "Id De Chambre";
            IdReservation.Text = "Id De Reservation";
            Telephone.Text = "Telephone";
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            AjouterR.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int i = FacturesG.CurrentCell.RowIndex;
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            IdFacture.Text = FacturesG.Rows[i].Cells[0].Value.ToString();
            Montant.Text = FacturesG.Rows[i].Cells[3].Value.ToString();
            IdClient.Text = FacturesG.Rows[i].Cells[3].Value.ToString();
            IdChambre.Text = FacturesG.Rows[i].Cells[3].Value.ToString();
            IdReservation.Text = FacturesG.Rows[i].Cells[3].Value.ToString();
            Telephone.Text = FacturesG.Rows[i].Cells[3].Value.ToString();

        }

        private void RAnnuler_Click(object sender, EventArgs e)
        {
            int i;
            i = FacturesG.CurrentCell.RowIndex;
            FacturesG.Rows.RemoveAt(i);
            MessageBox.Show("Facture est bien supprimer !");
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            ModifierCh.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            ModifierCh.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void EnregistrerChambre_Click(object sender, EventArgs e)
        {
            if (IdFacture.Text == "Id De Facture"||Montant.Text == "Montant"||IdClient.Text == "Montant"||IdChambre.Text == "Id De Chambre"||IdReservation.Text == "Id De Reservation"|| Telephone.Text == "Telephone")
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

        private void Button7_Click(object sender, EventArgs e)
        {
            IdFacture.Text = "Id De Facture";
            Montant.Text = "Montant";
            IdClient.Text = "Montant";
            IdChambre.Text = "Id De Chambre";
            IdReservation.Text = "Id De Reservation";
            Telephone.Text = "Telephone";
        }
    }
}

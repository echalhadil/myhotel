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
    public partial class Restaurant : Form
    {
        int i = 0;
        private SqlDataAdapter Restaurant_adapter ;
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private DataSet ds = new DataSet();
        public Restaurant()
        {
            InitializeComponent();
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Restaurant_Load(object sender, EventArgs e)
        {
            Restaurant_adapter = new SqlDataAdapter("SELECT ChefNome, ChefPrenome, NomRepas, IdClient, DateDem FROM REPAS R, CUISINE C  WHERE R.NomREpas = C.RepasSpecial", conn);
            Restaurant_adapter.Fill(ds, "Restaurant");
            RestaurantG.DataSource = ds;
            RestaurantG.DataMember = "Restaurant";
        }

        private void SearchValue_TextChanged(object sender, EventArgs e)
        {
            if (SearchValue.Text != "Nom de Chef")
            {
                i++;
                Restaurant_adapter = new SqlDataAdapter("SELECT ChefNome,ChefPrenome,NomRepas,IdClient,DateDem FROM REPAS R,CUISINE C  WHERE R.NomREpas = C.RepasSpecial AND ChefNome LIKE '%" + SearchValue.Text + "%'", conn);
                Restaurant_adapter.Fill(ds, "rest" + i.ToString());
                RestaurantG.DataSource = ds;
                RestaurantG.DataMember = "rest" + i.ToString();
            }
            else
            {
                RestaurantG.DataSource = ds;
                RestaurantG.DataMember = "Restaurant";

            }
            

        }

        private void SearchValue_Leave(object sender, EventArgs e)
        {
            if (SearchValue.Text == "")
                SearchValue.Text = "Nom de Chef";

        }

        private void SearchValue_Click(object sender, EventArgs e)
        {
            if (SearchValue.Text == "Nom de Chef")
                SearchValue.Text = "";
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Visible = true;
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            NomDeRepas.Text = "Nom De Repas";
            IdClient.Text = "Id De Client";
            DateDem.Text = "";
        }

        private void AjouterR_Click(object sender, EventArgs e)
        {
            NomDeRepas.Text = "Nom De Repas";
            IdClient.Text = "Id De Client";
            DateDem.Text = "";
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            AjouterR.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);

        }

        private void RAnnuler_Click(object sender, EventArgs e)
        {
            int i;
            i = RestaurantG.CurrentCell.RowIndex;
            RestaurantG.Rows.RemoveAt(i);
            MessageBox.Show("le Repas est bien supprimer !");
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            ModifierCh.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            int i = RestaurantG.CurrentCell.RowIndex; 
            AjouterP.Visible = true;
            ModifierCh.Visible = false;
            NomDeRepas.Text = RestaurantG.Rows[i].Cells[2].Value.ToString();
            IdClient.Text = RestaurantG.Rows[i].Cells[3].Value.ToString();
            DateDem.Text = Convert.ToDateTime(RestaurantG.Rows[i].Cells[4].Value).ToString("dd-MM-yyyy");
           
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
            if(NomDeRepas.Text == "Nom De Repas"||NomDeRepas.Text == "Id De Client"||DateDem.Text == "")
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

        private void AjouterP_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}

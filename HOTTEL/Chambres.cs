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
    public partial class Chambres : Form
    {
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private SqlDataAdapter Chambre_search;
        String id;
        int j;
        int i = 0;
        private DataSet ds = new DataSet();
        public Chambres()
        {
            InitializeComponent();
        }

        private void ModifierCh_Paint(object sender, PaintEventArgs e)
        {

        }

        

        private void Button8_Click(object sender, EventArgs e)
        {
            if (button8.Text == "Modifier")
            {

                int j;
                j = dataGridView1.CurrentCell.RowIndex;
                //id = dataGridView1.SelectedRows[j].Cells[0].Value.ToString();
                SqlCommand delcmd = new SqlCommand();
                //if (dataGridView1.Rows.Count > 1 && i != dataGridView1.Rows.Count - 1)
                //{

                //    
                //    
                //    delcmd.CommandText = "SELECT * FROM CHAMBRE WHERE  IdChambre =" + dataGridView1.SelectedRows[j].Cells[0].Value.ToString() + "";


                //    conn.Open();
                //    delcmd.Connection = conn;
                //    delcmd.ExecuteNonQuery();
                //    conn.Close();

                ////////
                AjouterP.Visible = true;
                ModifierCh.Visible = false;
                TypeDeChambre.Text = dataGridView1.Rows[j].Cells[1].Value.ToString();
                NumeroChambre.Text = dataGridView1.Rows[j].Cells[2].Value.ToString();
                Telephone.Text = dataGridView1.Rows[j].Cells[3].Value.ToString();
                Etage.Text = dataGridView1.Rows[j].Cells[4].Value.ToString();



                    ///////
                //}
            }
            if (button8.Text == "Supprimer")
            {

                int j;
                j = dataGridView1.CurrentCell.RowIndex;
               // SqlCommand delcmd = new SqlCommand();
               // if (dataGridView1.Rows.Count > 1 && i != dataGridView1.Rows.Count - 1)
               // {
                   // delcmd.CommandText = "Delete FROM CHAMBRE WHERE IdChambre =" + dataGridView1.SelectedRows[i].Cells[0].Value.ToString() + "";
                   // conn.Open();
                   // delcmd.Connection = conn;
                   //delcmd.ExecuteNonQuery();
                   // conn.Close();
                    dataGridView1.Rows.RemoveAt(dataGridView1.Rows[i].Index);
                    MessageBox.Show("Chambre est bien supprimer !");

               // }
            }
        }

        private void Chambres_Load(object sender, EventArgs e)

        {
            AccueilP.Visible = true;
            AjouterP.Visible = false;
            ModifierCh.Visible = false;

            SqlDataAdapter Chambre_adapter = new SqlDataAdapter("SELECT * FROM CHAMBRE", conn);
            Chambre_adapter.Fill(ds, "Chambres");
            ChambresG.DataSource = ds;
            ChambresG.DataMember = "Chambres";
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Chambres";
            conn.Open();
            SqlCommand NbrChambreD = new SqlCommand("SELECT COUNT(*) FROM CHAMBRE WHERE StatuChambre = 'Disponible'", conn);
            Int32 count1 = Convert.ToInt32(NbrChambreD.ExecuteScalar());
            if (count1 > 0)
            {
                nbrcnr.Text = Convert.ToString(count1.ToString()); 
            }
            else
            {
                nbrcnr.Text = "0";
            }

            SqlCommand NbrChambreND = new SqlCommand("SELECT COUNT(*) FROM CHAMBRE WHERE StatuChambre = 'Indisponible'", conn);
            Int32 count2 = Convert.ToInt32(NbrChambreND.ExecuteScalar());
            if (count2 > 0)
            {
                nbrcr.Text = Convert.ToString(count2.ToString()); 
            }
            else
            {
                nbrcr.Text = "0";
            }

            conn.Close();
        }
        private void DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Chambres";
        }

        private void AjouterR_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(42, 39, 51);
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.Gray;
            AjouterP.Visible = true;
            panel5.Visible = false;
            AccueilP.Visible = false;
            ModifierCh.Visible = false;
            TypeDeChambre.Text = "Type De Chambre";
            NumeroChambre.Text = "Numero De Chambre";
            Telephone.Text = "Telephone";
            Etage.Text = "Etage";

        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
            AjouterP.Visible = false;
            AccueilP.Visible = true;
            ModifierCh.Visible = false;
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            AccueilP.Visible = false;
            ModifierCh.Visible = true;
            button4.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
            AjouterP.Visible = false;
            panel5.Visible = false;
            ModifierCh.Visible = true;
            button8.Text = "Modifier";
        }

        private void RAnnuler_Click(object sender, EventArgs e)
        {
            button4.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);

            AjouterP.Visible = false;
            AccueilP.Visible = false;
            ModifierCh.Visible = true;
            button8.Text = "Supprimer";
        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void SearchValue_TextChanged(object sender, EventArgs e)
        {
            if (SearchValue.Text != "ID")
            {
                i++;
                Chambre_search = new SqlDataAdapter("SELECT * FROM CHAMBRE  WHERE IdChambre LIKE '%" + SearchValue.Text + "%'", conn);
                Chambre_search.Fill(ds, "Chambre" + i.ToString());
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Chambre" + i.ToString();

            }
            else
            {
                dataGridView1.DataSource = ds;
                dataGridView1.DataMember = "Chambres";

            }
        }

        private void AjouterP_Paint(object sender, PaintEventArgs e)
        {


        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            this.Hide();
            a.Visible = true;

            
        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            ModifierCh.Visible = true;
            AccueilP.Visible = true;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button9_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            ModifierCh.Visible = true;
            AccueilP.Visible = true;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            TypeDeChambre.Text = "Type De Chambre";
            NumeroChambre.Text = "Numero De Chambre";
            Telephone.Text = "Telephone";
            Etage.Text = "Etage";

        }

        private void EnregistrerChambre_Click(object sender, EventArgs e)
        {
            if(TypeDeChambre.Text == "Type De Chambre"||NumeroChambre.Text == "Numero"||Telephone.Text == "Telephone"||Etage.Text == "Etage"){
                MessageBox.Show("tous les champes est obligatoire ! ");
            }
            else
            {

                MessageBox.Show("enregistre avec seccess ! ");
                Accueil.BackColor = Color.Gray;
                button4.BackColor = Color.FromArgb(42, 39, 51);
                AjouterR.BackColor = Color.FromArgb(42, 39, 51);
                RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
                AjouterP.Visible = false;
                AccueilP.Visible = true;
                ModifierCh.Visible = false;
            }
        }

        private void SearchValue_Click(object sender, EventArgs e)
        {
            if (SearchValue.Text == "ID")
                SearchValue.Text = "";
        }

        private void SearchValue_Leave(object sender, EventArgs e)
        {
            if (SearchValue.Text == "")
                SearchValue.Text = "ID";
        }

        private void NumeroChambre_Click(object sender, EventArgs e)
        {
            if (NumeroChambre.Text == "Numero De Chambre")
                NumeroChambre.Text = "";
        }

        private void NumeroChambre_Leave(object sender, EventArgs e)
        {
            if (NumeroChambre.Text == "")
                NumeroChambre.Text = "Numero De Chambre";
        }

        private void TypeDeChambre_Leave(object sender, EventArgs e)
        {
            if (TypeDeChambre.Text == "")
                TypeDeChambre.Text = "Type De Chambre";
        }

        private void TypeDeChambre_Click(object sender, EventArgs e)
        {
            if (TypeDeChambre.Text == "Type De Chambre")
                TypeDeChambre.Text = "";

        }

        private void Etage_Leave(object sender, EventArgs e)
        {
            if (Etage.Text == "")
                Etage.Text = "Etage";

        }

        private void Etage_Click(object sender, EventArgs e)
        {
            if (Etage.Text == "Etage")
                Etage.Text = "";
        }

        private void Telephone_Leave(object sender, EventArgs e)
        {
            if (Telephone.Text == "")
                Telephone.Text = "Telephone";
        }

        private void Telephone_Click(object sender, EventArgs e)
        {
            if (Telephone.Text == "Telephone")
                Telephone.Text = "";
        }
    }
}

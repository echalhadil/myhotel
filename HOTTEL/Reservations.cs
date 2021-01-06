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
    
    public partial class Reservations : Form
    {
        int i = 0;
        String id = "";
        private SqlConnection conn = new SqlConnection("Data Source =.; Initial Catalog = HOTEL ; Integrated Security = true;");
        private SqlDataAdapter Reservation_Adapt;
        private SqlDataAdapter Reservation_search;
        int RowIndex;
        //private SqlDataAdapter Chambre_Adapt;
        //private SqlDataAdapter Restaurant_Adapt;
        private DataSet ds = new DataSet();
        public Reservations()
        {
            InitializeComponent();
        }

        private void ModifierP_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchValue_TextChanged(object sender, EventArgs e)
        {
            if (SearchValue.Text != "CIN , Nom")
            {
                i++;
                Reservation_search = new SqlDataAdapter("SELECT R.IdReservation,R.IdClient,C.Nom,C.Prenom,C.DateNaissance,C.CIN,C.Sexe,C.Telephone,C.Mail,C.Address,Ca.Libelle,CH.IdChambre,CH.EtageChambre,R.DateDebut,R.DateFin FROM RESERVATION R, CLIENT C, CATEGORIE Ca, CHAMBRE CH WHERE CH.TypeChambre = Ca.IdCategorie AND C.IdClient = R.IdClient AND CH.IdChambre = R.IdChambre AND C.CIN LIKE '%" + SearchValue.Text + "%' or Nom LIKE '%" + SearchValue.Text + "%' or  Prenom LIKE '%" + SearchValue.Text + "%'", conn);
                Reservation_search.Fill(ds, "Reservation" + i.ToString());
                ChambreM.DataSource = ds;
                ChambreM.DataMember = "Reservation" + i.ToString();
            }
            else
            {
                ChambreM.DataSource = ds;
                ChambreM.DataMember = "Reservation";

            }

        }

        private void Close_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void EnregistrerReservation_Click(object sender, EventArgs e)
        {
            string a = "111" + i.ToString();
            bool valide = true;
            if (String.Compare(dateIn.ToString(), dateOut.ToString()) <= 0)
                valide = false;
            if (Nom.Text == "Nom" || Prenom.Text == "Prenom" || CIN.Text == "CIN" || Address.Text == "Address" ||
                Telephone.Text == "Telephone" || Email.Text == "Email" || Sexe.Text == "Sexe" ||
                DateNaissance.Text == "" || TypeDeChambre.Text == "" || NumeroChambre.Text == "" ||
                Etage.Text == "" || dateIn.Text == "" || dateOut.Text == "")
            {
                valide = false;
                MessageBox.Show("Tous Les Champes est Obligatoire ! ");
            }
            else if(dateIn.Text ==  dateOut.Text)
            {
                valide = false;
                MessageBox.Show(" la date de Entre doit etre Inferieur a la date de Sortie ! ");
            }
            
            else {
                i++;
                //DataRow r;
                //r = ds.Tables["Reservation"].NewRow();
                //r[0] = a.Trim();
                //r[1] = Nom.Text.Trim();
                //r[1] = Prenom.Text.Trim();
                //r[2] = CIN.Text.Trim();
                //r[3] = Address.Text.Trim(); ;
                //r[4] = Telephone.Text.Trim();
                //r[5] = Email.Text.Trim();
                //r[6] = TypeDeChambre.Text.Trim();
                //ds.Tables["Reservation"].Rows.Add(r);
                //Reservation_Adapt.Update(ds, "Reservation");
                //ds.Tables["Reservation"].AcceptChanges();
                ChambreM.Refresh();
                MessageBox.Show("Enregistrement ajouté");
            }


            //if (id == "" && valide == true)
            //{
                //conn.Open();
                //SqlCommand ajoutR = new SqlCommand();
                //SqlCommand ajoutC = new SqlCommand();
                //ajoutC.CommandText = "INSERT INTO CLIENT VALUES('" + Nom.Text + "','" + Prenom.Text + "','" + DateNaissance.Text + "','" + Sexe.Text + "','" + CIN.Text + "','" + Email.Text + "','" + Telephone.Text + ",'" + Address.Text + "')";
                //ajoutC.Connection = conn;
                //ajoutC.ExecuteNonQuery();

                //SqlCommand NbrChambre = new SqlCommand("SELECT top 1 IdClient FROM Client ORDER BY IdClient DESC", conn);
                //String Idclient = Convert.ToString(NbrChambre.ExecuteScalar());

                //ajoutR.CommandText = "INSERT INTO RESERVATION VALUES ('" + NumeroChambre.Text + "','" + Idclient + "','" + dateIn.Value.Date + "','" + dateOut.Value.Date + "','0')";
                //ajoutR.Connection = conn;
                //ajoutR.ExecuteNonQuery();
                //MessageBox.Show("hehehehe");
                //conn.Close();

            //}
            //if (id != "" && valide == true)
            //{
            //    conn.Open();
            //    SqlCommand ModifierR = new SqlCommand();
            //    ModifierR.CommandText = " UPDATE RESERVATION SET IdChambre ='" + NumeroChambre.Text + "' ,DateDebut = " + dateIn.Value.Date + ",DateFin = " + dateOut.Value.Date + "  WHERE IdReservation = '" + id + "'";
            //    ModifierR.Connection = conn;
            //    ModifierR.ExecuteNonQuery();
            //    conn.Close();
            //    MessageBox.Show("le Reservation a ete Modifier avec Seccess  ! ");
            //}
        }

        private void AjouterR_Click(object sender, EventArgs e)
        {
            Nom.Text = "Nom";
            Prenom.Text = "Prenom";
            CIN.Text = "CIN";
            Address.Text = "Address";
            Telephone.Text = "Telephone";
            Email.Text = "Email";
            Sexe.Text = "Sexe";
            DateNaissance.Text = "";
            TypeDeChambre.Text = "Type";
            NumeroChambre.Text = "Numero";
            Etage.Text = "Etage";
            dateIn.Text = "";
            dateOut.Text = "";
            Nom.Text = "Nom";
            AjouterP.Visible = true;
            ModifierP.Visible = false;
           AccueilP.Visible = false;
            AjouterR.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
             AccueilP.Visible = false;
            ModifierP.Visible = true;
            button4.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.FromArgb(42, 39, 51);
            button2.Text = "Modifier";
        }

        private void RAnnuler_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            AccueilP.Visible = false;
            ModifierP.Visible = true;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            RAnnuler.BackColor = Color.Gray;
            Accueil.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
            button2.Text = "Supprimer";
        }

        private void Accueil_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            ModifierP.Visible = false;
           AccueilP.Visible = true;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "Modifier")
            {
                
                
                SqlCommand delcmd = new SqlCommand();
                if (ChambreM.Rows.Count > 1 && i != ChambreM.Rows.Count - 1)
                {
                    int j;
                    j = ChambreM.CurrentCell.RowIndex;
                   
                    id = ChambreM.Rows[j].Cells[0].Value.ToString();

                    AjouterP.Visible = true;
                    ModifierP.Visible = false;
                    //delcmd.CommandText = "SELECT R.IdReservation,C.Nom,C.Prenom,C.DateNaissance,C.CIN,C.Sexe,C.Telephone,C.Mail,C.Address,Ca.Libelle,CH.IdChambre,CH.EtageChambre,R.DateDebut,R.DateFin FROM" +
                     //   " RESERVATION R, CLIENT C, CATEGORIE Ca, CHAMBRE CH " +
                       // "WHERE CH.TypeChambre = Ca.Libelle AND C.IdClient = R.IdClient AND CH.IdChambre = R.IdChambre  AND R.IdReservation =" + ChambreM.SelectedRows[j].Cells[0].Value.ToString() + "";


                    //conn.Open();
                    //delcmd.Connection = conn;
                    //delcmd.ExecuteNonQuery();
                    //conn.Close();

                    ////////
                    Nom.Text = ChambreM.Rows[j].Cells[1].Value.ToString();
                    Prenom.Text = ChambreM.Rows[j].Cells[2].Value.ToString();
                    DateNaissance.Text = Convert.ToDateTime(ChambreM.Rows[i].Cells[3].Value).ToString("dd-MM-yyyy");
                    CIN.Text = ChambreM.Rows[j].Cells[4].Value.ToString();
                    Sexe.Text = ChambreM.Rows[j].Cells[5].Value.ToString();
                    Telephone.Text = ChambreM.Rows[j].Cells[6].Value.ToString();
                    Email.Text = ChambreM.Rows[j].Cells[7].Value.ToString();
                    Address.Text = ChambreM.Rows[j].Cells[8].Value.ToString();
                    TypeDeChambre.Text = ChambreM.Rows[j].Cells[9].Value.ToString();
                    NumeroChambre.Text = ChambreM.Rows[j].Cells[10].Value.ToString();
                    Etage.Text = ChambreM.Rows[j].Cells[11].Value.ToString();
                    dateIn.Text = ChambreM.Rows[j].Cells[12].Value.ToString();
                    dateOut.Text = ChambreM.Rows[j].Cells[12].Value.ToString();




                    ///////
                }
            }
            if (button2.Text == "Supprimer")
            {
                int i;
                i = ChambreM.SelectedCells[0].RowIndex;
                SqlCommand delcmd = new SqlCommand();
                if (ChambreM.Rows.Count > 1 && i != ChambreM.Rows.Count - 1)
                {
                    //delcmd.CommandText = "Delete FROM RESERVATION WHERE IdReservation =" + ChambreM.SelectedRows[i].Cells[0].Value.ToString() + "";
                    //conn.Open();
                    //delcmd.Connection = conn;
                    //delcmd.ExecuteNonQuery();
                    //conn.Close();
                    ChambreM.Rows.RemoveAt(ChambreM.Rows[i].Index);
                    MessageBox.Show("la reservation est bien supprimer !");

                }
            }
        }

        private void Reservations_Load(object sender, EventArgs e)
        {
           
            conn.Open();
            Reservation_Adapt = new SqlDataAdapter("SELECT R.IdReservation,C.Nom,C.Prenom,C.DateNaissance,C.CIN,C.Sexe,C.Telephone,C.Mail,C.Address,Ca.Libelle,CH.IdChambre,CH.EtageChambre,R.DateDebut,R.DateFin FROM" +
                        " RESERVATION R, CLIENT C, CATEGORIE Ca, CHAMBRE CH " +
                        "WHERE CH.TypeChambre = Ca.Libelle AND C.IdClient = R.IdClient AND CH.IdChambre = R.IdChambre ", conn);
            Reservation_Adapt.Fill(ds, "Reservation");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "Reservation";
            ChambreM.DataSource = ds;
            ChambreM.DataMember = "Reservation";



            //calculer Les Reservations
            SqlCommand NbrRes = new SqlCommand("SELECT COUNT(*) FROM RESERVATION", conn);
            Int32 count1 = Convert.ToInt32(NbrRes.ExecuteScalar());
            if (count1 > 0)
            {
                NombreReservation.Text = Convert.ToString(count1.ToString()); //For example a Label
            }
            else
            {
                NombreReservation.Text = "0";
            }

            //Calculer Les Chambres Disponibles

            SqlCommand NbrChambre = new SqlCommand("SELECT COUNT(*) FROM CHAMBRE WHERE StatuChambre = 'Disponible'", conn);
            Int32 count2 = Convert.ToInt32(NbrChambre.ExecuteScalar());
            if (count2 > 0)
            {
                ChambreDisponible.Text = Convert.ToString(count2.ToString()); //For example a Label
            }
            else
            {
                ChambreDisponible.Text = "0";
            }

            conn.Close();
        }

        private void SearchValue_TextChanged_1(object sender, EventArgs e)
        {
            if (SearchValue.Text != "CIN , Nom")
            {
                i++;
                Reservation_search = new SqlDataAdapter("SELECT R.IdReservation,R.IdClient,C.Nom,C.Prenom,C.DateNaissance,C.CIN,C.Sexe,C.Telephone,C.Mail,C.Address,Ca.Libelle,CH.IdChambre,CH.EtageChambre,R.DateDebut,R.DateFin FROM RESERVATION R, CLIENT C, CATEGORIE Ca, CHAMBRE CH WHERE CH.TypeChambre = Ca.Libelle AND C.IdClient = R.IdClient AND CH.IdChambre = R.IdChambre AND C.CIN LIKE '%" + SearchValue.Text + "%' or Nom LIKE '%" + SearchValue.Text + "%' or  Prenom LIKE '%" + SearchValue.Text + "%'", conn);
                Reservation_search.Fill(ds, "Reservation" + i.ToString());
                ChambreM.DataSource = ds;
                ChambreM.DataMember = "Reservation" + i.ToString();
            }
            else
            {
                ChambreM.DataSource = ds;
                ChambreM.DataMember = "Reservation";

            }
        }

        private void Vider_Click(object sender, EventArgs e)
        {
            Prenom.Text = "Prenom";
            CIN.Text = "CIN";
            Address.Text = "Address";
            Telephone.Text = "Telephone";
            Email.Text = "Email";
            Sexe.Text = "Sexe";
            DateNaissance.Text = "";
            TypeDeChambre.Text = "Type";
            NumeroChambre.Text = "Numero";
            Etage.Text = "Etage";
            dateIn.Text = "";
            dateOut.Text = "";
            Nom.Text = "Nom";
        }

        private void NumeroChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Details();
        }

        private void Details()
        {
            label2.ForeColor = Color.FromArgb(58, 88, 255);
            label4.ForeColor = Color.FromArgb(58, 88, 255);
            label1.ForeColor = Color.Silver;
            label5.ForeColor = Color.Silver;
        }

        private void Etage_SelectedIndexChanged(object sender, EventArgs e)
        {
            Details();

        }

        private void DateOut_ValueChanged(object sender, EventArgs e)
        {
            Details();

        }

        private void TypeDeChambre_SelectedIndexChanged(object sender, EventArgs e)
        {
            Details();

        }

        private void DateIn_ValueChanged(object sender, EventArgs e)
        {
            Details();

        }

        private void Annuler_Click(object sender, EventArgs e)
        {
            AccueilP.Visible = true;
            AjouterP.Visible = false;
            Accueil.BackColor = Color.Gray;
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Retour1_Click(object sender, EventArgs e)
        {

            Form1 a = new Form1();
            this.Hide();
            a.Visible = true;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            AjouterP.Visible = false;
            ModifierP.Visible = false;
            AccueilP.Visible = true;
            Accueil.BackColor = Color.Gray;
            button4.BackColor = Color.FromArgb(42, 39, 51);
            AjouterR.BackColor = Color.FromArgb(42, 39, 51);
        }

        private void Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void SearchValue_Leave(object sender, EventArgs e)
        {
            
            if (SearchValue.Text == "")
                SearchValue.Text = "CIN , Nom";
        }

        private void SearchValue_Click(object sender, EventArgs e)
        {
            if (SearchValue.Text == "CIN , Nom")
                SearchValue.Text = "";
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GestionCongee.GUI.AdminGUI
{
    public partial class Historique : Form
    {
        

        gs_CongeeDataContext db;
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        public static int bureauId { get; set; } 
        public static string etatGlobale { get; set; } 

        public Historique()
        {
            InitializeComponent();
            Console.WriteLine("Bonjour ddddddddddddddddddd");
            db = new gs_CongeeDataContext();
            tabledata.DataBindingComplete += tabledata_DataBindingComplete;

        }

        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chercher_Click(object sender, EventArgs e)
        {
            // Récupérez le nom du bureau sélectionné
            string nomBureau = comBox.SelectedItem.ToString();
            if (nomBureau == "Tout")
            {
                bureauId = -1;
            }
            else
            {
                bureauId = b.GetIdByNom(nomBureau);
            }


            DataTable dataTable = GetDataFromDatabase();
            tabledata.DataSource = dataTable;

        }

        private void RemplirComboBoxBureaux()
        {
            // Récupérez les noms des bureaux à partir du modèle de données LINQ
            var Bureaux = b.GetBureauFromDatabase();

            comBox.Items.Add("Tout");
            // Ajoutez les noms des bureaux à la ComboBox
            foreach (var nomBureau in Bureaux)
            {
                comBox.Items.Add(nomBureau.nomB);
            }

            // Sélectionnez le premier élément par défaut si la ComboBox n'est pas vide
            if (comBox.Items.Count > 0)
            {
                comBox.SelectedIndex = 0;
            }
        }


        public DataTable GetDataFromDatabase()
        {
            int nb_d = 0;
            List<demande> demandes;
            Console.Write(bureauId);
            Console.Write(etatGlobale);
            if (bureauId < 0 & etatGlobale=="None")
            {
                // Effectuez une requête LINQ pour récupérer les données de la table Demande avec les noms de personne
                demandes = d.GetAllDemandes();
            }
            else if (bureauId>0 & etatGlobale == "None")
            {
                demandes = d.GetDemandesBureauById(bureauId);
            }
            else if(etatGlobale!="None" & bureauId<0){
                demandes = d.GetDemandesByCondition(etatGlobale);
            }
            else
            {
                demandes = d.GetDemandesByConditionEB(etatGlobale, bureauId);
            }
            DataTable table = new DataTable();
            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Date de demande", typeof(DateTime));
            table.Columns.Add("Le demandeur", typeof(string));// Colonne pour l'ID
            table.Columns.Add("Date de début", typeof(DateTime)); // Colonne pour la date de début
            table.Columns.Add("Date de fin", typeof(DateTime)); // Colonne pour la date de fin
            
            table.Columns.Add("Certificat", typeof(string)); 
             // Colonne pour le nom et le prénom de la personne
            table.Columns.Add("Commentaire", typeof(string));
            table.Columns.Add("Etat", typeof(string));// Colonne pour le commentaire
                                                      // Colonne pour la date de demande
            
            personne p_id;
            // Parcourez les résultats de la requête et ajoutez-les au DataTable
            foreach (var demande in demandes)
            {
                nb_d++;
                p_id = p.GetPersonneById(demande.id_pers);
                // Concaténez le nom et le prénom de la personne dans une seule chaîne
                string nom_prenom_personne = $"{p_id.nom} {p_id.prenom}";
                table.Rows.Add(demande.id, demande.date_demande, nom_prenom_personne, demande.date_d, demande.date_f, demande.certificat, demande.commentaire, demande.etat);

            }

            total.Text = nb_d.ToString();
            return table;

        }

        private void Historique_Load(object sender, EventArgs e)
        {
            
            RemplirComboBoxBureaux();
            DataTable dataTable = GetDataFromDatabase();
            tabledata.DataSource = dataTable;
            
        }

        private void tabledata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void total_Click(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {
            HomeAdmin f = new HomeAdmin();
            f.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Historique.etatGlobale = "None";
            Historique.bureauId = -1;
            Historique f = new Historique();
            f.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            CompteAdmin F = new CompteAdmin();
            F.Show();
            this.Hide();
        }





        private void tabledata_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in tabledata.Rows)
            {
                // Récupérer la cellule de la colonne "Etat" pour la ligne actuelle
                DataGridViewCell etatCell = row.Cells["Etat"];

                // Vérifier si la cellule et sa valeur ne sont pas null
                if (etatCell != null && etatCell.Value != null)
                {
                    // Récupérer la valeur de l'état de la demande dans la cellule
                    string etatDemande = etatCell.Value.ToString();

                    // Appliquer le style en fonction de l'état de la demande
                    switch (etatDemande)
                    {
                        case "Accepter":
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cell.Style.BackColor = Color.LightGreen; // Fond vert clair
                                cell.Style.ForeColor = Color.Black; // Texte noir
                            }
                            break;
                        case "Refuser":
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cell.Style.BackColor = Color.LightSalmon; // Fond saumon clair
                                cell.Style.ForeColor = Color.Black; // Texte noir
                            }
                            break;
                        case "En cours":
                            // Vous pouvez personnaliser les couleurs de votre choix pour les demandes en cours
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cell.Style.BackColor = Color.LightYellow; // Fond jaune clair
                                cell.Style.ForeColor = Color.Black; // Texte noir
                            }
                            break;
                        default:
                            // Appliquer un style par défaut pour les autres états de demande
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                cell.Style.BackColor = Color.White; // Fond blanc
                                cell.Style.ForeColor = Color.Black; // Texte noir
                            }
                            break;
                    }
                }
                else
                {
                    // Si la cellule ou sa valeur sont null, appliquer un style par défaut
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        cell.Style.BackColor = Color.White; // Fond blanc
                        cell.Style.ForeColor = Color.Black; // Texte noir
                    }
                }
            }
        }


    }
}

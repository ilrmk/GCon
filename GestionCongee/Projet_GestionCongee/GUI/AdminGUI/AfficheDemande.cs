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
    public partial class AfficheDemande : Form
    {
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        public static int b_Id { get; set; }
        

        String etatGlobale="en cours";




        

        public AfficheDemande()
        {
            InitializeComponent();
            tabledata.CellContentClick += tabledata_CellContentClick;
            


        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login form2 = new Login();
            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Historique.etatGlobale = "None";
            Historique.bureauId = -1;
            Historique form2 = new Historique();
            form2.Show();
            this.Hide();
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AfficheDemande_Load(object sender, EventArgs e)
        {
            nom_b.Text ="Le département "+ b.GetBureauById(b_Id).nomB;
            total_p.Text = p.GetPersonnesByBureau(b_Id).Count().ToString();
            tatale_conge.Text = p.getPersonneConge(b_Id).Count().ToString();
            DataTable dataTable = GetDataFromDatabase();
            tabledata.DataSource = dataTable;
        }


        public DataTable GetDataFromDatabase()
        {
            int nb_d = 0;
            List<demande> demandes;
            Console.Write(b_Id);
            Console.Write(etatGlobale);
            
            demandes = d.GetDemandesByConditionEB(etatGlobale, b_Id);
            
            DataTable table = new DataTable();
            table.Columns.Add("id", typeof(int)); // Colonne pour l'ID
            table.Columns.Add("date_demande", typeof(DateTime)); // Colonne pour la date de demande
            table.Columns.Add("Le demandeur", typeof(string));
            table.Columns.Add("Le nombre de jours", typeof(int));
            table.Columns.Add("date_d", typeof(DateTime)); // Colonne pour la date de début
            table.Columns.Add("date_f", typeof(DateTime)); // Colonne pour la date de fin
            table.Columns.Add("etat", typeof(string)); // Colonne pour l'éta
          

            int nb_jour;
            personne p_id;
            // Parcourez les résultats de la requête et ajoutez-les au DataTable
            foreach (var demande in demandes)
            {
               
                nb_jour = (demande.date_f - demande.date_d).Days;
                nb_d++;
                p_id = p.GetPersonneById(demande.id_pers);
                // Concaténez le nom et le prénom de la personne dans une seule chaîne
                string nom_prenom_personne = $"{p_id.nom} {p_id.prenom}";
                table.Rows.Add(demande.id, demande.date_demande, nom_prenom_personne, nb_jour, demande.date_d, demande.date_f, demande.etat);
            }

            total.Text = nb_d.ToString();

            return table;

        }

        private void label16_Click(object sender, EventArgs e)
        {
            HomeAdmin form2 = new HomeAdmin();
            form2.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            CompteAdmin F = new CompteAdmin();
            F.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        // Gérez les clics sur les boutons
        private void tabledata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Vérifiez si la cellule cliquée est dans la colonne d'action
            if ( e.RowIndex >= 0)
            {
                // Récupérez l'ID de la demande à partir de la ligne sélectionnée
                int demandeId = Convert.ToInt32(tabledata.Rows[e.RowIndex].Cells["id"].Value);

                TraiterDemande.IdDemande = demandeId;
                TraiterDemande f =new  TraiterDemande();
                f.Show();
                this.Hide();

            }
        }
    }
}

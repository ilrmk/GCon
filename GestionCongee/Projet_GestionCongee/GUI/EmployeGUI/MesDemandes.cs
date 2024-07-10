using Projet_GestionCongee.Classe_Metier;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GestionCongee.GUI.EmployeGUI
{
    public partial class MesDemandes : Form
    {
  

        public personne returnPersonne()
        {
            int id = Personne.getId();
            Personne perS = new Personne();

            personne prsonne = perS.GetPersonneById(id);
            return prsonne;

        }
        private Color GetColorForState(string state)
        {
            switch (state)
            {
                case "en cours":
                    return Color.FromArgb(0, 102, 204);

                case "Accepter":
                    return Color.Green;
                default:
                    return Color.Red;
            }
        }

        private void remplireTableau()
        {
            dataGridView1.Columns.Add("Colonne1", "Némero");
            dataGridView1.Columns.Add("Colonne2", "Date de début");
            dataGridView1.Columns.Add("Colonne3", "Date fin");
            dataGridView1.Columns.Add("Colonne4", "Type");
            dataGridView1.Columns.Add("Colonne5", "Nombre de jour");
            dataGridView1.Columns.Add("Colonne6", "Décision");
            int id = Personne.getId();
            Demande de = new Demande();
            List<demande> demandes = de.GetDemandesEmploye(id);

            foreach (var demande in demandes)
            {
                int rowIndex = dataGridView1.Rows.Add(
                    demande.id,
                    demande.date_d,
                    demande.date_f,
                    demande.type,
                    demande.date_demande,
                    demande.etat

                );

                DataGridViewRow row = dataGridView1.Rows[rowIndex]; // Obtenez la ligne actuellement ajoutée

                row.DefaultCellStyle.BackColor = GetColorForState(demande.etat); // Définissez la couleur de fond en fonction de l'état de la demande
                row.DefaultCellStyle.ForeColor = Color.White;


            }
        }


        public MesDemandes()
        {
            InitializeComponent();
            int id = Personne.getId();
            Console.WriteLine("hhhhhh" + id);


            Personne per = new Personne();

            personne pers = per.GetPersonneById(id);
            if (pers != null)
            {
                NomU.Text = pers.nom + " " + pers.prenom;
                Console.Write(pers.nom + " " + pers.prenom);
                NomU.Visible = true;
            }
            remplireTableau();
        }

      

     

        

        private void label5_Click(object sender, EventArgs e)
        {
            Home form2 = new Home();

            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MesDemandes form2 = new MesDemandes();

            form2.Show();
            this.Hide();
        }

        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();

        }

        

        private void label3_Click(object sender, EventArgs e)
        {
            Compte form2 = new Compte();

            form2.Show();
            this.Hide();
        }

        private void MesDemandes_Load(object sender, EventArgs e)
        {

        }

        private void chercherDe_Click(object sender, EventArgs e)
        {

        }
    }
}

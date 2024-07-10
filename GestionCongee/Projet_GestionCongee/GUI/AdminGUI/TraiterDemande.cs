using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projet_GestionCongee.GUI.AdminGUI
{
    public partial class TraiterDemande : Form
    {
        public static int IdDemande;
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        public TraiterDemande()
        {
            InitializeComponent();
        }

        private void TraiterDemande_Load(object sender, EventArgs e)
        {
            demande actu = d.GetDemandeById(IdDemande);
            personne p1 = d.GetPersonneDeDemande(IdDemande);
            l1.Text = p1.nom + " " + p1.prenom;
            l2.Text = p1.date_debut.Value.ToShortDateString();           
            l3.Text = p1.nbjour.ToString();
            l4.Text = d.GetNombreConge(p1.id).ToString();
            l6.Text = ((actu.date_f - actu.date_d).Days + 1).ToString();

            link.Text = actu.certificat;
            l5.Text = actu.type;

            num.Text = "demande N° " + IdDemande;
        }

        private void label16_Click(object sender, EventArgs e)
        {
            HomeAdmin f = new HomeAdmin();
            f.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Historique f = new Historique();
            f.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
           CompteAdmin f = new CompteAdmin();
            f.Show();
            this.Hide();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login f = new Login();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Afficher une boîte de dialogue de confirmation
            DialogResult result = MessageBox.Show("Voulez-vous vraiment accepter cette demande ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Vérifier si l'utilisateur a cliqué sur Oui
            if (result == DialogResult.Yes)
            {
                // Mettre à jour l'état de la demande
                d.UpdateEtatDemande(IdDemande, "Accepter");
                demande d1 = d.GetDemandeById(IdDemande);
                TimeSpan difference = d1.date_d - d1.date_f;

                // Ajouter un jour à la différence car la différence entre deux dates ne comprend pas le dernier jour
                int nombreJoursConge = difference.Days + 1;

                p.UpdateNombreDejour(d1.id_pers, nombreJoursConge);
                // Actualiser l'affichage ou effectuer d'autres actions si nécessaire

                AfficheDemande f = new AfficheDemande();
                f.Show();
                this.Hide();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comment.Text))
            {
                MessageBox.Show("Le champ commentaire est obligatoire");
            }
            else
            {
                // Afficher une boîte de dialogue de confirmation
                DialogResult result = MessageBox.Show("Voulez-vous vraiment réfuser cette demande ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Vérifier si l'utilisateur a cliqué sur Oui
                if (result == DialogResult.Yes)
                {
                    // Mettre à jour l'état de la demande
                    d.UpdateEtatDemande(IdDemande, "Refuser");

                    // Actualiser l'affichage ou effectuer d'autres actions si nécessaire
                    AfficheDemande f = new AfficheDemande();
                    f.Show();
                    this.Hide();
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            OuvrirFichier(link.Text);
        }

        private void OuvrirFichier(string cheminFichier)
        {
            try
            {
                // Vérifiez si le fichier existe
                if (File.Exists(cheminFichier))
                {
                    // Ouvrez le fichier avec l'application par défaut
                    Process.Start(cheminFichier);
                }
                else
                {
                    MessageBox.Show("Le fichier n'existe pas.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur s'est produite : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void l5_Click(object sender, EventArgs e)
        {

        }

        private void l2_Click(object sender, EventArgs e)
        {

        }
    }
}

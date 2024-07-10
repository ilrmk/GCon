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
    public partial class HomeAdmin : Form
    {
        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();
        public HomeAdmin()
        {
            InitializeComponent();
        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void historique_Click(object sender, EventArgs e)
        {
            Historique.etatGlobale = "None";
            Historique.bureauId = -1;
            Historique F = new Historique();
            
            F.Show();
            this.Hide();

        }

        private void label16_Click(object sender, EventArgs e)
        {
            HomeAdmin F = new HomeAdmin();
            F.Show();
            this.Hide();
        }

        private void HomeAdmin_Load(object sender, EventArgs e)
        {
            nom.Text = p.GetPersonneById(p.Id).nom + p.GetPersonneById(p.Id).prenom;
            total_p.Text = p.GetPersonnesFromDatabase().Count().ToString();
            labelrefuser.Text = d.GetDemandesByCondition("Refuser").Count().ToString();
            label_accepter.Text = d.GetDemandesByCondition("accepter").Count().ToString();
            l_vente.Text = d.GetDemandesByConditionEB("en cours",5).Count().ToString();
            l_pr.Text = d.GetDemandesByConditionEB("en cours", 6).Count().ToString();
            l_rh.Text = d.GetDemandesByConditionEB("en cours", 7).Count().ToString();
            l_s.Text = d.GetDemandesByConditionEB("en cours", 8).Count().ToString();
            l_f.Text = d.GetDemandesByConditionEB("en cours", 9).Count().ToString();
            l_inf.Text = d.GetDemandesByConditionEB("en cours", 10).Count().ToString();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {
            Historique.etatGlobale = "refuser";
            Historique.bureauId = -1;
            Historique F = new Historique();            
            F.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Historique.bureauId = -1;
            Historique.etatGlobale = "accepter";
            Historique F = new Historique();           
            F.Show();
            this.Hide();
        }

        

        private void label5_Click(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 5;

            AfficheDemande F = new AfficheDemande();          
            F.Show();
            this.Hide();
        }

        private void label9_Click_1(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 7;
            AfficheDemande F = new AfficheDemande();
            F.Show();
            this.Hide();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void production_Click(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 6;
            AfficheDemande F = new AfficheDemande();
            F.Show();
            this.Hide();
        }

        private void label11_Click(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 8;
            AfficheDemande F = new AfficheDemande();
            F.Show();
            this.Hide();
        }

        private void label13_Click(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 9;
            AfficheDemande F = new AfficheDemande();
            F.Show();
            this.Hide();
        }

        private void label15_Click(object sender, EventArgs e)
        {
            AfficheDemande.b_Id = 10;
            AfficheDemande F = new AfficheDemande();
            F.Show();
            this.Hide();
        }

        private void label17_Click(object sender, EventArgs e)
        {
            CompteAdmin F = new CompteAdmin();
            F.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }
    }
}

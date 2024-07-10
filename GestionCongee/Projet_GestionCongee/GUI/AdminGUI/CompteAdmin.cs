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
    public partial class CompteAdmin : Form
    {
        public CompteAdmin()
        {
            InitializeComponent();
            personne prsonne = remplaireChamps();
            nomP.Text = prsonne.nom;
            prenomP.Text = prsonne.prenom;
            emailP.Text = prsonne.email;
            dep.Text = "";
            passwordP.Text = prsonne.password;
        }

        Classe_Metier.Demande d = new Classe_Metier.Demande();
        Classe_Metier.Personne p = new Classe_Metier.Personne();
        Classe_Metier.Departement b = new Classe_Metier.Departement();

        public personne remplaireChamps()
        {
            int id = Classe_Metier.Personne.getId();
            Classe_Metier.Personne perS = new Classe_Metier.Personne();

            personne prsonne = perS.GetPersonneById(id);
            return prsonne;

        }

     

       

       
        

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

       

        private void anuller_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            panel4.Visible = false;

        }


        private void CompteAdmin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox11_Click(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void modifier_Click_1(object sender, EventArgs e)
        {
            personne prsonne = remplaireChamps();
            textBox1.Text = prsonne.email;

            textBox2.Text = prsonne.password;
            panel4.Visible = true;
        }

        private void valider_Click_1(object sender, EventArgs e)
        {
            string email = textBox1.Text;
            string pass = textBox2.Text;
            string passc = textBox3.Text;
            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pass) || string.IsNullOrEmpty(passc))
            {
                MessageBox.Show("il faut saisire tout les  champes");
            }
            else
            {
                if (pass != passc)
                {
                    MessageBox.Show("Attention n'est pas correcte");
                    textBox3.Text = "";
                }
                else
                {
                    var choix = MessageBox.Show("Êtes-vous sûr de vouloir modifier le mot de passe et l'email ?");

                    if (choix != DialogResult.Yes)
                    {
                        int id = Classe_Metier.Personne.getId();
                        Classe_Metier.Personne pers = new Classe_Metier.Personne();
                        pers.UpdatePersonne(id, email, pass);
                    }
                    else
                    {
                        MessageBox.Show("Modification annulée.");
                    }
                }


            }

            personne a = new personne();

        }

        private void label16_Click_1(object sender, EventArgs e)
        {
            HomeAdmin form2 = new HomeAdmin();

            form2.Show();
            this.Hide();
        }



        private void label17_Click(object sender, EventArgs e)
        {
            CompteAdmin form2 = new CompteAdmin();

            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Historique form2 = new Historique();

            form2.Show();
            this.Hide();
        }
    
    }
}

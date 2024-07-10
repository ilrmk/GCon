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
    public partial class Compte : Form

    
    {
        public personne remplaireChamps()
        {
            int id = Personne.getId();
            Personne perS = new Personne();

            personne prsonne = perS.GetPersonneById(id);
            return prsonne;

        }

        public Compte()
        {
            InitializeComponent();

            personne prsonne = remplaireChamps();
            nomP.Text = prsonne.nom;
            prenomP.Text = prsonne.prenom;
            emailP.Text = prsonne.email ;
            dep.Text = "";
            passwordP.Text = prsonne.password;
        }

        
        private void pictureBox3_Click_1(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home form2 = new Home();

            form2.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            MesDemandes form2 = new MesDemandes();

            form2.Show();
            this.Hide();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            Compte form2 = new Compte();

            form2.Show();
            this.Hide();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void modifier_Click(object sender, EventArgs e)
        {

            personne prsonne = remplaireChamps();
           textBox1.Text = prsonne.email;
           
            textBox2.Text = prsonne.password;
            panel4.Visible = true;



        }

        private void anuller_Click(object sender, EventArgs e)
        {
            textBox1.Text = ""; 
            textBox2.Text = ""; 
            textBox3.Text = "";
            panel4.Visible =false;
            
        }

        private void valider_Click(object sender, EventArgs e)
        {

            string email = textBox1.Text;
            string pass = textBox2.Text;
            string passc = textBox3.Text;
            if(string.IsNullOrEmpty(email)|| string.IsNullOrEmpty(pass)|| string.IsNullOrEmpty(passc))
            {
                MessageBox.Show("il faut saisire tout les  champes");
            }
            else
            {
                if (pass !=passc)
                {
                    MessageBox.Show("Attention n'est pas correcte");
                    textBox3.Text = "";
                }
                else
                {
                    var choix = MessageBox.Show("Êtes-vous sûr de vouloir modifier le mot de passe et l'email ?");

                    if(choix != DialogResult.Yes)
                    {
                        int id = Personne.getId();
                        Personne pers = new Personne();
                        pers.UpdatePersonne(id,email,pass);
                    }
                    else
                    {
                        MessageBox.Show("Modification annulée.");
                    }
                }


            }

            personne a = new personne();


        }

        private void Compte_Load(object sender, EventArgs e)
        {

        }
    }
}

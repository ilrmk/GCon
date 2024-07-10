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
    public partial class Home : Form
    {
        Demande de = new Demande();
        public Home()
        {
            InitializeComponent();
            int id = Personne.getId();
            Console.WriteLine("hhhhhh" + id);
            // Ajoutez les types de maladie à la ComboBox

            // Continuez d'ajouter d'autres types de maladies selon vos besoins
            Personne per = new Personne();

            // Utilisation de l'id pour récupérer les détails de la personne
            personne pers = per.GetPersonneById(id);
            if (pers != null)
            {
                NomU.Text = pers.nom + " " + pers.prenom;
                Console.Write(pers.nom + " " + pers.prenom);
                NomU.Visible = true;
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {





        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

            Home form2 = new Home();

            form2.Show();
            this.Hide();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            MesDemandes form2 = new MesDemandes();

            form2.Show();
            this.Hide();

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Compte form2 = new Compte();

            form2.Show();
            this.Hide();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Login form2 = new Login();

            form2.Show();
            this.Hide();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {
            Home form2 = new Home();

            form2.Show();
            this.Hide();

        }

        private void label2_Click_1(object sender, EventArgs e)
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

        private void DeandeM_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string type = "malade";
            de.Type = "malade";
            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

      
        

        private void DemandeAnf_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string type = "enfant";
            de.Type = "enfant";
            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();

        }

        private void DemandeAutre_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string type = "autre";
            de.Type = "autre";

            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();
        }

        private void DemandeFeme_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string type = "enceinte";
            de.Type = "enceinte";

            DemandePage form2 = new DemandePage();

            form2.Show();
            this.Hide();

        }
    }
}

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
    public partial class DemandePage : Form
    {   Demande de = new Demande();

        private void demandeType()
        {
            string type = Demande.getType();
            if (type == "malade")
            {
                comboBox1.Items.Add("Grippe");
                comboBox1.Items.Add("Rhinopharyngite");
                comboBox1.Items.Add("Gastro-entérite");
                comboBox1.Visible = true;
                comboBox2.Visible =false;
                label7.Visible = true;

                pictureBox9.Visible =true;
                pictureBox8.Visible = false;
                pictureBox11.Visible = false;



            }

            else if (type == "enfant")
            {

               
                pictureBox8.Visible = true;
                pictureBox11.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;


            }
            else if(type == "enceinte")
            {

                pictureBox10.Visible = true;
                pictureBox9.Visible = false;
                pictureBox11.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;

            }
            else
            { 
                comboBox2.Items.Add("Congé de mariage");
                comboBox2.Items.Add("Congé parental d'éducation");
                comboBox2.Items.Add("Congé de proche aidant");
                comboBox2.Items.Add("Congé sans solde");
                comboBox2.Visible = true;
                label10.Visible = true;
                pictureBox11.Visible = true;
                pictureBox8.Visible = false;
                pictureBox9.Visible = false;
                comboBox1.Visible = false;
                label7.Visible = false;
                radioButton1.Visible = false;
                radioButton2.Visible = false;
                radioButton3.Visible = false;
                radioButton4.Visible = false;

            }
        }


        

        public DemandePage()
        {
            InitializeComponent();
            demandeType();
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void validMalade_Click(object sender, EventArgs e)
        {


            string date_d = dateTimePicker1.Text;
            string date_f = dateTimePicker2.Text;
            string ttype = Demande.getType();
            string champs_exp = textBox1.Text;
            string fichier = textBox2.Text ;
            DateTime dateSysteme = DateTime.Now;
            DateTime date_de= DateTime.Parse(date_d);
            DateTime date_fi = DateTime.Parse(date_f);

            int id = Personne.getId();



            if (ttype == "malade")
            {

                if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f) || string.IsNullOrEmpty(fichier))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }
                else if (date_de >= dateSysteme && date_de <= date_fi)


                {
                    demande nouvelleDemande = new demande
                    {
                        date_d = DateTime.Parse(date_d),
                        date_f = DateTime.Parse(date_f),
                        etat = "en cours",
                        certificat = fichier,
                        id_pers = id,
                        commentaire = champs_exp,
                        date_demande = dateSysteme,
                        type = ttype,
                    };
                    de.ajoute_demande(nouvelleDemande);
                    MessageBox.Show(" votre demande bien enregisté ");

                }
                else
                {

                    MessageBox.Show(" la date n'est pas correct");

                }
            }
        

                  
         

            else if (ttype == "enfant")
            {

                if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f) || string.IsNullOrEmpty(fichier))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }
              
                else if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f) )
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }
                else
                
                    if (date_de >= dateSysteme &&  date_de <= date_fi)
                    {
                      demande nouvelleDemande = new demande
                      {
                        date_d = DateTime.Parse(date_d),
                        date_f = DateTime.Parse(date_f),
                        etat = "en cours",
                        certificat = fichier,
                        id_pers = id,
                        commentaire = champs_exp,
                        date_demande = dateSysteme,
                        type = ttype,

                      };

                        de.ajoute_demande(nouvelleDemande);
                    MessageBox.Show(" votre demande bien enregisté ");

                }

                else
                    {
                
                        MessageBox.Show(" la date n'est pas correct");

                    }
  


                }

            else if (ttype == "enceinte")
            {

                if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f) || string.IsNullOrEmpty(fichier))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }

                else if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }
                else

                    if (date_de >= dateSysteme && date_de <= date_fi)
                {
                    demande nouvelleDemande = new demande
                    {
                        date_d = DateTime.Parse(date_d),
                        date_f = DateTime.Parse(date_f),
                        etat = "en cours",
                        certificat = fichier,
                        id_pers = id,
                        commentaire = champs_exp,
                        date_demande = dateSysteme,
                        type = ttype,

                    };

                    de.ajoute_demande(nouvelleDemande);
                    MessageBox.Show(" votre demande bien enregisté ");

                }

                else
                {

                    MessageBox.Show(" la date n'est pas correct");

                }


            }
            else

            {

                if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f) || string.IsNullOrEmpty(champs_exp))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }

                else if (string.IsNullOrEmpty(date_d) || string.IsNullOrEmpty(date_f))
                {
                    MessageBox.Show(" il faut saisir les champs obligatoire");
                }
                else

                    if (date_de >= dateSysteme && date_de <= date_fi)
                {
                    demande nouvelleDemande = new demande
                    {
                        date_d = DateTime.Parse(date_d),
                        date_f = DateTime.Parse(date_f),
                        etat = "en cours",
                        certificat = fichier,
                        id_pers = id,
                        commentaire = champs_exp,
                        date_demande = dateSysteme,
                        type = ttype,

                    };

                    de.ajoute_demande(nouvelleDemande);
                    MessageBox.Show(" votre demande bien enregisté ");

                }

                else
                {

                    MessageBox.Show(" la date n'est pas correct");

                }



            }


        }
        

        private void AnullerM_Click(object sender, EventArgs e)
        {

            Home form2 = new Home();

            form2.Show();
            this.Hide();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {


            
        }

        private void AjouFichier_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Sélectionner un fichier à importer";
            openFileDialog.Filter = "Fichiers PDF (*.pdf)|*.pdf|Tous les fichiers (*.*)|*.*";
            

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string cheminFichier = openFileDialog.FileName;

                textBox2.Text = cheminFichier;


            }
        }

        private void DemandePage_Load(object sender, EventArgs e)
        {

        }
    }
}


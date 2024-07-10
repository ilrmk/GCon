using Projet_GestionCongee.Classe_Metier;
using Projet_GestionCongee.GUI.AdminGUI;
using Projet_GestionCongee.GUI.EmployeGUI;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Projet_GestionCongee
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

      private void button1_Click(object sender, EventArgs e)
{
    String n = email.Text;
    String p = password.Text;

    using (gs_CongeeDataContext db = new gs_CongeeDataContext())
    {
        if (string.IsNullOrEmpty(n) || string.IsNullOrEmpty(p))
        {
            message.Text = "Il faut remplir tous les champs";
            message.Visible = true;
        }
        else
        {
            var result = (from c in db.personne where c.email == n && c.password == p select c).FirstOrDefault();

            if (result != null)
            {
                message.Visible = false;

                // Tu peux accéder aux propriétés de "result" ici
                int id = result.id;
                string role = result.role;
                        new Personne
                        {
                            Id = result.id,
                          
                        };

                        if (role == "admin")
                        {
                            HomeAdmin F =new  HomeAdmin();
                            F.Show();
                            this.Hide();
    
                        }
  
                       else
                       {
                            Home form2 = new Home();

                            form2.Show();
                            this.Hide();
                            
                       }

                
                
            }
            else
            {
                MessageBox.Show("Email ou mot de passe invalide");
            }
        }
    }
}

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            //ce code permit d'affiche le password

            password.PasswordChar = checkBox1.Checked ? '\0' : '*';


        }










        // Parcourir les résultats


    }
        }



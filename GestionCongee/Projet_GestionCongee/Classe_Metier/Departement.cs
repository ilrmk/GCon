using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Projet_GestionCongee.Classe_Metier
{
    class Departement
    {
        // Attributs
        private int id;
        private string nom;

        gs_CongeeDataContext db;

        public Departement()
        {
            db = new gs_CongeeDataContext();
        }
        // Constructeur
        public Departement(int id, string nom)
        {
            this.id = id;
            this.nom = nom;
        }

        // Getters et Setters
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }



        public List<bureau> GetBureauFromDatabase()
        {
            return db.bureau.ToList();

        }



        public bureau GetBureauById(int id)
        {

            return db.bureau.FirstOrDefault(p => p.id == id);

        }

        public int GetIdByNom(string nom)
        {
            var bureau = db.bureau.FirstOrDefault(b => b.nomB == nom);
            // Retournez l'ID du bureau
            return bureau.id;


        }

        

    }

}


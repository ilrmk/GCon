using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GestionCongee.Classe_Metier
{
    public class Demande
    {
        // Attributs
        private int id;
        private DateTime date_debut;
        private DateTime date_fin;
        private DateTime date_demande;
        private string etat;
        private string certificat;
        private static string type;
        private gs_CongeeDataContext db;

        // Constructeur par défaut
        public Demande()
        {
            db = new gs_CongeeDataContext();
        }

        // Constructeur avec paramètres
        public Demande(int id, DateTime date_debut, string Type, DateTime date_fin, DateTime date_demande, string etat, string certificat)
        {
            type = Type;
            this.id = id;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.date_demande = date_demande;
            this.etat = etat;
            this.certificat = certificat;
        }
        public Demande( DateTime date_debut, string Type, DateTime date_fin, DateTime date_demande, string etat, string certificat)
        {
            type = Type;
            this.date_debut = date_debut;
            this.date_fin = date_fin;
            this.date_demande = date_demande;
            this.etat = etat;
            this.certificat = certificat;
        }

        // Propriétés
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }


        static public string getType()
        {
            return type;
        }
        public DateTime DateDebut
        {
            get { return date_debut; }
            set { date_debut = value; }
        }

        public DateTime DateFin
        {
            get { return date_fin; }
            set { date_fin = value; }
        }

        public DateTime DateDemande
        {
            get { return date_demande; }
            set { date_demande = value; }
        }

        public string Etat
        {
            get { return etat; }
            set { etat = value; }
        }

        public string Certificat
        {
            get { return certificat; }
            set { certificat = value; }
        }

        // Méthodes pour récupérer des demandes
        public List<demande> GetAllDemandes()
        {
            return db.demande.ToList();
        }

        public demande GetDemandeById(int id)
        {
            return db.demande.FirstOrDefault(d => d.id == id);
        }

        public List<demande> GetDemandesByCondition(string etat)
        {
            return db.demande.Where(d => d.etat == etat).ToList();
        }

        public List<demande> GetDemandesByConditionEB(string etat, int bureauId)
        {
            var demandes = (from demande in db.demande
                            join personne in db.personne on demande.id_pers equals personne.id
                            where personne.id_B == bureauId && demande.etat == etat
                            select demande).ToList();
            return demandes;
        }

        public List<demande> GetDemandesBetweenDates(DateTime dateDebut, DateTime dateFin)
        {
            return db.demande.Where(d => d.date_d >= dateDebut && d.date_f <= dateFin).ToList();
        }

        public List<demande> GetDemandesBureauById(int bureauId)
        {
            var demandes = (from demande in db.demande
                            join personne in db.personne on demande.id_pers equals personne.id
                            where personne.id_B == bureauId
                            select demande).Take(1000).ToList();
            return demandes;
        }
         public void ajoute_demande(demande de)
        {
            db.demande.InsertOnSubmit(de);
            db.SubmitChanges();
        }
        public List<demande> GetDemandesEmploye(int idEmploye)
        {
            var demandes = (from demande in db.demande
                           where demande.id_pers == idEmploye 
                           select demande).Take(1000).ToList(); ;

            return demandes;
        }


        public void UpdateEtatDemande(int IdDemande, string etat)
        {
            // Connexion à votre base de données
            using (var db = new gs_CongeeDataContext())
            {
                // Trouver la demande à mettre à jour
                var demande = db.demande.FirstOrDefault(d => d.id == IdDemande);

                // Vérifier si la demande existe
                if (demande != null)
                {
                    // Mettre à jour l'état de la demande
                    demande.etat = etat;

                    // Enregistrer les modifications dans la base de données
                    db.SubmitChanges();

                    Console.WriteLine("L'état de la demande a été mis à jour avec succès.");
                }
                else
                {
                    Console.WriteLine("Aucune demande n'a été trouvée avec l'ID spécifié.");
                }
            }
        }


        public personne GetPersonneDeDemande(int id)
        {
            var personne1 = (from demande in db.demande
                             join personne in db.personne on demande.id_pers equals personne.id
                             where demande.id == id
                             select personne).FirstOrDefault();

            return personne1;
        }

        public int GetNombreConge(int idpersonne)
        {
            var nombreConge = (from demande in db.demande
                               
                               where demande.etat == "Accepter" && demande.id_pers == idpersonne
                               select demande).Count();

            return nombreConge;
        }

    }
}

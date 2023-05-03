using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Modèle
{
    /// <summary>
    /// La classe User représente un utilisateur ayant pour identifiant son pseudo (publique),
    /// son nom et prénom en privé, pour une utilisation ultérieure et/ou pour identifier de manière
    /// plus simple l'utilisateur dans la base de donnée (car un pseudo n'est pas forcément explicite)
    /// </summary>
    public class User
    {
        public string Pseudo { get; private set; }
        public string Nom { get; private set; }
        public string Prenom { get; private set; }
        private string Mdp { get; set; }
        public List<Monstre>? monstresDejaVu { get; private set; }

        public User(string pseudo, string nom, string prenom, string mdp)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(mdp))
            {
                throw new ArgumentException("Un User doit avoir un pseudo, un nom, un prénom et un mot de passe au minimum!");
            }
        }

        public User(string pseudo, string nom, string prenom, string mdp, List<Monstre> monstresVus)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
            monstresDejaVu = monstresVus;
            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(mdp))
            {
                throw new ArgumentException("Un User doit avoir un pseudo, un nom, un prénom et un mot de passe au minimum!");
            }
        }

        public bool verifyPssw(string pssw)
        {
            if(pssw.Equals(Mdp))
            {
                return true;
            }
            return false;
        }
    }
}

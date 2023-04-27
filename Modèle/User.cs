using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
    public class User
    {
        public string Pseudo { get; private set; }
        private string Nom { get; }
        private string Prenom { get; }
        public string Mdp { get; private set; }


        public User(string pseudo, string nom, string prenom, string mdp)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
        }
    }
}

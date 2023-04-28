using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

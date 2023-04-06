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
        public List<User> ListUsers { get; private set; } = new List<User>();


        public User(string pseudo, string nom, string prenom, string mdp)
        {
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
        }

        public int testConnexion(string pseudo, string mdp)
        {
            foreach (User i in ListUsers)
            {
                if (i.Pseudo.Equals(pseudo) && i.Mdp.Equals(mdp))
                {
                    return 0;
                }
                else
                {
                    if (i.Pseudo != pseudo && i.Mdp.Equals(mdp))
                    {
                        return 1;    
                    }
                    if (i.Pseudo.Equals(pseudo) && i.Mdp != mdp)
                    {
                        return 2;
                    }
                }
            }
            return -1;
        }
    }
}

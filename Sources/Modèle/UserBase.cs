using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// Cette classe permet d'initialiser une base de données d'utilisateurs, en appelant pour le
    /// moment le stub. Elle permet également de manipuler ces données.
    /// </summary>
    public class UserBase
    {
        private List<User> users = null!;
        public List<User> ListUsers
        {
            get
            {
                return users;
            }
            private set
            {
                users = value;
            }
        }

        public UserBase()
        {
            ListUsers = new Stub().loadUsers();
        }

        /// <summary>
        /// Cette méthode vérifie si l'utilisateur est présent dans la base de données
        /// </summary>
        /// <param name="username">Identifiant (pseudo) de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        public bool checkIfExists(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }
            foreach (User u in ListUsers)
            {
                if (checkIfPseudoExists(username) && u.verifyPssw(password))
                {
                    return true;
                }
            }
            return false;
        }

        public bool checkIfPseudoExists(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return false;
            }
            foreach (User u in ListUsers)
            {
                if (username.Equals(u.Pseudo))
                {
                    return true;
                }
            }
            return false;
        }

        public bool addUser(string pseudo, string nom, string prenom, string pssw)
        {
            bool exists = checkIfExists(pseudo, pssw);
            if ( exists )    // Si le nom d'utilisateur a été trouvé dans la base de données
            {
                return false;
            }
            User user = new User(pseudo, nom, prenom, pssw); //POUR L'INSTANT -> Ne peux pas ajouter dans le stub
            return true;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
    /// <summary>
    /// Cette classe permet d'initialiser une base de données d'utilisateurs, en appelant pour le
    /// moment le stub. Elle permet également de manipuler ces données.
    /// </summary>
    public class UserBase
    {
        private List<User> users;
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
        public int checkIfExists(string username, string password)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return 0;
            }
            foreach (User u in ListUsers)
            {
                if (username.Equals(u.Pseudo) && u.verifyPssw(password))
                {
                    return 5;
                }
            }
            return 0;

        }

    }
}
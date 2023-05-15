using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public class UserManager : IUserDataManager
    {
        public IUserDataManager Pers { get; set; }

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
        void addUser(User u)
        {

        }

        void removeUser(User u)
        {

        }
        //CHANGER VISIBILITE CAR ATTENTION
        void IUserDataManager.saveUsers(List<User> users)
        {
            Pers.saveUsers(users);
        }

        List<User> IUserDataManager.loadUsers()
        {
            return Pers.loadUsers();
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

            return (from User u in ListUsers
                    where username.Equals(u.Pseudo)
                    select true).FirstOrDefault();
        }

        public bool addUser(string pseudo, string nom, string prenom, string pssw)
        {
            bool exists = checkIfExists(pseudo, pssw);
            if ( exists )    // Si le nom d'utilisateur a été trouvé dans la base de données
            {
                return false;
            }
            User user = new User(pseudo, nom, prenom, pssw); //POUR L'INSTANT, de manière non permanente
            ListUsers.Add(user);
            return true;
        }

        public UserManager(IUserDataManager dataMngr) {
            Pers = dataMngr;
            ListUsers = new LoaderStub().loadUsers();
        }
    }
}

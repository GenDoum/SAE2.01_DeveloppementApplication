using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
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
        
        public int checkIfExists(string username, string password)
        {
            foreach (User u in ListUsers)
            {
                if(username.Equals(u.Pseudo) && password.Equals(u.Mdp))
                {
                    Console.WriteLine($"Bienvenue, {u.Pseudo}, vous venez de vous connecter!");
                    return 1;
                }
            }
            return 0;
        }
    }
}
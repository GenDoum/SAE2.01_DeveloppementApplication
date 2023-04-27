using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
    public class Stub
    {
        public Stub() { }
        public List<User> loadUsers() ///CHANGER VISIBILITEE, CAR PAS BIEN DE LAISSER A TOUT LE MONDE
        {
            List<User> lu = new List<User>();
            lu.Add(new User("DedeDu42", "dede", "dodo", "mdp"));
            lu.Add(new User("Moi", "Monchanin", "Liam", "feur"));
            lu.Add(new User("Nikoala", "Blondeau", "Nicolas", "niblondeau"));
            lu.Add(new User("Yadoumir", "Doumir", "Yannis", "mdp"));
            return lu;
        }
    }
}
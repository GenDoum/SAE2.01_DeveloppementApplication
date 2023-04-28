using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Modèle
{
    /// <summary>
    /// Le stub "émule" une base de données, elle permet simplement d'imiter le rôle du stockage des 
    /// données, par exemple en ajoutant plusieurs utilisateurs dans une base de données.
    /// </summary>
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

        public List<Monstre> loadMonsters() ///SAME
        {
            List<Monstre> lm = new List<Monstre>();
            lm.Add(new Monstre(1, "Cochon", "Je suis un animal présent un peu partout (oui cette info est pas juste).", new List<string> { "Caractéristique 1", "C2", "C3" }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(2, "Poule", "Je suis présente un peu partout, et je ponds des oeufs des fois.", new List<string> { "Caractéristique 1", "C2", "C3" }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(3, "Mouton", "Je suis un animal présent dans la campagne.", new List<string>{ "Caractéristique 1", "C2", "C3" }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(4, "Warden", "Le Warden est une entité conçue pour vous traquer.", new List<string> { "Caractéristique 1", "C2", "C3" }, new List<string> { "Apparence1", "App2", "App3" }));
            return lm;
        }
    }
}
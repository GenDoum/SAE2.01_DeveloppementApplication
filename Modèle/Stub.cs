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
            lm.Add(new Monstre(1, "Poule", "Je suis un animal présent un peu partout, sauf dans le desert car il fait beaucoup trop chaud. Mais j'aime beaucoup la jungle !", new List<string> { "Quand une poule est tué il y a 3.12% de chance que la poule laisse tomber un oeuf " }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(2, "Mouton", "Je suis présent un peu partout, sauf dnas le desert.", new List<string> { "Avec une cisaille il est possible de rasé la laine d'un mouton, il se retoruvera sans laine.", "Pour faire repousser la laine d'un mouton il faut qu'il ai de l'herbe sous ses pattes pour qu'il puisse manger. Une fois manger la laine repousse instantanément !" }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(3, "Cochon", "Je suis un animal présent partout, sauf dans le desert ou il fait trop chaud pour moi.", new List<string>{ "La reproduction de cochon peut se faire avec des carottes et des patates crues."}, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(4, "Warden", "Je ne vous voit pas mais je sais où vous êtes", new List<string> { "Le warden est aveugle mais il entend tous les bruit autour de lui.", "Il apparait dans une caverne spécial appeler les abîmes quand on y marche en faisant trop de bruit.", "Il s'agit du seul monstre qui ai une animation d'apparation, il sort du sol.", "Il est capable de tirer des rayon laser à l'endroit d'où proviennes les bruit qu'il entend." }, new List<string> { "Apparence1", "App2", "App3" }));
            return lm;
        }
    }
}
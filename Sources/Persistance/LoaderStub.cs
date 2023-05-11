using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    /// <summary>
    /// Le stub "émule" une base de données, elle permet simplement d'imiter le rôle du stockage des 
    /// données, par exemple en ajoutant plusieurs utilisateurs dans une base de données.
    /// </summary>
    public class LoaderStub : IUserDataManager
    {
        public LoaderStub() { }
        public List<User> loadUsers() ///CHANGER VISIBILITEE, CAR PAS BIEN DE LAISSER A TOUT LE MONDE
        {
            List<User> lu = new List<User>();
            lu.Add(new User("DedeDu42", "dede", "dodo", "mdp", new List<Monstre> { }));
            lu.Add(new User("Moi", "Monchanin", "Liam", "feur", new List<Monstre> { }));
            lu.Add(new User("Nikoala", "Blondeau", "Nicolas", "niblondeau", new List<Monstre> { }));
            lu.Add(new User("Yadoumir", "Doumir", "Yannis", "mdp", new List<Monstre> { }));
            lu.Add(new User("osuplayer123", "Bonetti", "Martin", "oSu!727", new List<Monstre> { }));
            return lu;
        }

        public List<Monstre> loadMonsters() ///SAME
        {
            List<Monstre> lm = new List<Monstre>();
            lm.Add(new Monstre(1, "Poule", "passif", "Je suis un animal présent un peu partout, sauf dans le desert car il fait beaucoup trop chaud. Mais j'aime beaucoup la jungle !", new List<string> { "Quand une poule est tué il y a 3.12% de chance que la poule laisse tomber un oeuf " }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(2, "Mouton", "passif", "Je suis présent un peu partout, sauf dnas le desert.", new List<string> { "Avec une cisaille il est possible de rasé la laine d'un mouton, il se retoruvera sans laine.", "Pour faire repousser la laine d'un mouton il faut qu'il ai de l'herbe sous ses pattes pour qu'il puisse manger. Une fois manger la laine repousse instantanément !" }, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(3, "Cochon", "passif", "Je suis un animal présent partout, sauf dans le desert ou il fait trop chaud pour moi.", new List<string>{ "La reproduction de cochon peut se faire avec des carottes et des patates crues."}, new List<string> { "Apparence1", "App2", "App3" }));
            lm.Add(new Monstre(4, "Warden", "boss", "Je ne vous voit pas mais je sais où vous êtes", new List<string> { "Le warden est aveugle mais il entend tous les bruit autour de lui.", "Il apparait dans une caverne spécial appeler les abîmes quand on y marche en faisant trop de bruit.", "Il s'agit du seul monstre qui ai une animation d'apparation, il sort du sol.", "Il est capable de tirer des rayon laser à l'endroit d'où proviennes les bruit qu'il entend." }, new List<string> { "Une seul apparence pour lui" }));
            lm.Add(new Monstre(5, "Ender dragon", "boss", "Si vous arrivez à me vaincre, vous aurez accompli tout ce qui était possible de faire dans ce monde.", new List<string> { "L'Ender dragon est le boss de fin de minecraft.", "Pour le vaincre il faut trouver le portail inter-dimensionnel qui se cache quelque part dans votre monde.", "Une fois vaincu, il laissera son oeuf ainsi qu'un portail qui vous permettra de rentrer chez vous." }, new List<string> { "Une seul apparence pour lui" }));
            lm.Add(new Monstre(6, "Wither", "boss", "Une fois que je vous ai aperçue, je ne vous lâcherais plus jusqu'à ce que mort s'ensuive.", new List<string> { "Pour le faire apparaitre, il vous faudrat la tête de 3 wither squelette.", "Le wither lance des tête qui repousse instantanément.", "Ces têtes peuvent vous empoissoné jusqu'à la mort" }, new List<string> { "Apparence de chargement", "Apparence d'attaque", "Apparence mid life" }));
            lm.Add(new Monstre(7, "Vache", "passif", "Je suis un peu partout dans le monde, mais plus particulièrement dans les plaines.", new List<string> { "Les vaches apparaissent par groupe de quatres minimum.", "Elle peuvent donner du lait grâce à un sceau, ce lait enlève tout les effets de potion que vous aurez" }, new List<string> { "Vache de base", "vache champignon" }));
            lm.Add(new Monstre(8, "Loup", "passif", "Je deviens vite aggressif lorsque l'on m'attaque.", new List<string> { "Les loups peuvent être apprivoisé grâce à des os.", " Une fois apprivoisé" }, new List<string> { "Apparence nature", "Apparence méchant", "Apparence apprivoisé" }));
            lm.Add(new Monstre(9, "Chat", "passif", "J'espère que tu as du poisson, sinon je ne m'approche pas de toi !", new List<string> { "Le chat à peur des humain mais apparaît seulement dans les villages.", "Si un chat apparaît près d'une sorcière, il sera forcément noir" }, new List<string> { "apparence au pif", "apparence noir" }));
            lm.Add(new Monstre(10, "Zombie", "hostile", "Je peux vous voir de très loin et venir discrètement.", new List<string> { "Il y a une faible chance qu'un zombie qui apparaît soit un zombie villageois, il est possible de le re transformer en villageois afin de faire des échanges à prix réduit avec lui", "Les bébé zombie sont les monstres les plus rapides." }, new List<string> { "Zobmie", "zombie villageois", " bébé zombie" }));
            lm.Add(new Monstre(11, "Squelette", "hostile", "Je suis un sniper d'élite, je ne loupe presque jamais ma cible", new List<string> { "Il laisse parfois tomber leurs arc, mais ils sont souvent usés.", " Parfois il chevauche une araignée pour se déplacer, il devient alors plus rapide." }, new List<string> { "basique", "spider jokey" }));
            lm.Add(new Monstre(12, "Creeper", "hostile", "J'approche doucement et j'explose.", new List<string> { "Le creeper possède une peau verte et blanche. Cette apparence était à l'époque de la bêta du jeu la même que les blocs de terre, afin de surprendre les joueurs.", "Il est possible de le faire exploser avec un briquet" }, new List<string> { "apparence de base" }));
            lm.Add(new Monstre(13, "Phantom", "hostile", "Dormez ou je viendrais", new List<string> { "Le phantom apparaît lorsque vous ne dormez pas pendant plus de trois jour d'affilés.", "Ils sont difficile à atteindre pusiqu'il vole plutôt vite" }, new List<string>{"Apparence 1"}));
            lm.Add(new Monstre(14, "Enderman", "hostile", "Ne me regardez pas ! ", new List<string> { "Si vous regardez un enderman dans les yeux, il se mettra à vous attaquer, autrement, il est inoffensif", " Gardez le contact visuel avec, lui le fera changer d'avis au bout de quelques secondes sur l'agressivité qu'il a envers vous.", "Il est capable de prendre des blocks et les reposer ailleurs." }, new List<string> { "apparence 1", "apparence avec un bloc" }));
            lm.Add(new Monstre(15, "Slime", "hostile", "Je connais le multiclonage !", new List<string> { "Les slimes peuvent apparaître avec des tailles différentes.", "S'il n'est pas trop petit, il se divisera en quatre."}, new List<string> { "Apparencegrand", "apparence petit"}));
            lm.Add(new Monstre(16, "Araignée", "hostile", " je sais pas quoi mettre mdrrrrr", new List<string> { "L'arraignée est capable de grimper au mur", " Si vous en rencontrait une en journée et en extérieur elle sera inoffensive, mais dans une caverne ou pendant la nuit elle vous attaquera." }, new List<string> { "une seule apparence" }));
            return lm;
        }

        void IUserDataManager.saveUsers(List<User> users)
        {
            Console.WriteLine("This is a stub, so no 'save' possible !");
        }
    }
}
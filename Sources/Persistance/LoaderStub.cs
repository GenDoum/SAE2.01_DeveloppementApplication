using System;
using Model;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace Persistance
{
    /// <summary>
    /// Le stub "émule" une base de données, elle permet simplement d'imiter le rôle du stockage des 
    /// données, par exemple en ajoutant plusieurs utilisateurs dans une base de données.
    /// </summary>
    public class LoaderStub : IUserDataManager, IMonsterDataManager
    {
        public LoaderStub() { }
        public List<User> loadUsers() ///CHANGER VISIBILITEE, CAR PAS BIEN DE LAISSER A TOUT LE MONDE
        {
            List<User> lu = new List<User>();
            lu.Add(new User("DedeDu42", "dede", "dodo", "mdp", new List<Monstre> { }));
            lu.Add(new User("Moi", "Monchanin", "Liam", "feur", new List<Monstre> { }));
            lu.Add(new User("Nikoala", "Blondeau", "Nicolas", "niblondeau", new List<Monstre> { 
                                                                                    new Monstre(2, 
                                                                                    "Mouton", "passif", "Je suis présent un peu partout, sauf dnas le desert.", 
                                                                                    new List<string> { "Avec une cisaille il est possible de raser la laine d'un mouton, il se retrouvera sans laine.","Pour faire repousser la laine d'un mouton, il faut qu'il ait de l'herbe sous ses pattes pour qu'il puisse manger. Une fois l'herbe mangée, la laine repousse instantanément !" }, 
                                                                                    new List<string> { "Apparence1", "App2", "App3" }
                                                                                    , new ObservableCollection<Conseil> {}) }));

            lu.Add(new User("Yadoumir", "Doumir", "Yannis", "mdp", new List<Monstre> { }));
            lu.Add(new User("osuplayer123", "Bonetti", "Martin", "oSu!727", new List<Monstre> { }));
            return lu;
        }

        public ObservableCollection<Monstre> loadMonsters() ///SAME
        {
            ObservableCollection<Monstre> lm = new ObservableCollection<Monstre>();
            User user = new User("ddd", "ddd", "ddd", "ddd");
            Monstre monstre = new Monstre(1, "monstre", "dangereux", "je suis gentil tkt", new List<string> { }, new List<string> { }, new ObservableCollection<Conseil>{ });
            Conseil conseil = new Conseil(user, "Voili voilou", monstre);
            lm.Add(new Monstre(1, "Poule", "passif", "Je suis un animal présent un peu partout, sauf dans le desert car il fait beaucoup trop chaud. Mais j'aime beaucoup la jungle !", new List<string> { "Quand une poule est tué il y a 3.12% de chance que la poule laisse tomber un oeuf " }, new List<string> { "Apparence1", "App2", "App3" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(2, "Mouton", "passif", "Je suis présent un peu partout, sauf dnas le desert.", new List<string> { "Avec une cisaille il est possible de rasé la laine d'un mouton, il se retoruvera sans laine.", "Pour faire repousser la laine d'un mouton il faut qu'il ai de l'herbe sous ses pattes pour qu'il puisse manger. Une fois manger la laine repousse instantanément !" }, new List<string> { "Apparence1", "App2", "App3" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(3, "Cochon", "passif", "Je suis un animal présent partout, sauf dans le desert ou il fait trop chaud pour moi.", new List<string>{ "La reproduction de cochon peut se faire avec des carottes et des patates crues."}, new List<string> { "Apparence1", "App2", "App3" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(4, "Warden", "boss", "Je ne vous voit pas mais je sais où vous êtes", new List<string> { "Le warden est aveugle mais il entend tous les bruit autour de lui.", "Il apparait dans une caverne spécial appeler les abîmes quand on y marche en faisant trop de bruit.", "Il s'agit du seul monstre qui ai une animation d'apparation, il sort du sol.", "Il est capable de tirer des rayon laser à l'endroit d'où proviennes les bruit qu'il entend." }, new List<string> { "Une seul apparence pour lui" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(5, "EnderDragon", "boss", "Si vous arrivez à me vaincre, vous aurez accompli tout ce qui était possible de faire dans ce monde.", new List<string> { "L'Ender dragon est le boss de fin de minecraft.", "Pour le vaincre il faut trouver le portail inter-dimensionnel qui se cache quelque part dans votre monde.", "Une fois vaincu, il laissera son oeuf ainsi qu'un portail qui vous permettra de rentrer chez vous." }, new List<string> { "Une seul apparence pour lui" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(6, "Wither", "boss", "Une fois que je vous ai aperçue, je ne vous lâcherais plus jusqu'à ce que mort s'ensuive.", new List<string> { "Pour le faire apparaitre, il vous faudrat la tête de 3 wither squelette.", "Le wither lance des tête qui repousse instantanément.", "Ces têtes peuvent vous empoissoné jusqu'à la mort" }, new List<string> { "Apparence de chargement", "Apparence d'attaque", "Apparence mid life" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(7, "Vache", "passif", "Je suis un peu partout dans le monde, mais plus particulièrement dans les plaines.", new List<string> { "Les vaches apparaissent par groupe de quatres minimum.", "Elle peuvent donner du lait grâce à un sceau, ce lait enlève tout les effets de potion que vous aurez" }, new List<string> { "Vache de base", "vache champignon" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(8, "Loup", "passif", "Je deviens vite aggressif lorsque l'on m'attaque.", new List<string> { "Les loups peuvent être apprivoisé grâce à des os.", " Une fois apprivoisé" }, new List<string> { "Apparence nature", "Apparence méchant", "Apparence apprivoisé" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(9, "Chat", "passif", "Les chats sont des animaux de compagnie. On les trouve dans les villages. Ils peuvent prendre 11 apparences différentes. Une fois adoptés grâce à du poisson, ils vous suivront partout à moins que vous leur disiez de ne plus bouger.", new List<string> { "Les chats ont la particularité d'effrayer les creepers", "Ils chassent aussi les lapins, qu'ils tuent pour vous ainsi que les bébés tortues.", "Les chats apprivoisés iront directement sur votre lit si vous en possédez un à proximité.  Au réveil, ils peuvent parfois vous faire un cadeau (un objet aléatoire).", "Si un chat apparaît près d'une cabane à sorcière ou à proximité d'une sorcière, il sera automatiquement noir." }, new List<string> { "apparence au pif", "apparence noir" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(10, "Zombie", "hostile", "Je peux vous voir de très loin et venir discrètement.", new List<string> { "Il y a une faible chance qu'un zombie qui apparaît soit un zombie villageois, il est possible de le re transformer en villageois afin de faire des échanges à prix réduit avec lui", "Les bébé zombie sont les monstres les plus rapides." }, new List<string> { "Zobmie", "zombie villageois", " bébé zombie" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(11, "Squelette", "hostile", "Les squelettes sont des créatures hostiles. Ils sont des ennemis rapides qui tirent des flèches sur les joueurs. Il existe une variante au squelette classique, le Vagabond. Le vagabond est un squelette qui apparaît uniquement dans les biomes froids. Comme les squelettes classiques, ils apparaissent uniquement la nuit ou dans les endroits sombres.", new List<string> { "Au contact de la lumière du soleil, ils prennent feu et finissent par mourir de leurs brûlures. Il peut arriver que des araignées apparaissent avec un squelette sur leur dos, on les appelle les Araignées Jockey.", "Le vagabond lance des flèches qui donnent l'effet lenteur aux joueurs." }, new List<string> { "basique", "spider jokey" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(12, "Creeper", "hostile", "Le creeper est une créature verte, pratiquement silencieuse, insidieuse et kamikaze. Une fois qu'il s'est assez rapproché du joueur, le creeper laissera échapper un sifflement sonore et explosera après un à deux secondes. Lorsqu'ils sont frappés par la foudre, les creepers se chargent et se transforment en creeper chargé.", new List<string> { "Il est également possible d'activer l'explosion des creepers manuellement en utilisant un briquet sur eux.", "Les creepers sont silencieux quand ils ne bougent pas et ne prennent pas feu quand ils sont exposé à la lumière du jour. En revanche, ils n'apparaissent que dans des endroits sombres (cavernes ou la nuit).", "Lorsqu'un creeper est tué par un squelette, il laissera tomber un disque.", "Lorsqu'un crepper chargé tue un monstre en explosant, le monstre tué par l'explosion laisseront tomber leurs têtes. De même pour les joueurs." }, new List<string> { "apparence de base" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(13, "Phantom", "hostile", "Les phantoms sont des monstres volants en haute altitude, ils apparaissent uniquement la nuit et au dessus des joueurs n'ayant pas domit depuis au 3 jours.", new List<string> { "Si le joueur fatigué est en extérieur durant la nuit les phantoms apparaissent par groupe de 1 à 4 à 20 blocks de haut.", "Plus les joueurs passent de temps sans dormir, et plus il y a de chances que des phantoms apparaissent en nombre.", "Ils attaquent en faisant un piqué sur le joueur avant de remonter en altitude.", "Le seul moyen d'empêcher leur apparition, est de dormir ou de mourir, ainsi le compteur de fatigue se remettra à zéro." }, new List<string>{"Apparence 1"}, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(14, "Enderman", "hostile", "L'Enderman est un monstre assez rre dans le monde normal. C'est un mob qui à la possibilité de prendre et de déplacer des blocs.", new List<string> { "Ils ne vous attaqueront pas sauf si vous les regardez directement dans les yeux, ils se téléporteront alors derrière vous et deviendrons extrêmement hostiles.", "L'eau (et donc la pluie) est leur ennemie, en effet au contact de celle-ci, ils perdront de la vie, c'est pourquoi ils se téléporteront instantanément.", "Les Endermans sont omniprésents dans le monde de l'End.", "Comme la plupart des monstres, les Endermans apparaissent seulement dans les endroits sombres." }, new List<string> { "apparence 1", "apparence avec un bloc" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(15, "Slime", "hostile", "Les slimes sont des cubes verts translucides. Ils peuvent être répertoriés dans 3 tailles : Grand, moyen et petit.", new List<string> { "Les slimes peuvent apparaitre à la fois dans des zones éclairées et sombres, mais uniquement dans les couches les plus profondes et dans des endroit plat.", "Ils apparaissent généralement dans de grandes cavernes ou des mines à ciel ouvert, puisqu'ils ont besoin de place.", "Si vous tuez un Gros slime, il peut se diviser en deux, trois ou quatre slime de taille plus petite."}, new List<string> { "Apparencegrand", "apparence petit"}, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(16, "Araignee", "hostile", "Les araignées sont agressives au cours de la nuit ou dans l'obscurité, on les reconnait à leurs yeux qui brillent en rouge.", new List<string> { "Elles sont rapide et sont caapble de grimper aux murs.", "Lorsqu'elles poursuivent le joueur pendant la nuit, elles continueront à les chasser durant la journée.", "En journée, elles ne vous attaqeuront pas à moins d'être provoquées", "Il peut arriver que des araignées apparaissent avec un squelette sur leurs dos, on les appelle les Araignées Jockey." }, new List<string> { "une seule apparence" }, new ObservableCollection<Conseil> { }));
            return lm;
        }

        void IUserDataManager.saveUsers(List<User> users)
        {
            Console.WriteLine("This is a stub, so no 'save' possible !");
        }

        void IMonsterDataManager.saveMonsters(List<Monstre> monstres)
        {
            Console.WriteLine("This is a stub, so no 'save' possible !");
        }
    }
}
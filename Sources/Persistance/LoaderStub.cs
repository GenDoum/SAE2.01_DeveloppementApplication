﻿using System;
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
            Monstre monstre = new Monstre(1, "Poule", "passif", "Les poules sont des créatures passives. Elles fournissent des plumes et des oeufs.En moyenne, une poule laisse tomber un oeuf toutes des 5 à 10 minutes.", new List<string> { "Quand une poule est tuée, il y a une faible chance qu'elle laisse tomber un œuf.", "Parfois, les poules apparaissent avec un bébé zombie sur le dos, on l'appelle alors une poule jockey. Il est aussi possible d'avoir un bébé cochon zombie sur son dos, mais seulement par commande." }, new List<string> { "Poule", "Poule jockey", "Poule jockey cochon" }, new ObservableCollection<Conseil> { });
            List<User> lu = new List<User>();
            lu.Add(new User("DedeDu42", "dede", "dodo", "mdp", new List<Monstre> { monstre }));
            lu.Add(new User("Moi", "Monchanin", "Liam", "feur", new List<Monstre> { monstre }));
            lu.Add(new User("Nikoala", "Blondeau", "Nicolas", "niblondeau", new List<Monstre> { 
                                                                                    new Monstre(2, 
                                                                                    "Mouton", "passif", "Je suis présent un peu partout, sauf dnas le desert.", 
                                                                                    new List<string> { "Avec une cisaille il est possible de raser la laine d'un mouton, il se retrouvera sans laine.","Pour faire repousser la laine d'un mouton, il faut qu'il ait de l'herbe sous ses pattes pour qu'il puisse manger. Une fois l'herbe mangée, la laine repousse instantanément !" }, 
                                                                                    new List<string> { "Apparence1", "App2", "App3" }
                                                                                    , new ObservableCollection<Conseil> {}) }));

            lu.Add(new User("Yadoumir", "Doumir", "Yannis", "mdp", new List<Monstre> { monstre }));
            lu.Add(new User("osuplayer123", "Bonetti", "Martin", "oSu!727", new List<Monstre> { monstre }));
            return lu;
        }

        public ObservableCollection<Monstre> loadMonsters() ///SAME
        {
            ObservableCollection<Monstre> lm = new ObservableCollection<Monstre>();
            User user = new User("Admin", "ddd", "ddd", "ddd");
            Monstre monstre = new Monstre(1, "monstre", "dangereux", "je suis gentil tkt", new List<string> { }, new List<string> { }, new ObservableCollection<Conseil>{ });
            Conseil conseil = new Conseil(user, "C'est super facile à tuer !", monstre);
            lm.Add(new Monstre(1, "Poule", "passif", "Les poules sont des créatures passives. Elles fournissent des plumes et des oeufs.En moyenne, une poule laisse tomber un oeuf toutes des 5 à 10 minutes.", new List<string> { "Quand une poule est tuée, il y a une faible chance qu'elle laisse tomber un œuf.", "Parfois, les poules apparaissent avec un bébé zombie sur le dos, on l'appelle alors une poule jockey. Il est aussi possible d'avoir un bébé cochon zombie sur son dos, mais seulement par commande." }, new List<string> { "Poule", "Poule jockey", "Poule jockey cochon" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(2, "Mouton", "passif", "Les moutons sont des créatures passives. Sa principale caractéristique est qu'il peut fournir de la laine, un matériau qui sert à fabriquer des objets, notamment des lits.", new List<string> { "Avec une cisaille, il est possible de rasé la laine d'un mouton, il se retrouvera sans laine.", "Pour faire repousser la laine d'un mouton, il faut qu'il ait de l'herbe sous ses pattes pour qu'il puisse manger. Une fois manger la laine repousse instantanément.", "Les moutons peuvent avoir toutes les couleurs du jeu grâce à des teintures et des mélanges. Mais les seules couleurs de mouton pouvant apparaître sont le blanc, le gris, le marron, le noir et le rose..", "Le rose est une couleur qui a une chance d'apparaître très faible, tellement faible que la probabilité pour qu'un mouton un bébé et soit rose en même temps est la probabilité la plus petite du jeu." }, new List<string> { "Mouton" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(3, "Cochon", "passif", "Les cochons sont des créatures passives, on les rencontre très fréquemment dans le jeu. Ils laissent tomber du porc cru une fois tué. S'il est frappé par la foudre, il se mettra sur ses deux pattes arrières et deviendras un cochon zombie.", new List<string>{ "La reproduction de cochon peut se faire avec des carottes et des patates crues.", "Il est possible de les monter en leur mettant une selle sur le dos et en les dirigeant grâce à une canne à pêche avec une carotte au bout." }, new List<string> { "Cochon", "Cochon Zombie" }, new ObservableCollection<Conseil> {conseil}));
            lm.Add(new Monstre(4, "Warden", "BOSS", "Le Warden est un monstre qui a été récemment ajouté au jeu. Il tuera la plupart des joueur en 1 seul coup, c'est pour cela qu'il est considéré comme un boss par la plupart des joueurs..", new List<string> { "Le warden est aveugle mais il entend tous les bruit autour de lui.", "Il apparait dans une caverne spécial appeler Deep Dark (les abîmes en français) quand on y marche en faisant trop de bruit.", "Il s'agit du seul monstre qui ai une animation d'apparation, il sort du sol.", "Lorsque l'on fait trop de bruit grâce à un bloc spécial, le Sculk Hurleur, ce bloc détecte tous bruit et les envoient au Warden qui sortira du sol s'il y a trop de bruit", "Il est capable de tirer des rayon laser à l'endroit d'où proviennes les bruits qu'il entend.", "Il est capable de se baisser pour nous poursuivre dans des endroits petit." }, new List<string> { "Warden" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(5, "EnderDragon", "BOSS", "L'Ender Dragon est le premier boss ajouté à Minecraft. Il est présent dans le monde de l'End et le seul moyen de quitter cette dimension est de le vaincre.", new List<string> { "L'Ender Dragon est le boss de fin de minecraft.", "Il est capable de se régénérer grâce à aux cristaux présent dans sa dimensions. Pour le vaincre, il faut donc tout les détruire.", "Il y a qu'un seul et unique Ender Dragon, aucun autre apparaît sauf s'il est invoqué à nouveaux.", "Le seul moyen de ressusciter le Dragon est de poser 4 Cristal de l'End sur le portail qui permet de revenir dans le monde normal. Ainsi, il sera ressuscité et vous pourrez le vaincre à nouveau.x", "À sa mort, l'Ender Dragon laisse son œuf, il est purement décoratif, mais il n'y en a qu'un seul qui apparaît même après l'avoir vaincu plusieurs fois.", "Si l'Ender Dragon se retrouve dans l'Overworld (le monde normal) grâce à des commandes, chaque bloc qu'il touchera disparaîtra." }, new List<string> { "Ender Dragon" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(6, "Wither", "BOSS", "Le Wither est un boss extrêmement agressive, en effet non seulement il s'attaque au joueur mais également aux animaux et même à certains monstres.", new List<string> { "Grâce à ses trois têtes, il est capable d'attaquer simultanément trois cibles différentes en leur lançant ses têtes qui repoussent instantanément.", "Le Wither n'apparaît pas naturellement, il faut le créer. Pour ce faire, il faut faire un T avec 4 blocks de sable des âmes et trois têtes de wither squelette.", "Les têtes du Wither, si elles vous touchent, vous aurez l'effet wither, cet effet est comparable au poison, mais il peut tuer.", "Il est le seul boss pouvant casser l'obsidienne, le deuxième block le plus dur du jeu." }, new List<string> { "Wither", "Wither low" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(7, "Vache", "passif", "Les vaches sont des créatures passives. Elles fournissent du cuir et de la viande. Il est aussi possible de récupérer du lait avec un seau vide. La vache à une variante qui se nomme, la Champivache, il s'agit d'une vache qui apparaît seulement dans un biome spécial.", new List<string> { "Les vaches apparaissent par groupe de quatre minimums.", "Le lait des vaches enlève tous les effets de potion que vous aurez", "Les champivaches apparaissent seulement dans les biomes champignons. Il s'agit du biome le plus rare du jeu, il est composé d'une terre unique et de champignons.", " Les vaches champignon ont elles aussi une variante, la champivache marron.", "La champivache marron le devient lorsqu'une champivache ce fait frapper pas la foudre.", "Grâce à un bol, il est possible de récupérer des soupes de champivache sur les champivache." }, new List<string> { "Vache", "Vache champi", "Vache champi seche" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(8, "Loup", "passif", "Les loups sont des créatures que l'on peut rencontrer dans les forêts. Ils sont neutres et pourront soit devenir enragés si vous les attaquez, soit devenir votre allié si vous l'apprivoisez.", new List<string> { "Pour apprivoiser un loup il vous faudrat quelques os.", "Ils peuvent vous aidez à chasser des animaux ou des monstres car ils attaquent tous ce que vous attaquez et qui vous attaque.", "Pour leur redonner de la vie, il faut leur donner de la viande. Peut importe le type, ils mangent tous." }, new List<string> { "Loup", "Loup enrage" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(9, "Chat", "passif", "Les chats sont des animaux de compagnie. On les trouve dans les villages. Ils peuvent prendre 11 apparences différentes. Une fois adoptés grâce à du poisson, ils vous suivront partout à moins que vous leur disiez de ne plus bouger.", new List<string> { "Les chats ont la particularité d'effrayer les creepers", "Ils chassent aussi les lapins, qu'ils tuent pour vous ainsi que les bébés tortues.", "Les chats apprivoisés iront directement sur votre lit si vous en possédez un à proximité.  Au réveil, ils peuvent parfois vous faire un cadeau (un objet aléatoire).", "Si un chat apparaît près d'une cabane à sorcière ou à proximité d'une sorcière, il sera automatiquement noir." }, new List<string> { "Chat" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(10, "Zombie", "hostile", "Les zombies sont des monstres lents mais qui peuvent voir les joueurs de très loin. Le seul moyen pour un zombie de faire des dégâts est de frapper à la main le joueur. Il a un cousin qui qui vit seulement dans le desert, le Husk, s'il vous attrape vous aurez l'effet de faim pendant 30sec.", new List<string> { "Les zombies attaquent naturellement les villageois, un villageois attaqué par un zombie mourra et se réincarnera en zombie villageois.", "Le seul moyens de sauver un zombie villageois est de lui lancé une potion de faiblesse et de lui donner un pomme d'or.", "Entourer le zombie villageois de barreaux de fer accélèrera le processus.", "Les zombies peuvent avoir des enfants. Les bébés zombies sont très rapide et diffice à atteindre par leurs petites tailles."}, new List<string> { "Zombie", "Zombie villageois", "Zombie desert" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(11, "Squelette", "hostile", "Les squelettes sont des créatures hostiles. Ils sont des ennemis rapides qui tirent des flèches sur les joueurs. Il existe une variante au squelette classique, le Vagabond. Le vagabond est un squelette qui apparaît uniquement dans les biomes froids. Comme les squelettes classiques, ils apparaissent uniquement la nuit ou dans les endroits sombres.", new List<string> { "Au contact de la lumière du soleil, ils prennent feu et finissent par mourir de leurs brûlures. Il peut arriver que des araignées apparaissent avec un squelette sur leur dos, on les appelle les Araignées Jockey.", "Le vagabond lance des flèches qui donnent l'effet lenteur aux joueurs." }, new List<string> { "Squelette", "Squelette Wither" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(12, "Creeper", "hostile", "Le creeper est une créature verte, pratiquement silencieuse, insidieuse et kamikaze. Une fois qu'il s'est assez rapproché du joueur, le creeper laissera échapper un sifflement sonore et explosera après un à deux secondes. Lorsqu'ils sont frappés par la foudre, les creepers se chargent et se transforment en creeper chargé.", new List<string> { "Il est également possible d'activer l'explosion des creepers manuellement en utilisant un briquet sur eux.", "Les creepers sont silencieux quand ils ne bougent pas et ne prennent pas feu quand ils sont exposé à la lumière du jour. En revanche, ils n'apparaissent que dans des endroits sombres (cavernes ou la nuit).", "Lorsqu'un creeper est tué par un squelette, il laissera tomber un disque.", "Lorsqu'un creeper chargé tue un monstre en explosant, le monstre tué par l'explosion laisseront tomber leurs têtes. De même pour les joueurs." }, new List<string> { "Creeper", "Creeper Chargee" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(13, "Phantom", "hostile", "Les phantoms sont des monstres volants en haute altitude, ils apparaissent uniquement la nuit et au dessus des joueurs n'ayant pas domit depuis au 3 jours.", new List<string> { "Si le joueur fatigué est en extérieur durant la nuit les phantoms apparaissent par groupe de 1 à 4 à 20 blocks de haut.", "Plus les joueurs passent de temps sans dormir, et plus il y a de chances que des phantoms apparaissent en nombre.", "Ils attaquent en faisant un piqué sur le joueur avant de remonter en altitude.", "Le seul moyen d'empêcher leur apparition, est de dormir ou de mourir, ainsi le compteur de fatigue se remettra à zéro." }, new List<string>{"Phantom"}, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(14, "Enderman", "hostile", "L'Enderman est un monstre assez rre dans le monde normal. C'est un mob qui à la possibilité de prendre et de déplacer des blocs.", new List<string> { "Ils ne vous attaqueront pas sauf si vous les regardez directement dans les yeux, ils se téléporteront alors derrière vous et deviendrons extrêmement hostiles.", "L'eau (et donc la pluie) est leur ennemie, en effet au contact de celle-ci, ils perdront de la vie, c'est pourquoi ils se téléporteront instantanément.", "Les Endermans sont omniprésents dans le monde de l'End.", "Comme la plupart des monstres, les Endermans apparaissent seulement dans les endroits sombres." }, new List<string> { "Enderman" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(15, "Slime", "hostile", "Les slimes sont des cubes verts translucides. Ils peuvent être répertoriés dans 3 tailles : Grand, moyen et petit.", new List<string> { "Les slimes peuvent apparaitre à la fois dans des zones éclairées et sombres, mais uniquement dans les couches les plus profondes et dans des endroit plat.", "Ils apparaissent généralement dans de grandes cavernes ou des mines à ciel ouvert, puisqu'ils ont besoin de place.", "Si vous tuez un Gros slime, il peut se diviser en deux, trois ou quatre slime de taille plus petite."}, new List<string> { "Slime" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(16, "Araignee", "hostile", "Les araignées sont agressives au cours de la nuit ou dans l'obscurité, on les reconnait à leurs yeux qui brillent en rouge.", new List<string> { "Elles sont rapide et sont caapble de grimper aux murs.", "Lorsqu'elles poursuivent le joueur pendant la nuit, elles continueront à les chasser durant la journée.", "En journée, elles ne vous attaqeuront pas à moins d'être provoquées", "Il peut arriver que des araignées apparaissent avec un squelette sur leurs dos, on les appelle les Araignées Jockey." }, new List<string> { "Araignee", "Araignee jockey" }, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(17, "Piglin Zombifié", "passif", "Le piglin zombifié est une créature neutre qui devient agressive s'il est attaqué. On le trouve très fréquement dans le nether, mais il est également possible de le rencontrer dans le monde normal où il peut apparaitre depuis un portail du Nether.", new List<string> { "Les pignlins zombies on l'esprits d'équipes, si vous en attaquez un, tous ceux de la zone viendront vous attaquez.", "Ce monstre remplace le cochon zombie, avant que les piglins soit rajouté au jeu en version 1.16, il n'y avait pas des piglin zombifié mais des cochons zombies.", "Ils peuvent aussi apparaître sur des Strider afin de traverser la lave facilement" }, new List<string> { "Piglin zobifie", "Piglin Arpenteur"}, new ObservableCollection<Conseil> { }));
            lm.Add(new Monstre(18, "Strider", "passif", "L'arpenteur est un mob passif du Nether. Il vie dans les profondeurs du Nether, sur l'océan de lave. Lorsqu'il n'est plus sur la lave, il frissone. Il est possible de l'apprivoiser en plaçant une selle sur son dos.", new List<string> { "Une fois sur son dos, on peut controler ses déplacements en tenant en main un champignon biscornu au bout d'un baton.", "Les striders ne craingne pas la chaleur de la lave, en revenche ils prendront de dégât s'il sont en contact avec de l'eau: ce qui est normallement impossible dans le Nether mais possible s'ils franchissent un portail vers le monde normal. La pluie leur inflige également des dégâts.", "Ils apparaissent parfois avec un bébé strider sur eux." }, new List<string> { "Strider", "Strider hors de la lave" }, new ObservableCollection<Conseil> { }));
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
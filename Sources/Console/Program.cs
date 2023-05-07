// See https://aka.ms/new-console-template for more information

using Model;
using System;
using System.Diagnostics.Metrics;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

// Déclaration du STUB
UserBase ub = new UserBase();
MonsterBase monsterBase = new MonsterBase();

//======================================= Fonctions d'affichage ============================================//

///<summary>
///Cette fonction est appelée lors de la fermeture de l'application.
///</summary>
void exitAppConsole()
{
    Console.Clear();
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\tFermeture de l'application...");
    Console.ResetColor();
    Thread.Sleep(800);
    Console.WriteLine("\tA bientôt !");
    Console.WriteLine();
    return;
}

// Cette fonction permet d'écrire une string en rouge, le plus souvent lorsque l'on veut notifier une erreur
void writeLineError(string text)
{
    Console.WriteLine();
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine($"\t{text}");
    Console.ResetColor();
}



//======================================= Menus ============================================//
void menuAccueil(){
    // Si jamais il y a eu des modifications de la couleur du terminal,
    // cela reset le texte en blanc.
    Console.ResetColor();
    int choix;

    do
    {
        choix = ConsoleHelper.MultipleChoice("Menu principal", true,
        "Connexion", "Inscription", "Continuer en tant qu'invité", "Quitter l'application");

        //Traitement du choix de l'utilisateur
        switch (choix)
        {
            case -1:
                // Lorsque l'utilisateur appuie sur Echap, alors quitter l'application.
                exitAppConsole();
                break;
            case 0:
                Console.Clear();
                if (menuConnexion() == -1)
                {
                    exitAppConsole();
                    return;
                }
                
                break;

            case 1:
                Console.Clear();
                if (menuInscription() == -1)
                {
                    exitAppConsole();
                    return;
                }
                break;

            case 2:
                Console.Clear();
                menuMontres();
                break;

            case 3:
                exitAppConsole();
                return;

            default:
                // Pour toutes les autres possiblités non comprise entre -1 et 3
                // (normalement pas possible, mais on est jamais trop prudent)
                Console.Clear();
                writeLineError($"La valeur {choix} n'est pas valide. Fermeture de l'application.");
                return;
        }
    } while ( choix != -1 );
    
    return;
}

int menuConnexion()
{
    string? id, psswd;
    int nbTries = 1; // Initialise le nombre d'essais à 1
    bool exists = false;

    while (exists == false)
    {
        if (nbTries > 3) // Si il y a eu plus de 3 essais effectués
        {
            ConsoleHelper.displayTitle("Connexion", true);
            writeLineError("Trop d'erreurs. Réessayez plus tard.");
            Console.WriteLine();
            Thread.Sleep(1500);
            return -1;
        }
        ConsoleHelper.displayTitle("Connexion", true);
        Console.WriteLine();

        // Saisie de l'identifiant
        Console.Write($"\tEssai n°{nbTries} Identifiant : ");
        id = Console.ReadLine();
        nbTries++;

        if (string.IsNullOrEmpty(id))
        {
            Console.Clear();
            continue;
        }

        // Saisie du mot de passe (affichage avec des étoiles dans la console)
        Console.Write("\tMot de passe : ");
        psswd = ConsoleHelper.ReadPassword();

        if (string.IsNullOrEmpty(psswd))
        {
            Console.Clear();
            continue;
        }

        exists = ub.checkIfExists(id, psswd);
        if ( !exists ) // Si le nom d'utilisateur ou le mot de passe ne correspondent pas,
                       // ou s'ils ne sont pas présent dans la base de données.
        {
            writeLineError("Erreur, identifiant ou mot de passe incorrect.");
            Thread.Sleep(1000); // Pause de 1 seconde pour afficher l'erreur
        }
        else
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\tConnexion réussie !");
            Console.ResetColor ();
            Thread.Sleep(2000); // Pause de 2 secondes
        }
    }
    menuMontres();
    return 0;
}

int menuInscription()
{
    string pseudo;
    string nom;
    string prenom;
    string mdp;
    int n = 1; //Itérateur du nombre d'essais
    while (n <= 4)
    {
        ConsoleHelper.displayTitle("Inscription", false);
        if (n > 3)
        {
            writeLineError("Trop de tentatives. Réessayez plus tard.");
            Console.WriteLine();
            Thread.Sleep(1500);
            return -1;
        }
        Console.WriteLine();
        Console.WriteLine($"\tTentatives (jusqu'à 3) : {n}");
        Console.Write("\tPrénom : ");
        prenom = Console.ReadLine();
        if (string.IsNullOrEmpty(prenom))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("\tNom : ");
        nom = Console.ReadLine();
        if (string.IsNullOrEmpty(nom))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("\tPseudo : ");
        pseudo = Console.ReadLine();
        if (string.IsNullOrEmpty(pseudo))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("\tMot de passe : ");
        mdp = ConsoleHelper.ReadPassword();
        if (string.IsNullOrEmpty(mdp))
        {
            Console.Clear();
            n++;
            continue;
        }

        if(ub.checkIfPseudoExists(pseudo))
        {
            Console.Clear();
            ConsoleHelper.displayTitle("Inscription", true);
            writeLineError("Erreur, ce pseudo est déjà pris.");
            Console.WriteLine();
            System.Threading.Thread.Sleep(1500);
            n++;
        }
        else if (ub.addUser(pseudo, nom, prenom, mdp))
        {
            break;
        }
    }
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine();
    Console.WriteLine("\tInscription réussie !");
    Console.ResetColor ();
    System.Threading.Thread.Sleep(2000); // Pause de 2 secondes
    return 0;
}

int menuMontres()
{
    int choix;
    do
    {
        choix = ConsoleHelper.MultipleChoice("Index des monstres", true,
        "Afficher la liste des montres", "Afficher les informations d'un monstre", "Recherche", "Filtrer", "Retour à l'accueil");

        switch (choix)
        {
            case -1:
                // Lorsque l'utilisateur appuie sur Echap, retourner à l'accueil.
                Console.Clear();
                break;
            case 0:
                Console.Clear();
                displayAllMonsters();
                break;

            case 1:
                Console.Clear();
                //================= A FAIRE =================//
                break;

            case 2:
                Console.Clear();
                rechercheMonstre();
                break;
            case 3:
                Console.Clear();
                //================= A FAIRE =================//
                break;

            case 4:
                return 0;

            default:
                // Pour toutes les autres possiblités non comprise entre -1 et 3
                // (normalement pas possible, mais on est jamais trop prudent)
                Console.Clear();
                writeLineError($"La valeur {choix} n'est pas valide.");
                return -1;
        }
    } while (choix != -1); // Tant que l'utilisateur n'appuie pas sur Echap


    return 0;
}

//======================================= Fonctions d'affichage ============================================//
void displayAllMonsters()
{
    ConsoleHelper.displayTitle("Index des monstres - Affichage des monstres", true);
    displayAllMonstersLegend();
    Console.WriteLine();
    foreach (Monstre m in monsterBase.ListMonsters)
    {
        // Afficher le monstre d'une certaine couleur selon son hostilité
        switch (m.Dangerosite)
        {
            case "hostile":
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine($"\t{m.Name}");
                Console.ResetColor();
                continue;
            case "boss":
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"\t{m.Name}");
                Console.ResetColor();
                continue;
            case "passif":
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine($"\t{m.Name}");
                Console.ResetColor();
                continue;
        }
    }
}

void displayAllMonstersLegend()
{
    Console.Write("Les monstres sont soit ");
    Console.ForegroundColor = ConsoleColor.DarkGreen;
    Console.Write("passifs");
    Console.ResetColor();
    Console.Write(", ");
    Console.ForegroundColor = ConsoleColor.DarkRed;
    Console.Write("hostiles");
    Console.ResetColor();
    Console.Write(" ou ");
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("très agressifs (boss) :");
    Console.ResetColor();
}

// Fonction de recherche de monstre, mise à jour de la liste à chaque touche appuyée
void rechercheMonstre()
{
    List<Monstre> m = new List<Monstre>();
    Console.Clear();
    ConsoleKeyInfo carac;
    string listCarac = "";

    ConsoleHelper.displayTitle("Index des monstres - Recherche", true);
    Console.Write("\tRecherche : ");
    carac = Console.ReadKey(true);
    Console.WriteLine();
    while (carac.Key != ConsoleKey.Enter && carac.Key != ConsoleKey.Escape)
    {
        ConsoleHelper.displayTitle("Index des monstres - Recherche", true);
        Console.Write("\tRecherche : ");
        if (carac.Key != ConsoleKey.Backspace)
        {
            listCarac += carac.KeyChar;
        }
        else if (carac.Key == ConsoleKey.Backspace)
        {
            if (!string.IsNullOrEmpty(listCarac))
            {
                listCarac = listCarac.Remove(listCarac.Length - 1, 1);
            }
        }
        
        Console.Write(listCarac);
        Console.WriteLine();
        Console.WriteLine();
        m = monsterBase.search(listCarac.ToString(), monsterBase);
        foreach (Monstre mnstr in m)
        {
            Console.WriteLine($"\t- {mnstr.Name}");
        }
        carac = Console.ReadKey(true);
    }
    writeLineError("Retour à la page précédente...");
    Thread.Sleep(1000);
}


menuAccueil();
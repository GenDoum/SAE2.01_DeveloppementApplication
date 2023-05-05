// See https://aka.ms/new-console-template for more information

using Model;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Reflection.PortableExecutable;

///Déclaration du STUB

UserBase ub = new UserBase();
MonsterBase monsterBase = new MonsterBase();
/*
void testMonstre()
{
    //Création non permanente d'une liste de caractéristiques (pour tests) -> PEUT-ÊTRE EN FAIRE UNE CLASSE PLUS TARD???
    List<string> charact = new List<string>();
    charact.AddRange(new List<string> { "Caractéristique 1", "C2", "C3", "ENCORE UNE CARACTÉRISTIQUE", "Again and again" });

    //Création non permanente d'une liste d'apparences (pour tests) -> PEUT-ÊTRE EN FAIRE UNE CLASSE PLUS TARD AUSSI???
    List<string> appear = new List<string>();
    appear.AddRange(new List<string> { "Wow1", "Wow2", "Wow3", "ENCORE UNE APPARENCE" });

    Monstre monstre = new Monstre(1, "Warden", "Le Warden est une entité conçue pour vous traquer. Il est comme un GPS vivant capable d'optimiser ses déplacements pour vous contrer," +
        " sachant que s'il n'arrive pas à vous coincer, il pourra toujours utiliser son attaque... [Plus]", charact, appear);
    Console.WriteLine(monstre.IntroduceTest());
    Console.WriteLine();
    Console.WriteLine("Liste de mes caractéristiques :");
    monstre.CharacteristicsList.ForEach(Console.WriteLine);
    Console.WriteLine();
    Console.WriteLine("Liste de mes apparences :");
    monstre.AppearanceList.ForEach(Console.WriteLine);
    Console.WriteLine();
    Console.WriteLine();
    Monstre monstre2 = new Monstre(423, "Mouton", "Je suis un animal présent dans la campagne.", charact, appear);
    Console.WriteLine(monstre2.IntroduceTest());
}*/


int menuAccueil(){
    string? choix;
    Console.WriteLine("Menu - Connexion / Inscription");
    Console.WriteLine("\t1 - Connexion\n\t2 - Inscription\n\t3 - Connexion plus tard\n\t4 - Fermer\n");
    choix = Console.ReadLine();
    while(choix != null)
    {
        if (choix == "1")
        {
            Console.Clear();
            Console.WriteLine("Choix 1");
            menuConnexion();
            return 1;
        }
        else if (choix == "2")
        {
            Console.Clear();
            Console.WriteLine("Choix 2");
            menuInscription();
            return 2;
        }
        else if (choix == "3")
        {
            Console.Clear();
            Console.WriteLine("Choix 3");
            monsterPage();
            return 3;
        }
        else if (choix == "4")
        {
            Console.Clear();
            Console.WriteLine("Exit");
            return 4;
        }
        else
        {
            // Si l'utilisateur entre autre chose que 1, 2, 3 ou 4
            Console.WriteLine("Écris un nombre compris entre 1 et 3, ou juste tape sur la touche Entrée pour quitter.");
        }
    }
    return 0;
}

string ReadPassword()
{
    string psswrd = "";
    ConsoleKeyInfo info = Console.ReadKey(true);
    while (info.Key != ConsoleKey.Enter)
    {
        if (info.Key != ConsoleKey.Backspace)
        {
            Console.Write("*");
            psswrd += info.KeyChar;
        }
        else if (info.Key == ConsoleKey.Backspace)
        {
            if (!string.IsNullOrEmpty(psswrd))
            {
                // Supprime un élément de la liste de char de psswrd
                psswrd = psswrd.Substring(0, psswrd.Length - 1);
                // get the location of the cursor
                int pos = Console.CursorLeft;
                // move the cursor to the left by one character
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
                // replace it with space
                Console.Write(" ");
                // move the cursor to the left by one character again
                Console.SetCursorPosition(pos - 1, Console.CursorTop);
            }
        }
        info = Console.ReadKey(true);
    }
    // Ajoute un alinéa parce que l'utlisateur a validé
    Console.WriteLine();
    return psswrd;
}
int menuConnexion()
{
    string? id;
    string? psswd;
    int i = 1;
    int nbRetries = 0;
    nbRetries++;
    bool exists = false;
    while (exists == false)
    {
        if (nbRetries >= 3)
        {
            return -1;
        }
        Console.Write($"Essai n°{i} Identifiant : ");
        id = Console.ReadLine();
        i++;
        if (id != null)
            id = id.Trim();

        while (string.IsNullOrEmpty(id))
        {
            if (i > 3)
            {
                Console.Clear();
                Console.WriteLine("Trop d'erreurs. Réessayez plus tard.");
                return -2;
            }
            Console.Clear();
            Console.Write($"Essai n°{i} Identifiant : ");
            id = Console.ReadLine();
            if (id != null)
                id = id.Trim();
            i++;
        }

        Console.Write("Mot de passe : ");
        psswd = ReadPassword();
        if (string.IsNullOrEmpty(psswd))
        {
            continue;
        }
        exists = ub.checkIfExists(id, psswd);
        if ( !exists ) // Si le nom d'utilisateur ou le mot de passe ne correspondent pas, ou s'ils ne sont pas présent dans la base de données
        {
            Console.WriteLine("Erreur, identifiant ou mot de passe incorrect.");
        }
    }
    monsterPage();
    return 0;
}

int menuInscription()
{
    string pseudo;
    string nom;
    string prenom;
    string mdp;
    int n = 1; //Itérateur du nombre d'essais
    while (n <= 3)
    {
        Console.WriteLine($"Tentatives : {n}");
        Console.Write("Prénom : ");
        prenom = Console.ReadLine();
        if (string.IsNullOrEmpty(prenom))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("Nom : ");
        nom = Console.ReadLine();
        if (string.IsNullOrEmpty(nom))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("Pseudo : ");
        pseudo = Console.ReadLine();
        if (string.IsNullOrEmpty(pseudo))
        {
            Console.Clear();
            n++;
            continue;
        }
        Console.Write("Mot de passe : ");
        mdp = ReadPassword();
        if (string.IsNullOrEmpty(mdp))
        {
            Console.Clear();
            n++;
            continue;
        }

        if(ub.checkIfPseudoExists(pseudo))
        {
            Console.Clear();
            Console.WriteLine("Erreur, ce pseudo est déjà pris.");
            n++;
        }
        else if (ub.addUser(pseudo, nom, prenom, mdp))
        {
            Console.WriteLine("Utilisateur ajouté avec succès !");
            break;
        }
    }

    if (n >= 3)
    {
        Console.WriteLine("Trop de tentatives. Réessayez plus tard.");
        return -1;
    }

    Console.WriteLine("Inscription réussie !");
    return 0;
}

int monsterPage()
{
    Console.WriteLine("Index des monstres :");
    Console.WriteLine("\n\t1 - Rechercher\n\t2 - Accueil\n");
    string? choix;
    choix = Console.ReadLine();
    if ( choix == "1")
    {
        List<Monstre> m = new List<Monstre>();
        Console.Clear ();
        ConsoleKeyInfo carac = Console.ReadKey(true); ;
        string listCarac = "";
        while (carac.Key != ConsoleKey.Enter)
        {
            
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
            Console.Clear ();
            Console.Write(listCarac);
            Console.WriteLine();
            Console.WriteLine();
            m = monsterBase.search(listCarac.ToString(), monsterBase);
            foreach (Monstre mnstr in m)
            {
                Console.WriteLine($"{mnstr.Name} a été trouvé!");
            }
            carac = Console.ReadKey(true);
        }
        
        return 1;
    }
    
    else
    {
        Console.WriteLine("Entrer un chiffre correct");
    }
    return 0;
}

int codeRetour = menuAccueil();
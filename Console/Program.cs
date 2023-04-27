// See https://aka.ms/new-console-template for more information

using Modèle;
using System;
using System.Reflection.PortableExecutable;

///Déclaration du STUB

UserBase ub = new UserBase();
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


int menuPrincipal(){
    string? choix;
    Console.WriteLine("Menu - Connexion / Inscription");
    Console.WriteLine("\t1 - Connexion\n\t2 - Inscription\n\t3 - Connexion plus tard\n");
    choix = Console.ReadLine();
    if ( choix == "1")
    {
        Console.Clear();
        Console.WriteLine("Choix 1");
        menuConnexion();
        return 1;
    } else if ( choix == "2")
    {
        Console.Clear();
        Console.WriteLine("Choix 2");
        return 2;
    } else if (choix == "3")
    {
        Console.Clear();
        Console.WriteLine("Choix 3");
        return 3;
    } else
    {
        Console.WriteLine("Écris un nombre compris entre 1 et 3");
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
    Console.WriteLine("Identifiant : ");
    id = Console.ReadLine();
    Console.WriteLine("Mot de passe : ");
    psswd = ReadPassword();
    int nbRetries = 0;
    int exists = ub.checkIfExists(id, psswd);
    while (exists == 0)
    {
        if(nbRetries >= 3)
        {
            return -1;
        }
        Console.Clear();
        Console.WriteLine("Erreur, identifiant ou mot de passe incorrect.");
        nbRetries++;
        Console.WriteLine("");
        Console.WriteLine("Identifiant : ");
        id = Console.ReadLine();
        Console.WriteLine("Mot de passe : ");
        psswd = ReadPassword();
        exists = ub.checkIfExists(id, psswd);
    }
    return 0;
}

int codeRetour = menuPrincipal();
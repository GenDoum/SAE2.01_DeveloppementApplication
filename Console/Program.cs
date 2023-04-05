// See https://aka.ms/new-console-template for more information

using Modèle;
using System;
using System.Reflection.PortableExecutable;

//Création non permanente d'une liste de caractéristiques (pour tests) -> PEUT-ÊTRE EN FAIRE UNE CLASSE PLUS TARD???
List<string> charact = new List<string>();
charact.AddRange(new List<string> { "Caractéristique 1", "C2", "C3", "ENCORE UNE CARACTÉRISTIQUE", "Again and again" });

//Création non permanente d'une liste d'apparences (pour tests) -> PEUT-ÊTRE EN FAIRE UNE CLASSE PLUS TARD AUSSI???
List<string> appear = new List<string>();
appear.AddRange(new List<string> { "Wow1", "Wow2", "Wow3", "ENCORE UNE APPARENCE" });

Monstre monstre = new Monstre ( 1, "Warden", "Le Warden est une entité conçue pour vous traquer. Il est comme un GPS vivant capable d'optimiser ses déplacements pour vous contrer," +
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
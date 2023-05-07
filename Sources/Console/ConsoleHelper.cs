using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


public class ConsoleHelper
{
    public static void displayTitle(string title, bool clear)
    {
        if (clear)
        {
            Console.Clear();
        }
        Console.ForegroundColor = ConsoleColor.Green; //Ecris le titre suivant en vert
        Console.WriteLine();
        Console.WriteLine($"-==============- {title} -==============-");
        Console.WriteLine();
        Console.ResetColor();   //Reset la couleur du texte par défaut (à blanc)
    }

    public static string ReadPassword()
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
                    // Récupère la position du curseur
                    int pos = Console.CursorLeft;
                    // Déplace le curseur d'un à gauche
                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                    // Remplace par un espace dans la console
                    Console.Write(" ");
                    // Déplace le curseur d'une position à gauche encore
                    Console.SetCursorPosition(pos - 1, Console.CursorTop);
                }
            }
            info = Console.ReadKey(true);
        }
        // Ajoute un alinéa parce que l'utlisateur a validé
        Console.WriteLine();
        return psswrd;
    }
    public static int MultipleChoice(string title, bool canCancel, params string[] options)
    {
        displayTitle(title, true);
        // Uint = unsigned int -> pour pas que le décalage soit négatif et entraine une exception
        const uint startX = 11; // Décalage à partir de la gauche
        const uint startY = 4;   // Décalage à partir du haut
        const int optionsPerLine = 1;
        const int spacingPerLine = 50;
        int currentSelection = 0;

        ConsoleKey key;

        Console.CursorVisible = false;

        do
        {
            
            for (int i = 0; i < options.Length; i++)
            {
                Console.SetCursorPosition((int)(startX + (i % optionsPerLine) * spacingPerLine), (int)(startY + i / optionsPerLine));

                if (i == currentSelection)
                    Console.ForegroundColor = ConsoleColor.Blue;

                Console.Write(options[i]);

                Console.ResetColor();
            }

            key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.LeftArrow:
                    {
                        if (currentSelection % optionsPerLine > 0)
                            currentSelection--;
                        break;
                    }
                case ConsoleKey.RightArrow:
                    {
                        if (currentSelection % optionsPerLine < optionsPerLine - 1)
                            currentSelection++;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        if (currentSelection >= optionsPerLine)
                            currentSelection -= optionsPerLine;
                        break;
                    }
                case ConsoleKey.DownArrow:
                    {
                        if (currentSelection + optionsPerLine < options.Length)
                            currentSelection += optionsPerLine;
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        if (canCancel)
                            return -1;
                        break;
                    }
            }
        } while (key != ConsoleKey.Enter);

        Console.CursorVisible = true;

        return currentSelection;
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;


namespace System {
    public static class ConsoleHelper
    {
        public static void displayTitle(string title, bool clear)
        {
            if (clear)
            {
                System.Console.Clear();
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
            ConsoleKeyInfo info = System.Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    System.Console.Write("*");
                    psswrd += info.KeyChar;
                }
                else if (info.Key == ConsoleKey.Backspace && !string.IsNullOrEmpty(psswrd))
                {
                    // Supprime un élément de la liste de char de psswrd
                    psswrd = psswrd.Substring(0, psswrd.Length - 1);
                    // Récupère la position du curseur
                    int pos = System.Console.CursorLeft;
                    // Déplace le curseur d'un à gauche
                    System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                    // Remplace par un espace dans la console
                    System.Console.Write(" ");
                    // Déplace le curseur d'une position à gauche encore
                    System.Console.SetCursorPosition(pos - 1, System.Console.CursorTop);
                }
                info = System.Console.ReadKey(true);
            }
            // Ajoute un alinéa parce que l'utlisateur a validé
            System.Console.WriteLine();
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

            System.Console.CursorVisible = false;

            do
            {
            
                for (int i = 0; i < options.Length; i++)
                {
                    System.Console.SetCursorPosition((int)(startX + (i % optionsPerLine) * spacingPerLine), (int)(startY + i / optionsPerLine));

                    if (i == currentSelection)
                        System.Console.ForegroundColor = ConsoleColor.Blue;

                    System.Console.Write(options[i]);

                    System.Console.ResetColor();
                }

                key = System.Console.ReadKey(true).Key;

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

            System.Console.CursorVisible = true;

            return currentSelection;
        }
    }
}
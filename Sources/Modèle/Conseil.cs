using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Modèle
{
    /// <summary>
    /// La classe conseil permet à un utilisateur de poster un conseil sur la page d'un monstre.
    /// Il est composé d'un auteur(public), un texte(string), un monstre(Monstre) ainsi que
    /// deux méthodes : addConseil et removeConseil
    /// </summary>
    public class Conseil
    {
        public User Auteur { get; set; }
        public string Texte { get; private set; }
        public Monstre LeMonstre { get; set; }

        public Conseil(User auteur, string texte, Monstre monstre)
        {
            // Test pour voir si le conseil est vide 
            if ( string.IsNullOrWhiteSpace(texte) )
            {
                throw new ArgumentException("Vous ne pouvez pas postez un commentaire sans texte !");
            }

            // Essaye de convertir le paramètre monstre en int 
            // Problème je pense que le type Monstre ne va pas
            bool isMonstreNumeric = int.TryParse(monstre, out _);

            // Test si le nom du monstre est correct
            if ( isMonstreNumeric ) 
            {
                throw new FormatException("Veuillez entrer un nom de Monstre correct.");
            }
            

            Auteur = auteur;
            Texte = texte;  
            LeMonstre = monstre;
        }

        public void addConseil()
        {

        }

        public void removeConseil()
        {

        }

    }
}

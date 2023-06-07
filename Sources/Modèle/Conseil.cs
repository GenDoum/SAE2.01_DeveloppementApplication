using Model;
using Modèle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;



namespace Model
{
    /// <summary>
    /// La classe conseil permet à un utilisateur de poster un conseil sur la page d'un monstre.
    /// Il est composé d'un auteur(public), un texte(string), un monstre(Monstre) ainsi que
    /// deux méthodes : addConseil et removeConseil
    /// </summary>

    [DataContract]
    public class Conseil // J'ai l'impression d'avoir oublié de faire un truc important masi je sais pas quoi
    {
        [DataMember(Order = 1)]
        // Faire une condition du supression il fut que la personne qui ai créé le conseil soit la même que celle qui suprime le conseil.
        public readonly int Id = 0;
        int idConseil = 0; // Initialisateur de ID
        [DataMember(Order = 2)]
        public User Auteur { get; set; }
        [DataMember(Order = 3)]
        public string Texte { get; private set; }
        [DataMember(Order = 4)]
        public Monstre LeMonstre { get; set; }

        public Conseil(User auteur, string texte, Monstre leMonstre)
        {
            if (string.IsNullOrWhiteSpace(texte))
            {
                throw new ArgumentException("Vous ne pouvez pas poster un commentaire sans texte !");
            }

            if (auteur == null)
            {
                throw new ArgumentNullException(nameof(auteur), "L'auteur ne peut pas être nul !");
            }

            if (leMonstre == null)
            {
                throw new ArgumentNullException(nameof(leMonstre), "Le monstre ne peut pas être nul !");
            }
            Id = idConseil;
            idConseil++;
            Auteur = auteur;
            Texte = texte;
            LeMonstre = leMonstre;
        }
        // FONCTION A DEPLACER -> Dans la console, ON AFFICHE RIEN DANS LE MODEL DJSKLFJDKLFJ :>
        public void affichConseil()
        {
            Console.WriteLine($"Id : {Id}");
            Console.WriteLine($"Auteur : {Auteur.Pseudo}");
            Console.WriteLine($"Monstre : {LeMonstre.Name}");
            Console.WriteLine($"Conseil : {Texte}");
        }
    }
}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Runtime.CompilerServices;
using Xunit;

namespace Model
{
    /// <summary>
    /// La classe User représente un utilisateur ayant pour identifiant son pseudo (publique),
    /// son nom et prénom en privé, pour une utilisation ultérieure et/ou pour identifier de manière
    /// plus simple l'utilisateur dans la base de donnée (car un pseudo n'est pas forcément explicite)
    /// </summary>
    [DataContract]
    public class User : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

    void OnPropertyChanged([CallerMemberName]string propertyName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        [DataMember(Order = 3)]
        public string Pseudo 
        {
            get => Pseudo;
            set
            {
                if (Pseudo == value)
                    return;
                Pseudo = value;
                OnPropertyChanged();
            }
        }

        [DataMember(Order = 1)]
        public string Nom
        {
            get => Nom;
            set
            {
                if (Nom == value)
                    return;
                Nom = value;
                OnPropertyChanged();
            }
        }

        [DataMember(Order = 2)]
        public string Prenom
        {
            get => Prenom;
            set
            {
                if (Prenom == value)
                    return;
                Prenom = value;
                OnPropertyChanged();
            }
        }

        [DataMember(Order = 4)]
        private string Mdp
        {
            get => Mdp;
            set
            {
                if (Mdp == value)
                    return;
                Mdp = value;
                OnPropertyChanged();
            }
        }


        [DataMember]
        public List<Monstre>? monstresDejaVu { get; private set; }

        public User(string pseudo, string nom, string prenom, string mdp, List<Monstre>? monstresVus = null)
        {

            if (string.IsNullOrWhiteSpace(pseudo) || string.IsNullOrWhiteSpace(nom) || string.IsNullOrWhiteSpace(prenom) || string.IsNullOrWhiteSpace(mdp))
            {
                throw new ArgumentException("Un User doit avoir un pseudo, un nom, un prénom et un mot de passe au minimum !");
            }

            //Essaye de convertir les paramètres du constructeur (excepté le mot de passe) en int, renvoie true si c'est possible
            bool isPseudoNumeric = int.TryParse(pseudo, out _);
            bool isNomNumeric = int.TryParse(nom, out _);
            bool isPrenomNumeric = int.TryParse(prenom, out _);

            //Si une des variables est convertissable en int, alors c'est une chaine de caractère uniquement composée de nombres
            if (isPseudoNumeric || isNomNumeric || isPrenomNumeric)
            {
                //Alors on renvoie une exception appelée "FormatException"
                throw new FormatException("Un User ne peux pas avoir de pseudo/nom/prénom composé uniquement de nombres !");
            }
            Pseudo = pseudo;
            Nom = nom;
            Prenom = prenom;
            Mdp = mdp;
            monstresDejaVu = monstresVus;
        }
        
        /*
        public User()
        {
            Pseudo = null;
            Nom = null;
            Prenom = null;
            Mdp = null;
            monstresDejaVu = null;
        }
        */

        public bool verifyPssw(string pssw)
        {
            if(pssw.Equals(Mdp))
            {
                return true;
            }
            return false;
        }
    }
}

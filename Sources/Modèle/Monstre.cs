using Modèle;
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace Model
{

    [DataContract]
    public class Monstre : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        [DataMember(Order = 1)]
        public int Id { get; set; } // ID

        [DataMember(Order = 2)]
        public string Name
        {
            get => name;
            set
            {
                if (name == value)
                    return;
                name = value;
                OnPropertyChanged("Name");
            }
        }
        private string name; // Nom

        [DataMember(Order = 3)]
        public string Dangerosite { get; private init; } // Dangerosité
        //EN FAIT IL FAUDRAIT FAIRE UN ENUM DU TYPE DE DANGEROSITÉ, pour rajouter lors de
        //l'affichage de la liste des monstres une couleur selon ça,
        //genre rouge dangereux, violet hyper dangereux, et vert passif

        [DataMember(Order = 4)]
        public string Description
        {
            get => description;
            set
            {
                if (description == value)
                    return;
                description = value;
                OnPropertyChanged("Description");
            }
        }
        private string description; // Description

        [DataMember(Order = 5)]
        public List<string> CharacteristicsList // Liste des caractéristiques
        {
            get; init;
        }

        [DataMember(Order = 6)]
        public List<string> AppearanceList // Liste des apparences
        {
            get; init;
        }

        public List<Conseil> ListConseils { get; set; }

        public string ImageLink { get; init ; }
        public Monstre(int id, string name, string danger, string desc, List<string> characList, List<string> appearList, List<Conseil> conseilList)
        {
            Id = id;
            Name = name;
            Dangerosite = danger;
            Description = desc;
            CharacteristicsList = characList;
            AppearanceList = appearList;
            ListConseils = conseilList;
            ImageLink = name.ToLower() + ".png";

            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(danger))
            {
                throw new ArgumentException("Un monstre doit avoir un nom, une description et une dangerosité!");
            }
        }
    }
} 
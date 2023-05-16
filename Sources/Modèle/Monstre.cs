using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.Serialization;

namespace Model
{

    [DataContract]
    public class Monstre
    {
        [DataMember(Order = 1)]
        public int Id { get; set; }

        [DataMember(Order = 2)]
        public string Name { get; set; }

        [DataMember(Order = 3)]
        public string Dangerosite { get; private init; }
        //EN FAIT IL FAUDRAIT FAIRE UN ENUM DU TYPE DE DANGEROSITÉ, pour rajouter lors de
        //l'affichage de la liste des monstres une couleur selon ça,
        //genre rouge dangereux, violet hyper dangereux, et vert passif

        [DataMember(Order = 4)] 
        public string Description { get; set; }

        [DataMember(Order = 5)]
        public List<string> CharacteristicsList
        {
            get; init;
        }

        [DataMember(Order = 6)]
        public List<string> AppearanceList
        {
            get; init;
        }

        public Monstre(int id, string name, string danger, string desc, List<string> characList, List<string> appearList)
        {
            Id = id;
            Name = name;
            Dangerosite = danger;
            Description = desc;
            CharacteristicsList = characList;
            AppearanceList = appearList;
            if (string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(Description) || string.IsNullOrWhiteSpace(danger))
            {
                throw new ArgumentException("Un monstre doit avoir un nom, une description et une dangerosité!");
            }
        }
    }
}


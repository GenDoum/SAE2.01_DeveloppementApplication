using System.ComponentModel;
using System.Reflection.Metadata;

namespace Model;

public class Monstre
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Dangerosite { get; private init; }
        //EN FAIT IL FAUDRAIT FAIRE UN ENUM DU TYPE DE DANGEROSITÉ, pour rajouter lors de
        //l'affichage de la liste des monstres une couleur selon ça,
        //genre rouge dangereux, violet hyper dangereux, et vert passif
    public string Description { get; set; }
    
    
    public List<string> CharacteristicsList
    {
        get; private init;
    }

    
    public List<string> AppearanceList
    {
        get; private init;
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
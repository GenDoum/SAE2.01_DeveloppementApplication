using System.ComponentModel;
using System.Reflection.Metadata;

namespace Modèle;

public class Monstre
{
    public int Id { get; set; } = 1;
    public string Name { get; set; }
    public string Description { get; set; } = string.Empty;
    
    private List<string> characteristic = null!;
    public List<string> CharacteristicsList
    {
        get {
            return characteristic;
        }
        set {
            characteristic = value;
        }
    }
    
    private List<string> appearance = null!;
    public List<string> AppearanceList
    {
        get
        {
            return appearance;
        }
        set
        {
            appearance = value;
        }
    }

    public string IntroduceTest()
    {
        return $"Je suis un {Name} (id : {Id}). Description : {Description}";
    }
    public Monstre(int id, string name, string desc, List<string> characList, List<string> appearList)
    {
        Id = id;
        Name = name;
        Description = desc;
        CharacteristicsList = characList;
        AppearanceList = appearList;
    }
}
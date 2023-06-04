using Model;
using System.Collections.ObjectModel;

namespace Tests
{
    public class Conseil_UT
    {
        [Fact]
        public void TestFullConstructor()
        {
            User userUT = new User("test", "test", "test", "test", new List<Monstre> { });
            User userUT2 = new User("test", "test", "test", "test", new List<Monstre> { });
            Monstre monstreUT= new Monstre(15, "Slime", "hostile", "Les slimes sont des cubes verts translucides.", new List<string> { "Les slimes peuvent apparaitre à la fois dans des zones éclairées et sombres." }, new List<string> { "Slime" }, new ObservableCollection<Conseil> { });
            Monstre monstreUT2= new Monstre(15, "Slime", "hostile", "Les slimes", new List<string> { "Les slimes peuven." }, new List<string> { "Slime" }, new ObservableCollection<Conseil> { });
            Conseil conseilTest = new Conseil(userUT, "Conseil de fou furieux", monstreUT);
            Assert.NotNull(conseilTest);
            Assert.Equal(userUT2, conseilTest.Auteur); // Pas sur de l'utilité vu que les Monstre et User on déjà leurs tests
            Assert.Equal("Conseil un peu nul", conseilTest.Texte);
            Assert.Equal(monstreUT2, conseilTest.LeMonstre); // Same
        }

        [Fact]
        public void TestVoidConstructor() 
        {
            User userUT = new User("test", "test", "test", "test", new List<Monstre> { });
            Monstre monstreUT = new Monstre(15, "Slime", "hostile", "Les slimes sont des cubes verts translucides.", new List<string> { "Les slimes peuvent apparaitre à la fois dans des zones éclairées et sombres." }, new List<string> { "Slime" }, new ObservableCollection<Conseil> { });
            Conseil conseilTest = new Conseil(userUT, "woaaaaa", monstreUT);
            Assert.Throws<ArgumentException>(() => new Conseil(userUT, "", monstreUT));
        }
    }
}

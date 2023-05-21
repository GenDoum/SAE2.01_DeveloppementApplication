using Model;
using Modèle;

namespace Tests

{
    public class Monstres_UT
    {
        [Fact]
        public void TestFullConstructor()
        {
            Monstre a = new Monstre(0, "Name", "Hostility", "This is my description", new List<string> { "Carac 1", "Carac 2", "Carac 3" }, new List<string> { "App 1", "App 2", "App 3" }, new List<Conseil>());
            User usetUT = new User("pseudo", "nom", "prenom", "mdp", new List<Monstre>());
            Conseil conseilUT = new Conseil(usetUT, "conseil de fou furieux", a);
            Assert.NotNull(a);
            Assert.Equal("Name", a.Name);
            Assert.Equal("Hostility", a.Dangerosite);
            Assert.Equal("This is my description", a.Description);
            Assert.Equal(new List<string> { "Carac 1", "Carac 2", "Carac 3" }, a.CharacteristicsList);
            Assert.Equal(new List<string> { "App 1", "App 2", "App 3" }, a.AppearanceList);

            
        }

        [Fact]
        public void TestVoidConstructor()
        {
            Monstre a = new Monstre(0, "Name", "Hostility", "This is my description", new List<string> { "Carac 1", "Carac 2", "Carac 3" }, new List<string> { "App 1", "App 2", "App 3" }, new List<Conseil>());
            User usetUT = new User("pseudo", "nom", "prenom", "mdp", new List<Monstre>());
            Conseil conseilUT = new Conseil(usetUT, "conseil de fou furieux", a);
            Assert.Throws<ArgumentException>(() => new Monstre(0, "", "", "", new List<string> { "" }, new List<string> { "" }, new List<Conseil> {conseilUT}));
        }
    }
}
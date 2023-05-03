using Mod�le;

namespace Tests

{
    public class User_UT
    {

        [Theory]
        [MemberData(nameof(DataWithoutList))]
        public void TestConstructorWithoutList(string pseudo, string nom, string prenom, string mdp)
        {
            Assert.Throws<ArgumentException>(() => new User(pseudo, nom, prenom, mdp));
            /*User u = new User(pseudo, nom, prenom, mdp);
            Assert.Equal(pseudo, u.Pseudo);
            Assert.Equal(nom, u.Nom);
            Assert.Equal(prenom, u.Prenom);
            Assert.True(u.verifyPssw(mdp));*/
        }

        public static IEnumerable<object[]> DataWithoutList =>
            new List<object[]>
            {
                //Test de toutes les possibilit�s
                new object[] { "", "", "", "" },
                new object[] { "Pseudo", "", "", "" },
                new object[] { "", "Nom", "", "" },
                new object[] { "Pseudo", "Nom", "", "" },
                new object[] { "", "", "Prenom", "" },
                new object[] { "Pseudo", "", "Prenom", "" },
                new object[] { "", "Nom", "Prenom", "" },
                new object[] { "Prenom", "Nom", "Prenom", "" },
                new object[] { "", "", "", "Mdp" },
                new object[] { "Pseudo", "", "", "Mdp" },
                new object[] { "", "Nom", "", "Mdp" },
                new object[] { "Pseudo", "Nom", "", "Mdp" },
                new object[] { "", "", "Prenom", "Mdp" },
                new object[] { "Pseudo", "", "Prenom", "Mdp" },
                new object[] { "", "Nom", "Prenom", "Mdp" },
                new object[] { "Pseudo", "Nom", "Prenom", "Mdp" },

                //Puis quelques tests avec des ints au lieu de strings
                new object[] { 0, "Nom", "Prenom", "Mdp" },
                new object[] { "Pseudo", 0, "Prenom", "Mdp" },
                new object[] { "Pseudo", "Nom", 0, "Mdp" },
                new object[] { "Pseudo", "Nom", "Prenom", 0 },
                new object[] { 1, 12, 123, 1234}
            };

        [Theory]
        [MemberData(nameof(DataWithList))]
        public void TestConstructorWithList(string pseudo, string nom, string prenom, string mdp, List<Monstre> monstresVus)
        {
            if (Assert.Throws<ArgumentException>(() => new User(pseudo, nom, prenom, mdp, monstresVus)) == null ) {
                return;
            }
            User u = new User(pseudo, nom, prenom, mdp, monstresVus);

            Assert.Equal(pseudo, u.Pseudo);
            Assert.Equal(nom, u.Nom);
            Assert.Equal(prenom, u.Prenom);
            Assert.True(u.verifyPssw(mdp));
            Assert.Equal(monstresVus, u.monstresDejaVu);
        }

        public static IEnumerable<object[]> DataWithList =>
            new List<object[]>
            {
            new object[] { "Pseudo", "Nom", "Prenom", "Mdp", new List<Monstre> { new Monstre(1, "Poule",
                                                                                                "Je suis un animal pr�sent un peu partout, sauf dans le desert car il fait beaucoup trop chaud. Mais j'aime beaucoup la jungle !", 
                                                                                                new List<string> { "Quand une poule est tu�e, il y a 3.12% de chance que la poule laisse tomber un oeuf " }, 
                                                                                                new List<string> { "Apparence1", "App2", "App3" } ),
                                                                                 new Monstre(2, "Mouton", 
                                                                                                "Je suis pr�sent un peu partout, sauf dnas le desert.", 
                                                                                                new List<string> { "Avec une cisaille il est possible de raser la laine d'un mouton, il se retrouvera sans laine.", "Pour faire repousser la laine d'un mouton, il faut qu'il ait de l'herbe sous ses pattes pour qu'il puisse manger. Une fois mang�, la laine du mouton repousse instantan�ment !" }, 
                                                                                                new List<string> { "Apparence1", "App2", "App3" } )} },
            new object[] { "", "", "", "", new List<Monstre> { new Monstre(1, "Poule",
                                                                                                "Je suis un animal pr�sent un peu partout, sauf dans le desert car il fait beaucoup trop chaud. Mais j'aime beaucoup la jungle !",
                                                                                                new List<string> { "Quand une poule est tu�e, il y a 3.12% de chance que la poule laisse tomber un oeuf " },
                                                                                                new List<string> { "Apparence1", "App2", "App3" } ),
                                                                                 new Monstre(2, "Mouton",
                                                                                                "Je suis pr�sent un peu partout, sauf dnas le desert.",
                                                                                                new List<string> { "Avec une cisaille il est possible de raser la laine d'un mouton, il se retrouvera sans laine.", "Pour faire repousser la laine d'un mouton, il faut qu'il ait de l'herbe sous ses pattes pour qu'il puisse manger. Une fois mang�, la laine du mouton repousse instantan�ment !" },
                                                                                                new List<string> { "Apparence1", "App2", "App3" } )} },
            new object[] { "", "", "", "", new List<Monstre>() },
            new object[] { "Pseudo", "", "", "", new List<Monstre>() },
            new object[] { "Pseudo", "Nom", "", "", new List<Monstre>() },
            new object[] { "Pseudo", "Nom", "Prenom", "", new List<Monstre>() },
            new object[] { "Pseudo", "Nom", "Prenom", "Mdp", new List<Monstre>() },
            new object[] { 0, "Nom", "Prenom", "Mdp", new List<Monstre>() },
            new object[] { "Pseudo", 0, "Prenom", "Mdp", new List<Monstre>() },
            new object[] { "Pseudo", "Nom", 0, "Mdp", new List<Monstre>() },
            new object[] { "Pseudo", "Nom", "Prenom", 0, new List<Monstre>() },
            new object[] { 1, 12, 123, 1234, 12345 }
            };
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace Tests
{
    public class Conseil_UT
    {
        User userTest = new User("Moi", "Monchanin", "Liam", "feur", new List<Monstre> { });
        Monstre monstreTest = new Monstre(2, "Mouton", "passif", "Les moutons sont des créatures passives.", new List<string> { "Avec une cisaille, il est possible de rasé la laine d'un mouton"}, new List<string> { "Mouton" }, new ObservableCollection<Conseil> { });

        [Fact]
        public void ConseilConstructorGood()
        {
            string texte = "Ceci est un conseil.";

            Conseil conseil = new Conseil(userTest, texte, monstreTest);
            Assert.Equal(userTest, conseil.Auteur);
            Assert.Equal(texte, conseil.Texte);
            Assert.Equal(monstreTest, conseil.LeMonstre);
        }

        [Fact]
        public void ConseilConstructorNullUser()
        {
            string texte = "Ceci est un conseil.";

            Assert.Throws<ArgumentNullException>(() => new Conseil(null, texte, monstreTest));
        }

        [Fact]
        public void ConseilConstructorNullMonster()
        {
            string texte = "Ceci est un conseil.";

            Assert.Throws<ArgumentNullException>(() => new Conseil(userTest, texte, null));
        }

        [Fact]
        public void ConseilConstructorTextVide()
        {
            // Arrange
            string texte = "";

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Conseil(userTest, texte, monstreTest));
        }
    }
}

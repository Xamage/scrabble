using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class DictionnaireTests
    {
        [TestMethod]
        public void TrouverLePlusLongAvecTocaabs()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");
            
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecTocaabs()
        {
            Sac sac = Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");
            
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecKkktzuk()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzuk()
        {
            Sac sac = Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlanche()
        {
            Sac sac = Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("BN#");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 6, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }
    }
}
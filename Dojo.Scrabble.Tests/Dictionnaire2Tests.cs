using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class Dictionnaire2Tests
    {
        static readonly Dictionnaire2 _dictionnaire = Dictionnaire2.Charger(@"C:\github\scrabble\ListeMots.txt");
        static Sac _sac = Sac.Charger(@"C:\github\scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }
        
        [TestMethod]
        public void TrouverLePlusLongAvecTocaabs()
        {
            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = _dictionnaire.TrouverLesMotsLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecTocaabs()
        {
            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = _dictionnaire.TrouverLesMotsLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecKkktzuk()
        {
            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotsLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzuk()
        {
            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotsLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlanche()
        {
            Chevalet chevalet = new Chevalet("BN#");

            var actual = _dictionnaire.TrouverLesMotsLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 6, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecDeuxLettresBlanche()
        {
            Chevalet chevalet = new Chevalet("#B#");

            var actual = _dictionnaire.TrouverLesMotsLesPlusLongs(chevalet);

            Assert.AreEqual(62, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecTisteEtDeuxLettresBlanches()
        {
            Chevalet chevalet = new Chevalet("T#I#STE");

            var actual = _dictionnaire.TrouverLesMotsLesPlusLongs(chevalet);

            Assert.AreEqual(139, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
        }

        [TestMethod]
        public void TempsChargement()
        {
            Dictionnaire2 dictionnaire = null;
            string[] combinaisons = null;
            Chevalet chevalet = new Chevalet("TOCAABS");
            long elapsed;
             
            // Chargement du dictionnaire
            elapsed = Chronometrer(() => dictionnaire = Dictionnaire2.Charger(@"C:\github\scrabble\ListeMots.txt"));
            TestContext.WriteLine("Temps de chargement du dictionnaire : {0} ms", elapsed);

            // Chargement du sac de lettres
            elapsed = Chronometrer(() => Sac.Charger(@"C:\github\scrabble\Lettres.txt"));
            TestContext.WriteLine("Temps de chargement du sac : {0} ms", elapsed);

            // Recherche des mots les plus longs
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotsLesPlusLongs(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus longs pour 'TOCAABS' : {0} ms", elapsed);

            // Recherche des mots les plus forts
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotsLesPlusForts(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus forts pour 'TOCAABS' : {0} ms", elapsed);

            chevalet = new Chevalet("T#I#STE");

            // Recherche des mots les plus longs
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotsLesPlusLongs(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus longs pour 'T#I#STE' : {0} ms", elapsed);

            // Recherche des mots les plus forts
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotsLesPlusForts(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus forts pour 'T#I#STE' : {0} ms", elapsed);
        }

        static long Chronometrer(Action action)
        {
            Stopwatch chrono = Stopwatch.StartNew();
            action();
            chrono.Stop();

            return chrono.ElapsedMilliseconds;
        }
    }
}
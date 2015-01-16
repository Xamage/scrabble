using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class DictionnaireTests
    {
        static readonly Dictionnaire _dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");
        static Sac _sac = Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres

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
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecTocaabsSansChargementDictionnaire()
        {
            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }
        
        [TestMethod]
        public void TrouverLePlusFortAvecTocaabs()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecTocaabsSansChargements()
        {
            Chevalet chevalet = new Chevalet("TOCAABS");

            var actual = _dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecKkktzuk()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecKkktzukSansChargement()
        {
            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzuk()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzukSansChargement()
        {
            Chevalet chevalet = new Chevalet("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlanche()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("BN#");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 6, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet("BN#");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

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
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("#B#");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.AreEqual(62, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }
        
        [TestMethod]
        public void TrouverLePlusLongAvecDeuxLettresBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet("#B#");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.AreEqual(62, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecTisteEtDeuxLettresBlanche()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet("T#I#STE");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.AreEqual(139, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecTisteEtDeuxLettresBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet("T#I#STE");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.AreEqual(139, actual.Count(), "La recherche n'a pas retourné le bon nombre de résultats");
        }

        [TestMethod]
        public void TempsChargement()
        {
            Dictionnaire dictionnaire = null;
            string[] combinaisons = null;
            Chevalet chevalet = new Chevalet("TOCAABS");
            long elapsed;

            // Chargement du dictionnaire
            elapsed = Chronometrer(() => dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt"));
            TestContext.WriteLine("Temps de chargement du dictionnaire : {0} ms", elapsed);

            // Chargement du sac de lettres
            elapsed = Chronometrer(() => Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"));
            TestContext.WriteLine("Temps de chargement du sac : {0} ms", elapsed);

            // Génération des combinaisons
            elapsed = Chronometrer(() => combinaisons = chevalet.GetAllCombinaisons().ToArray());
            TestContext.WriteLine("Temps de génération des {0} combinaisons : {1} ms", combinaisons.Length, elapsed);

            // Recherche des mots les plus longs
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotLesPlusLongs(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus longs pour 'TOCAABS' : {0} ms", elapsed);

            // Recherche des mots les plus forts
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotLesPlusForts(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus forts pour 'TOCAABS' : {0} ms", elapsed);

            chevalet = new Chevalet("T#I#STE");

            // Recherche des mots les plus longs
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotLesPlusLongs(chevalet));
            TestContext.WriteLine("Temps de recherche des mots les plus longs pour 'T#I#STE' : {0} ms", elapsed);

            // Recherche des mots les plus forts
            elapsed = Chronometrer(() => dictionnaire.TrouverLesMotLesPlusForts(chevalet));
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
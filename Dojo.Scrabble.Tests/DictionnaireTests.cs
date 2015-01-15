using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class DictionnaireTests
    {
        static readonly Dictionnaire _dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");
        static Sac _sac = Sac.FromFile(@"C:\dojo\Scrabble\Lettres.txt"); // Il faut charger un sac pour avoir les valeurs des lettres
        
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
        public void TrouverLePlusLongAvecTocaabsSansChargementDictionnaire()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

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
            
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 3, "");
            Assert.IsTrue(actual.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecTocaabsSansChargements()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

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

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecKkktzukSansChargement()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzuk()
        {
            Dictionnaire dictionnaire = Dictionnaire.FromFile(@"C:\dojo\Scrabble\ListeMots.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusFortAvecKkktzukSansChargement()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("KKKTZUK");

            var actual = _dictionnaire.TrouverLesMotLesPlusForts(chevalet);

            Assert.IsTrue(actual.Count() == 1, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "ZUT"), "ZUT n'a pas été trouvé");
        }

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlanche()
        {
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

        [TestMethod]
        public void TrouverLePlusLongAvecLettreBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("BN#");

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
        public void TrouverLePlusLongAvecDeuxLettresBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("#B#");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 63, "La recherche n'a pas retourné le bon nombre de résultats");
            Assert.IsTrue(actual.Any(m => m == "BAN"), "BAN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BEN"), "BEN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BON"), "BON n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "BUN"), "BUN n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "NIB"), "NIB n'a pas été trouvé");
            Assert.IsTrue(actual.Any(m => m == "IBN"), "IBN n'a pas été trouvé");
        }
        
        [TestMethod]
        public void TrouverLePlusLongAvecTisteEtDeuxLettresBlancheSansChargement()
        {
            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("T#I#STE");

            var actual = _dictionnaire.TrouverLesMotLesPlusLongs(chevalet);

            Assert.IsTrue(actual.Count() == 188, "La recherche n'a pas retourné le bon nombre de résultats");
            
            var expected = new[]
            {
                "TEINTES", "TRIATES", "TRISTES", "TWISTES", "TWISTEE", "TRISTES", "TWISTEE", "TWISTER", "TWISTES", "TWISTEZ", "TAISENT", "TOISENT", "TAOISTE", "TAXISTE", "THEISTE", "TITISTE",
                "TUBISTE", "TUCISTE", "TACITES", "TAPITES", "TARITES", "TOLITES", "TRAITES", "TRUITES", "TESTIEZ", "TETINES", "TITISME", "TITISTE", "TITRISE", "TUTHIES", "TUTOIES", "TUTSIES",
                "TUTSIES", "THEISTE", "TITISTE", "TIPATES", "TIRATES", "TISATES", "TICKETS", "TISSENT", "TINTEES", "TINTEES", "TISATES", "TISSENT", "TITRISE", "TITANES", "TITREES", "TITUBES",
                "TITISME", "TITISTE", "TITREES", "TIENTOS", "TERSAIT", "TENTAIS", "TESTAIS", "TEXTAIS", "TEINTAS", "TEINTES", "TESTAIT", "TESTAIS", "TESTAIT", "TESTIEZ", "TESTING", "TETINES",
                "TETIONS", "ETATISE", "ATTIFES", "ATTIGES", "ATTIRES", "ATTISES", "ATTISEE", "ATTISEE", "ATTISER", "ATTISES", "ATTISEZ", "ATTIERS", "ATTEINS", "ETEINTS", "ETETAIS", "TITISTE",
                "BITATES", "CITATES", "GITATES", "LITATES", "LITOTES", "MITATES", "BITTEES", "BITTUES", "FITTEES", "BITTEES", "BITTERS", "FITTEES", "FIOTTES", "MIETTES", "LISTENT", "PISTENT",
                "BISETTE", "DISETTE", "LISETTE", "RISETTE", "BISETTE", "DISETTE", "LISETTE", "RISETTE", "MIETTES", "SIESTAT", "ALTISTE", "ARTISTE", "AUTISTE", "BATISTE", "TITISTE", "ZUTISTE",
                "AETITES", "BATITES", "CATITES", "COTITES", "ENTITES", "LOTITES", "MATITES", "MUTITES", "PATITES", "PETITES", "RATITES", "ROTITES", "VETITES", "PUTIETS", "SOTTISE", "SOTTIES",
                "BOITTES", "COITTES", "FRITTES", "QUITTES", "CYSTITE", "MASTITE", "BLETTIS", "OSTEITE", "OSTEITE", "PETIOTS", "BETISAT", "AETITES", "PETITES", "VETITES", "METTAIS", "LESTAIT",
                "PESTAIT", "RESTAIT", "TESTAIT", "ZESTAIT", "HESITAT", "ILETTES", "IVETTES", "ILETTES", "IVETTES", "STRICTE", "STRIENT", "STIPITE", "STYLITE", "STATICE", "STATINE", "STATIVE",
                "STIPITE", "STERAIT", "SATIETE", "SATIETE", "SITTIDE", "SOTTISE", "SOTTIES", "SAIETTE", "SCIOTTE", "SAIETTA", "SAIETTE", "SAGITTE", "SITUENT", "SITTELE", "SITTIDE", "SITTELE",
                "SIESTAT", "SENTAIT", "ETEINTS", "ETROITS", "ETATISA", "ETATISE", "ETETAIS", "ENTITES", "EXISTAT", "EBATTIS", "ESTIMAT", "ESTIVAT"
            };

            Assert.IsTrue(!actual.Except(expected).Any(), "Les mots trouvés ne sont pas forcément ceux attendus");
        }
    }
}
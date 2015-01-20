using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class ChevaletTests
    {
        [TestMethod]
        public void TestCombinaisonsAuHasard()
        {
            Sac sac = Sac.Charger(@"C:\github\scrabble\Lettres.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter(sac.TirerLettres(7));

            List<string> combinaisons = chevalet.GetAllCombinaisons().ToList();
            Assert.IsTrue(combinaisons.Count > 0, "Le chevalet n'a pas généré de combinaisons");
            Assert.IsTrue(combinaisons.Count == combinaisons.Distinct().Count(), "Des combinaisons similaires ont été générées");
        }

        [TestMethod]
        public void TestCombinaisonsAvecTocaabs()
        {
            Sac sac = Sac.Charger(@"C:\github\scrabble\Lettres.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("TOCAABS");

            List<string> combinaisons = chevalet.GetAllCombinaisons().ToList();
            Assert.IsTrue(combinaisons.Count == 2520, "Le chevalet n'a pas généré le bon nombre de combinaisons");
            Assert.IsTrue(combinaisons.Count == combinaisons.Distinct().Count(), "Des combinaisons similaires ont été générées");
        }

        [TestMethod]
        public void TestCombinaisonsAvecAvflein()
        {
            Sac sac = Sac.Charger(@"C:\github\scrabble\Lettres.txt");

            Chevalet chevalet = new Chevalet();
            chevalet.Ajouter("AVFLEIN");

            List<string> combinaisons = chevalet.GetAllCombinaisons().ToList();
            Assert.IsTrue(combinaisons.Count == 5040, "Le chevalet n'a pas généré le bon nombre de combinaisons");
            Assert.IsTrue(combinaisons.Count == combinaisons.Distinct().Count(), "Des combinaisons similaires ont été générées");
        }
    }
}

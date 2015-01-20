using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Dojo.Scrabble.Tests
{
    [TestClass]
    public class SacTests
    {
        [TestMethod]
        public void TestSac()
        {
            Sac sac = Sac.Charger(@"C:\github\scrabble\Lettres.txt");

            Assert.AreEqual(102, sac.Lettres.Length, "Nombre de lettres incorrectes");
            Assert.AreEqual(1, Lettre.GetValeur(sac.Lettres[0]));
            Assert.AreEqual(3, Lettre.GetValeur(sac.Lettres[9]));
            Assert.AreEqual(3, Lettre.GetValeur(sac.Lettres[11]));
            Assert.AreEqual(2, Lettre.GetValeur(sac.Lettres[13]));
            Assert.AreEqual(10,Lettre.GetValeur( sac.Lettres[99]));
            Assert.AreEqual(0, Lettre.GetValeur(sac.Lettres[101]));
        }
    }
}
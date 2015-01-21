using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Scrabble.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            program.Demarrer();
        }

        private IDictionnaire _dictionnaire;
        private Sac _sac;
        private StreamWriter _results;

        public Program()
        {
            _dictionnaire = Dictionnaire2.Charger(@"..\..\..\ListeMots.txt");
            _sac = Sac.Charger(@"..\..\..\Lettres.txt");
            _results = File.CreateText(@"c:\temp\scrabble-results2.txt");
        }

        public void Demarrer()
        {
            while (true)
            {
                Console.WriteLine("Saisissez une série de lettres : ");
                Chevalet chevalet = new Chevalet(Console.ReadLine());

                //Console.WriteLine("** Les mots possibles sont : ");
                //Afficher(_dictionnaire.TrouverTousLesMots(chevalet));

                Console.WriteLine("** Les mots les plus longs sont : ");
                Afficher(_dictionnaire.TrouverLesMotsLesPlusLongs(chevalet));

                Console.WriteLine("** Les mots les plus fort sont : ");
                Afficher(_dictionnaire.TrouverLesMotsLesPlusForts(chevalet));

                Console.WriteLine("");
                _results.Flush();
                _results.Close();
            }
        }

        void Afficher(IEnumerable<string> resultats)
        {
            foreach (string resultat in resultats)
            {
                Console.WriteLine("  - " + resultat);
                _results.WriteLine(resultat);
            }
        }
    }
}

using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Dojo.Scrabble
{
    /// <summary>
    /// Représente un sac de lettres
    /// </summary>
    public class Sac
    {
        public Sac()
        {
            Lettres = "";
        }

        /// <summary>
        /// Obtient les lettres disponibles dans le sac
        /// </summary>
        public string Lettres { get; set; }

        /// <summary>
        /// Initialise le sac de lettres à partir d'un fichier
        /// </summary>
        /// <param name="filePath"></param>
        public static Sac FromFile(string filePath)
        {
            Sac sac = new Sac();

            string[] lignes = File.ReadAllLines(filePath);

            foreach (string ligne in lignes)
            {
                var match = Regex.Match(ligne, @"^([#A-Z])\((\d+)\,(\d+)\)$");

                char caractere = match.Groups[1].Value[0];
                byte valeur = byte.Parse(match.Groups[2].Value);
                byte nbOccurences = byte.Parse(match.Groups[3].Value);

                // On définit la valeur de la lettre. Ce traitement est mal placé car il n'est pas intuitif de devoir appeler cette méthode pour pouvoir calculer la valeur d'une lettre ou d'un mot...
                Lettre.SetValeur(caractere, valeur);

                for (int i = 0; i < nbOccurences; i++)
                {
                    sac.Lettres = string.Concat(sac.Lettres, caractere);
                }
            }

            return sac;
        }

        /// <summary>
        /// Tire aléatoirement un nombre de lettres spécifiée
        /// </summary>
        /// <param name="nombreDeLettres">Le nombre de lettres à tirer dans le sac</param>
        /// <returns>Une chaine contenant les lettres tirées</returns>
        public string TirerLettres(int nombreDeLettres = 1)
        {
            string result = string.Empty;
            Random random = new Random();

            int i = 0;

            while (Lettres.Length > 0 && i++ < nombreDeLettres)
            {
                // génération d'un nombre aléatoire entre 0 et le nombre de lettres restantes (-1)
                int indexTirage = random.Next(Lettres.Length - 1);

                // tirage de la lettre dans le sac
                char lettreTirage = Lettres[indexTirage];

                // mise à jour des lettres restantes
                Lettres = Lettres.Remove(indexTirage, 1);

                // ajout de la lettre au résultat
                result = string.Concat(result, lettreTirage);
            }

            return result;
        }
    }
}
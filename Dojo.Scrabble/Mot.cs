using System.Linq;

namespace Dojo.Scrabble
{
    public static class Mot
    {
        /// <summary>
        /// Calcule la valeur d'un mot en fonction de la valeur de chaque lettre
        /// </summary>
        public static int GetValeur(string mot)
        {
            return mot.Aggregate(0, (current, c) => current + Lettre.GetValeur(c));
        }
    }
}
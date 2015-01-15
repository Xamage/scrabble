using System.Collections.Generic;

namespace Dojo.Scrabble
{
    /// <summary>
    /// Classe utilitaire pour les lettres
    /// </summary>
    public static class Lettre
    {
        private static readonly Dictionary<char, byte> Valeurs = new Dictionary<char, byte>();

        /// <summary>
        /// Définit la valeur d'une lettre
        /// </summary>
        /// <param name="c">La lettre</param>
        /// <param name="value">Sa valeur</param>
        public static void SetValeur(char c, byte value)
        {
            Valeurs[c] = value;
        }

        /// <summary>
        /// Fournit la valeur d'une lettre donnée
        /// </summary>
        /// <param name="c">La lettre</param>
        /// <returns>La valeur de la lettre</returns>
        public static byte GetValeur(char c)
        {
            return Valeurs[c];
        }

        /// <summary>
        /// Obtient le caractère associé à la lettre blanche
        /// </summary>
        public static char LettreBlanche
        {
            get { return '#'; }
        }
    }
}
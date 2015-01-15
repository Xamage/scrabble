using System;
using System.Collections.Generic;
using System.Linq;

namespace Dojo.Scrabble
{
    public class Chevalet
    {
        public Chevalet()
        {
            Lettres = string.Empty;
        }

        public string Lettres { get; private set; }

        /// <summary>
        /// Ajoute des lettres sur le chevalet
        /// </summary>
        public void Ajouter(string lettres)
        {
            if (Lettres.Length == 7)
            {
                throw new IndexOutOfRangeException("Le chevalet est plein");
            }

            if ((Lettres.Length + lettres.Length) > 7)
            {
                throw new IndexOutOfRangeException(string.Format("Vous ne pouvez ajouter que {0} lettres au chevalet", 7 - Lettres.Length));
            }

            Lettres = string.Concat(Lettres, lettres);
        }

        /// <summary>
        /// Retourne toutes les combinaisons possibles des lettres disponibles
        /// </summary>
        public IEnumerable<string> GetAllCombinaisons()
        {
            return GetAllCombinaisons(Lettres).Distinct();
        }

        /// <summary>
        /// Retourne toutes les combinaisons possibles des lettres d'une chaine spécifiée
        /// </summary>
        /// <param name="lettres">Un ensemble de combinaisons de lettres</param>
        /// <returns></returns>
        private IEnumerable<string> GetAllCombinaisons(string lettres)
        {
            if (lettres.Length == 0)
                yield break;

            if (lettres.Length == 1)
                yield return lettres;

            for (int pos = 0; pos < lettres.Length; pos++)
            {
                string lettresRestantes = lettres.Remove(pos, 1);

                IEnumerable<string> sousMots = GetAllCombinaisons(lettresRestantes);

                foreach (var sousMot in sousMots)
                {
                    yield return string.Concat(lettres[pos], sousMot);
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Dojo.Scrabble
{
    /// <summary>
    /// Contient l'ensemble des mots connus et expose des méthodes permettant de rechercher des correspondances avec des combinaisons de lettres
    /// </summary>
    public class Dictionnaire2
    {
        private readonly Noeud _racine = new Noeud();

        #region Static

        public static Dictionnaire2 Charger(string filePath)
        {
            Dictionnaire2 dictionnaire = new Dictionnaire2();

            foreach (string mot in File.ReadAllLines(filePath))
            {
                char[] lettres = mot.ToArray();
                Array.Sort(lettres);

                dictionnaire._racine.AjouterMot(mot, lettres);
            }

            return dictionnaire;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Recherche tous les mots les plus longs pour un chevalet
        /// </summary>
        public IEnumerable<string> TrouverLesMotsLesPlusLongs(Chevalet chevalet)
        {
            // Recherche des mots possibles pour l'ensemble des combinaisons possibles
            var resultats = TrouverTousLesMots(chevalet);

            // Récupération de la longueur du mot le plus long
            var longueurMax = resultats.Max(mot => mot.Length);

            // Récupération de tous les mots ayant cette longueur
            return resultats.Where(mot => mot.Length == longueurMax).ToList();
        }

        /// <summary>
        /// Recherche tous les mots les plus forts pour un chevalet
        /// </summary>
        public IEnumerable<string> TrouverLesMotsLesPlusForts(Chevalet chevalet)
        {
            // Recherche des mots possibles pour l'ensemble des combinaisons possibles
            var resultats = TrouverTousLesMots(chevalet);

            // Récupération de la valeur du mot le plus fort
            var valeurMax = resultats.Max(mot => Mot.GetValeur(mot));

            // Récupération de tous les mots ayant cette valeur
            return resultats.Where(mot => Mot.GetValeur(mot) == valeurMax).ToList();
        }

        #endregion

        #region Helpers

        /// <summary>
        /// Recherche tous les mots pour un chevalet
        /// </summary>
        private IEnumerable<string> TrouverTousLesMots(Chevalet chevalet)
        {
            string lettresBlanches = new string(chevalet.Lettres.Where(c => c == '#').ToArray());
            string lettres = chevalet.Lettres.Replace("#", "");
            char[] lettresTriees = lettres.ToArray();
            Array.Sort(lettresTriees);

            Correspondances correspondances = new Correspondances();

            // Recherche dans l'arbre des mots pouvant correspondre à cette combinaison de lettres
            for (int i = 0; i < lettres.Length; i++)
            {
                _racine.ChercherMots(new string(lettresTriees), lettresBlanches, correspondances, i);
            }

            return correspondances.Distinct();
        }

        #endregion

        #region Inner classes

        /// <summary>
        /// Représente un arbre de lettres / mots. A chaque noeud est associée une lettre et éventuellement un mot si le noeud courant et ses parents forment un mot existant.
        /// </summary>
        [DebuggerDisplay("{LettreCorrespondante}")]
        class Noeud
        {
            #region Ctor

            public Noeud(char? lettre = null)
            {
                MotsCorrespondants = new List<string>();
                SousNoeuds = new Dictionary<char, Noeud>();

                if (lettre.HasValue)
                    LettreCorrespondante = lettre;
            }

            #endregion

            #region Properties

            private char? LettreCorrespondante { get; set; }

            private List<string> MotsCorrespondants { get; set; }

            private Dictionary<char, Noeud> SousNoeuds { get; set; }

            #endregion

            #region Public methods

            /// <summary>
            /// Ajoute un mot dans l'arbre
            /// </summary>
            public void AjouterMot(string mot, char[] lettres, int index = 0)
            {
                if (lettres.Length > index)
                {
                    char initiale = lettres[index];
                    Noeud sousNoeud;

                    if (!SousNoeuds.TryGetValue(initiale, out sousNoeud))
                    {
                        sousNoeud = new Noeud(initiale);
                        SousNoeuds.Add(initiale, sousNoeud);
                    }

                    sousNoeud.AjouterMot(mot, lettres, index + 1);
                }
                else
                {
                    MotsCorrespondants.Add(mot);
                }
            }

            /// <summary>
            /// Recherche dans l'arbre les mots correspondants à la suite de lettres spécifiée
            /// </summary>
            public void ChercherMots(string lettres, string lettresBlanches, Correspondances correspondances, int index = 0)
            {
                if (MotsCorrespondants.Any())
                {
                    correspondances.AddRange(MotsCorrespondants);
                }

                if (lettres.Length > index)
                {
                    char initial = lettres[index];

                    Noeud sousNoeud;

                    if (SousNoeuds.TryGetValue(initial, out sousNoeud))
                    {
                        // On descend dans l'arbre
                        sousNoeud.ChercherMots(lettres, lettresBlanches, correspondances, index + 1);
                    }                    
                }
                
                if (lettresBlanches.Any())
                {
                    foreach (Noeud sn in SousNoeuds.Values)
                    {
                        sn.ChercherMots(lettres, lettresBlanches.Substring(1), correspondances, index);
                    }
                }
            }

            #endregion
        }

        #endregion
    }
}
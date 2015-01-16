using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Dojo.Scrabble
{
    /// <summary>
    /// Contient l'ensemble des mots connus et expose des méthodes permettant de rechercher des correspondances avec des combinaisons de lettres
    /// </summary>
    public class Dictionnaire
    {
        private readonly Noeud _racine = new Noeud();

        #region Static

        public static Dictionnaire FromFile(string filePath)
        {
            Dictionnaire dictionnaire = new Dictionnaire();

            foreach (string mot in File.ReadAllLines(filePath))
            {
                dictionnaire._racine.AjouterMot(mot, mot);
            }

            return dictionnaire;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Recherche tous les mots les plus longs pour un chevalet
        /// </summary>
        public IEnumerable<string> TrouverLesMotLesPlusLongs(Chevalet chevalet)
        {
            // Recherche des mots possibles pour l'ensemble des combinaisons possibles
            var resultats = TrouverTousLesMots(chevalet.GetAllCombinaisons());

            // Récupération de la longueur du mot le plus long
            var longueurMax = resultats.Max(mot => mot.Length);

            // Récupération de tous les mots ayant cette longueur
            return resultats.Where(mot => mot.Length == longueurMax).ToList();
        }

        /// <summary>
        /// Recherche tous les mots les plus forts pour un chevalet
        /// </summary>
        public IEnumerable<string> TrouverLesMotLesPlusForts(Chevalet chevalet)
        {
            // Recherche des mots possibles pour l'ensemble des combinaisons possibles
            var resultats = TrouverTousLesMots(chevalet.GetAllCombinaisons());

            // Récupération de la valeur du mot le plus fort
            var valeurMax = resultats.Max(mot => Mot.GetValeur(mot));

            // Récupération de tous les mots ayant cette valeur
            return resultats.Where(mot => Mot.GetValeur(mot) == valeurMax).ToList();
        }

        #endregion

        #region Helpers

        private IEnumerable<string> TrouverTousLesMots(IEnumerable<string> combinaisons)
        {
            Correspondances results = new Correspondances();

            foreach (string combinaison in combinaisons)
            {
                // Recherche dans l'arbre des mots pouvant correspondre à cette combinaison de lettres
                _racine.ChercherCorrespondances(string.Empty, combinaison, results);
            }

            return results.Distinct();
        }

        #endregion

        #region Inner classes

        /// <summary>
        /// Représente un arbre de lettres / mots. A chaque noeud est associée une lettre et éventuellement un mot si le noeud courant et ses parents forment un mot existant.
        /// </summary>
        class Noeud
        {
            #region Ctor

            public Noeud(char? lettre = null)
            {
                SousNoeuds = new Dictionary<char, Noeud>();

                if (lettre.HasValue)
                    LettreCorrespondante = lettre;
            }

            #endregion

            #region Properties

            private char? LettreCorrespondante { get; set; }

            private string MotCorrespondant { get; set; }

            private Dictionary<char, Noeud> SousNoeuds { get; set; }

            #endregion

            #region Public methods
            
            /// <summary>
            /// Ajoute un mot dans l'arbre de manière récursive
            /// </summary>
            /// <param name="mot">Le mot à ajouter</param>
            /// <param name="motRestant">Les lettres restant à traiter pour l'ajout du mot dans l'arbre</param>
            public void AjouterMot(string mot, string motRestant)
            {
                if (!string.IsNullOrEmpty(motRestant))
                {
                    char initial = motRestant[0];
                    Noeud subNode;

                    if (!SousNoeuds.TryGetValue(initial, out subNode))
                    {
                        subNode = new Noeud(initial);
                        SousNoeuds.Add(initial, subNode);
                    }

                    subNode.AjouterMot(mot, motRestant.Substring(1));
                }
                else
                {
                    // On est arrivé sur le noeud correspondant à la dernière lettre => on place le mot complet sur ce noeud
                    MotCorrespondant = mot;
                }
            }

            /// <summary>
            /// Effectue la recherche des correspondances pour un mot donnée de manière récursive
            /// </summary>
            /// <param name="debut">Les lettres déjà parcourues</param>
            /// <param name="motRestant">Les lettres restant à traiter pour la descente dans l'arbre</param>
            /// <param name="correspondances">L'ensemble des correspondances trouvées avec les lettres déjà parcourues dans l'arbre</param>
            public void ChercherCorrespondances(string debut, string motRestant, Correspondances correspondances)
            {
                if (!string.IsNullOrEmpty(MotCorrespondant) && debut == MotCorrespondant)
                {
                    correspondances.Add(MotCorrespondant);
                }

                if (string.IsNullOrEmpty(motRestant))
                {
                    return;
                }

                char caractereSuivant = motRestant[0];

                if (!LettreCorrespondante.HasValue || caractereSuivant != Lettre.LettreBlanche)
                {
                    Noeud sousNoeud;
                    if (SousNoeuds.TryGetValue(caractereSuivant, out sousNoeud))
                    {
                        sousNoeud.ChercherCorrespondances(string.Concat(debut, caractereSuivant), motRestant.Substring(1), correspondances);
                    }
                }

                if (caractereSuivant == Lettre.LettreBlanche)
                {
                    // Cas particulier : la lettre blanche (#) => Il faut parcourir tous les sous noeuds du noeud courant
                    foreach (var kvp in SousNoeuds)
                    {
                        kvp.Value.ChercherCorrespondances(string.Concat(debut, kvp.Value.LettreCorrespondante.Value), motRestant.Substring(1), correspondances);
                    }
                }
            }

            #endregion
        }

        #endregion
    }
}
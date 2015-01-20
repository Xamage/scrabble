using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dojo.Scrabble
{
    public interface IDictionnaire
    {
        IEnumerable<string> TrouverTousLesMots(Chevalet chevalet);

        IEnumerable<string> TrouverLesMotsLesPlusLongs(Chevalet chevalet);

        IEnumerable<string> TrouverLesMotsLesPlusForts(Chevalet chevalet);
    }
}

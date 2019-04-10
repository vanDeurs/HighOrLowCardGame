using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    class Card
    {
        // Hjärter, Spader, Ruter, Klöver
        public string färg;
        // 1 (Ess) - 14 (Ess)
        public int värde;
        // Returnerar kortets värde
        public int ReturnernaVärde(Card card)
        {
            return card.värde;
        }
    }
}

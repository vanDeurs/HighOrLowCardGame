﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighOrLow
{
    public enum Färger {hjärter, spader, ruter, klöver};
    public enum Värden {ess = 1, knäckt = 11, dam = 12, kung = 13};

    class Card
    {
        public int färg;
        public int värde;
    }
}

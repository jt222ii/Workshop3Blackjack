using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class TieRuleDealerWin : ITieStrategy
    {
        public bool IsDealerWinner()
        {
            return true;
        }
    }
}

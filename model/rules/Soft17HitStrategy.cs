using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    class Sof17HitStrategy : IHitStrategy
    {
        private const int g_hitLimit = 17;

        public bool DoHit(model.Player a_dealer)
        {
            a_dealer.GetHand();
            if (a_dealer.CalcScore() == g_hitLimit)
            {
                int total = 0;
                int[] cardScores = a_dealer.getCardValues();
                foreach (Card card in a_dealer.GetHand())
                { 
                    if(card.GetValue() != Card.Value.Ace)
                    {
                        total += cardScores[(int)card.GetValue()];
                    }
                }
                return total <= 6;
            }
            return a_dealer.CalcScore() < g_hitLimit;
        }
    }
}

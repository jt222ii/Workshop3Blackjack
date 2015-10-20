using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private Deck m_deck = null;
        private const int g_maxScore = 21;

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.ITieStrategy m_tieRule;
        List<IDrawCardObserver> m_observers;


        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_tieRule = a_rulesFactory.GetTieRule();

            m_observers = new List<IDrawCardObserver>();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(m_deck, this, a_player);   
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
           //  m_observers.Add(nåtjävlaskit);

            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                DealCardHandler(true, a_player);

                if (a_player.CalcScore() >= 21)
                {
                    Stand();
                }
                return true;
            }
            return false;
        }
        public bool Stand()
        {
            if (m_deck != null)
            {
                foreach(Card card in GetHand()) 
                {
                    card.Show(true);      
                }
                while (m_hitRule.DoHit(this))
                {
                    DealCardHandler(true, this);
                }
                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            else if (CalcScore() == a_player.CalcScore())
            {
                return m_tieRule.IsDealerWinner();
            }
            return CalcScore() > a_player.CalcScore();
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public void DealCardHandler(bool hiddenCard, Player player)
        {
            Card c = m_deck.GetCard();
            c.Show(hiddenCard);
            player.DealCard(c);
            foreach (IDrawCardObserver o in m_observers)
            {
                o.DrawCard(c);
            }
        }

        public void AddSub(IDrawCardObserver a_sub)
        {
            m_observers.Add(a_sub);
        }
    }
}

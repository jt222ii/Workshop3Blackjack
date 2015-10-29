using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace BlackJack.controller
{
    class PlayGame : model.IDrawCardObserver
    {
        private view.IView m_view;
        private model.Game m_game;
        public bool Play(model.Game a_game, view.IView a_view)
        {
            m_view = a_view;
            m_game = a_game;
            a_view.DisplayWelcomeMessage();
            
            a_view.DisplayDealerHand(a_game.GetDealerHand(), a_game.GetDealerScore());
            a_view.DisplayPlayerHand(a_game.GetPlayerHand(), a_game.GetPlayerScore());

            if (a_game.IsGameOver())
            {
                a_view.DisplayGameOver(a_game.IsDealerWinner());
            }

            BlackJack.view.Events input = (BlackJack.view.Events)a_view.GetInput();

            if (input == view.Events.Play)
            {
                a_game.NewGame();
            }
            else if (input == view.Events.Hit)
            {
                a_game.Hit();
            }
            else if (input == view.Events.Stand)
            {
                a_game.Stand();
            }

            return input != view.Events.Quit;
        }

        public void DrawCard(model.Card card)
        {
            m_view.DisplayWelcomeMessage();
            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());
            Thread.Sleep(750);
        }
    }
}

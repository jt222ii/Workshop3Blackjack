﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{

    public enum Events
    {
        Play,
        Hit,
        Stand,
        Quit
    }


    

    interface IView
    {
        void DisplayWelcomeMessage();
        //int GetInput();
        Enum GetInput();
        void DisplayCard(model.Card a_card);
        void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score);
        void DisplayGameOver(bool a_dealerIsWinner);
    }
}

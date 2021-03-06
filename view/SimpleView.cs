﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class SimpleView : IView
    {
        private const string play = "p";
        private const string hit = "h";
        private const string stand = "s";
        private const string quit = "q";

        public void DisplayWelcomeMessage()
        { 
            System.Console.Clear();
            System.Console.WriteLine("Hello Black Jack World");
            System.Console.WriteLine("----------------------");
            System.Console.WriteLine("Type '{0}' to Play, '{1}' to Hit, '{2}' to Stand or '{3}' to Quit\n", play, hit, stand, quit);
        }

        public Enum GetInput()
        {
            string input = Console.ReadLine();
            switch (input)
            {
                case play:
                    return Events.Play;
                case hit:
                    return Events.Hit;
                case stand:
                    return Events.Stand;
                case quit:
                    return Events.Quit;
                default:
                    return null;
            }
        }

        public void DisplayCard(model.Card a_card)
        {
            System.Console.WriteLine("{0} of {1}", a_card.GetValue(), a_card.GetColor());
        }

        public void DisplayPlayerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Player", a_hand, a_score);
        }

        public void DisplayDealerHand(IEnumerable<model.Card> a_hand, int a_score)
        {
            DisplayHand("Dealer", a_hand, a_score);
        }

        private void DisplayHand(String a_name, IEnumerable<model.Card> a_hand, int a_score)
        {
            System.Console.WriteLine("{0} Has: ", a_name);
            foreach (model.Card c in a_hand)
            {
                DisplayCard(c);
            }
            System.Console.WriteLine("Score: {0}", a_score);
            System.Console.WriteLine("");
        }

        public void DisplayGameOver(bool a_dealerIsWinner)
        {
            System.Console.Write("GameOver: ");
            if (a_dealerIsWinner)
            {
                System.Console.WriteLine("Dealer Won!");
            }
            else
            {
                System.Console.WriteLine("You Won!");
            }
            
        }
    }
}

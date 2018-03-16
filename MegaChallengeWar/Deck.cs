﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck  {
        private List<Card> _orderedDeck { get; set; }
        private List<Card> _shuffledDeck { get; set; }
        private Random _rnd;

        public Deck()  {
            this._orderedDeck = new List<Card>();
            this._shuffledDeck = new List<Card>();
            this._rnd = new Random();

            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                foreach (Card.Values value in Enum.GetValues(typeof(Card.Values)))
                {
                    this._orderedDeck.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

         public void Shuffle()
        {
            while (this._orderedDeck.Count > 0)
            {
                int index = this._rnd.Next(this._orderedDeck.Count);
                this._shuffledDeck.Add(this._orderedDeck.ElementAt(index));
                this._orderedDeck.RemoveAt(index);
            }
        }

        public void Deal(Player player1, Player player2)
        {
            while (this._shuffledDeck.Count > 0)
            {
                player1.Cards.Add(this._shuffledDeck.ElementAt(0));
                this._shuffledDeck.RemoveAt(0);
                player2.Cards.Add(this._shuffledDeck.ElementAt(0));
                this._shuffledDeck.RemoveAt(0);
            }
        }
 
    }
}  

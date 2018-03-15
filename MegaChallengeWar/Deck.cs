using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck  {
        private List<Card> _orderedCards { get; set; }
        private List<Card> _shuffledCards { get; set; }
        private Random _rnd;

        public Deck()  {
            this._orderedCards = new List<Card>();
            this._shuffledCards = new List<Card>();
            this._rnd = new Random();
        }

        public void SetupDeck()  {
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                foreach (Card.Values value in Enum.GetValues(typeof(Card.Values)))
                {
                    this._orderedCards.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        public void Shuffle()
        {
            while (this._orderedCards.Count > 0)
            {
                int index = this._rnd.Next(this._orderedCards.Count);
                this._shuffledCards.Add(this._orderedCards.ElementAt(index));
                this._orderedCards.RemoveAt(index);
            }
        }

        public void Deal(Player player1, Player player2)
        {
            while (this._shuffledCards.Count > 0)
            {
                player1.Cards.Add(this._shuffledCards.ElementAt(0));
                this._shuffledCards.RemoveAt(0);
                player2.Cards.Add(this._shuffledCards.ElementAt(0));
                this._shuffledCards.RemoveAt(0);
            }
        }
 
    }
}  

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Deck  {
        public List<Card> OrderedCards { get; set; }
        public List<Card> ShuffledCards { get; set; }
        private Random _rnd;

        public Deck()  {
            this.OrderedCards = new List<Card>();
            this.ShuffledCards = new List<Card>();
            this._rnd = new Random();
        }

        public void SetupDeck()  {
            foreach (Card.Suits suit in Enum.GetValues(typeof(Card.Suits)))
            {
                foreach (Card.Values value in Enum.GetValues(typeof(Card.Values)))
                {
                    this.OrderedCards.Add(new Card { Suit = suit, Value = value });
                }
            }
        }

        public void ShuffleDeck()
        {
            while (this.OrderedCards.Count > 0)
            {
                int index = this._rnd.Next(this.OrderedCards.Count);
                this.ShuffledCards.Add(this.OrderedCards.ElementAt(index));
                this.OrderedCards.RemoveAt(index);
            }
        }

        public void DealCards(Player player1, Player player2)
        {
            while (this.ShuffledCards.Count > 0)
            {
                player1.Cards.Add(this.ShuffledCards.ElementAt(0));
                this.ShuffledCards.RemoveAt(0);
                player2.Cards.Add(this.ShuffledCards.ElementAt(0));
                this.ShuffledCards.RemoveAt(0);
            }
        }
 
    }
}  

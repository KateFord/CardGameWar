using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Card
    {

        public enum Suits { Clubs, Diamonds, Hearts, Spades };
        public enum Values { Two=2, Three=3, Four=4, Five=5, Six=6, Seven=7, Eight=8, Nine=9, Ten=10, Jack=11, Queen=12, King=13, Ace = 14 };

        public Suits Suit { get; set; }
        public Values Value { get; set; }
        public int ValueInt { get { return (int) Value; } }
        public string Name { get { return Value.ToString() + " of  " + Suit.ToString(); } }

        public Card()
        {

        }

        public Card(Suits suit, Values value)  {
            this.Value = value;
            this.Suit = suit;
        }
  
    }
}
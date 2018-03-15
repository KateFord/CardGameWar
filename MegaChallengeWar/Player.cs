using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Player
    {
        public string Name { get; set; }
        public List<Card> Cards { get; set; }
        public List<Card> Bounty { get; set; }

        public Player()
        {
            this.Name = "Undefined";
            this.Cards = new List<Card>();
            this.Bounty = new List<Card>();
        }
    }
}
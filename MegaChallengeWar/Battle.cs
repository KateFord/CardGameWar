using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {

        private List<Card> _bounty { get; set; }

        public Battle()
         {
             this._bounty = new List<Card>();
         }

        public void doBattle(Player player1, Player player2)
        {
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            evaluateBattle(player1, player2, player1Card, player2Card);
        }

        private Card getCard(Player player)
        {
            Card card = player.Cards.ElementAt(0);
            player.Cards.Remove(card);
            this._bounty.Add(card);
            return card;
        }

        private void evaluateBattle(Player player1, Player player2, Card card1, Card card2)
        {
            if (card1.ValueInt == card2.ValueInt)
                war(player1, player2);

            if (card1.ValueInt > card2.ValueInt)
                bountyToWinner(player1);
            else
                bountyToWinner(player2);
        }

        private void bountyToWinner(Player player)
        {
           player.Cards.AddRange(this._bounty);
            this._bounty.Clear();
        }

        private void war(Player player1, Player player2)
        {
            for (int i = 0; i < 3; i++)
            {
                getCard(player1);
                getCard(player2);
            }

            Card player1warCard = getCard(player1);
            Card player2warCard = getCard(player2);
        }

        private void displayBattleCards()
        {

        }

        private void displayBountyCards()
        {

        }

    }


}
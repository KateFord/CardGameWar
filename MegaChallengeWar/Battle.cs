using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MegaChallengeWar
{
    public class Battle
    {

        private List<Card> _bounty { get; set; }
        private StringBuilder _result;

        public Battle()
         {
            this._bounty = new List<Card>();
            this._result = new StringBuilder();
         }

        public string doBattle(Player player1, Player player2)
        {
            Card player1Card = getCard(player1);
            Card player2Card = getCard(player2);

            evaluateBattle(player1, player2, player1Card, player2Card);
            return this._result.ToString();
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
            displayBattleCards(card1, card2);
            if (card1.ValueInt == card2.ValueInt)
                war(player1, player2);

            if (card1.ValueInt > card2.ValueInt)
                bountyToWinner(player1);
            else
                bountyToWinner(player2);
        }

        private void bountyToWinner(Player player)
        {
            if (this._bounty.Count == 0) return;

            player.Cards.AddRange(this._bounty);
            this.displayBountyCards();
            this._result.Append("<br/>&nbsp;&nbsp;<strong>");
            this._result.Append(player.Name);
            this._result.Append(" wins!</strong>");
            this._bounty.Clear();
        }

        private void war(Player player1, Player player2)
        {
            this._result.Append("<br/>&nbsp;&nbsp;");
            this._result.Append("<strong><span style='color:red;font-weight:bolder;'>******************WAR*********************</span></strong>");
            for (int i = 0; i < 3; i++)
            {
                getCard(player1);
                getCard(player2);
            }

            Card player1warCard = getCard(player1);
            Card player2warCard = getCard(player2);
            evaluateBattle(player1, player2, player1warCard, player2warCard);

        }

        private void displayBattleCards(Card card1, Card card2)
        {
            this._result.Append("<br/><br/>&nbsp;&nbsp;");
            this._result.Append("<strong>Battle Cards: </strong>");
            this._result.Append("<span style='font-size:14px;'>");
            this._result.Append(card1.Name);
            this._result.Append("</span>");
            this._result.Append("<strong> versus <strong>");
            this._result.Append("<span style='font-size:14px;'>");
            this._result.Append(card2.Name);
            this._result.Append("</span>");
        }

        private void displayBountyCards()
        {
            this._result.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;");
            this._result.Append("<strong>Bounty ... </strong>");
            foreach (var card in this._bounty)
            {
                this._result.Append("<br/>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;");
                this._result.Append("<span style='font-size:14px;'>");
                this._result.Append(card.Name);
                this._result.Append("</span>");
            }
        }         

    }

}
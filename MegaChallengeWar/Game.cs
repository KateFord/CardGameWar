using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MegaChallengeWar
{
    public class Game  {
        private Player _player1;
        private Player _player2;
        private Deck _deck;
        public int Turn { get; set; }
        private string dealtCards { get; set; }
        private string battles { get; set; }

        public Game(string player1Name, string player2Name) {
            this._player1 = new Player();
            this. _player1.Name = player1Name;
            this. _player2 = new Player();
            this._player2.Name = player2Name;
            this. _deck = new Deck();
            this.dealtCards = "Dealing cards ...<br/><br/><br/>";
            this.Turn = 0;
         }

        public string GameOfWar()
        {
            _deck.SetupDeck();
            _deck.ShuffleDeck();
            _deck.DealCards(_player1, _player2);
            playMethod1(false);
            return displayResults();
        }

        private string displayResults(string error = "")
        {
            string result = this.dealtCards;
            result += error;
            return result;
         }

         private void playMethod1(bool war)  {

            while (this.Turn <= 10 && _player1.Cards.Count > 0 && _player2.Cards.Count > 0)
            {
                if (war)
                    playMethod2(4);
                else  {
                    playMethod2(1);
                    this.Turn++;  }

                playMethod3();
            }
         }

        private void playMethod2(int cardCount)
        {
            addCardsToBounty(_player1, cardCount);
            addCardsToBounty(_player2, cardCount);
            displayResults();
        }

        private void playMethod3()
        {
            Player winningPlayer;
            if (getTurnWinner(out winningPlayer))
            {
                addBountyToCards(winningPlayer);
                playMethod1(false);
            }
            else if (_player1.Bounty.Last().ValueInt == _player2.Bounty.Last().ValueInt)
                 war();
            else
                displayResults("error in playMethod3");
        }

        private bool getTurnWinner(out Player player)
        {
            if (_player1.Bounty.Last().ValueInt > _player2.Bounty.Last().ValueInt) player = _player1;
            else if (_player1.Bounty.Last().ValueInt < _player2.Bounty.Last().ValueInt) player = _player2;
            else player = null;

            if (player == _player1 || player == _player2) return true;
            else return false;
        }

        private void war()
        {
             playMethod1(true);
        }

        private void addCardsToBounty(Player player, int numberOfCards)
        {
            for (int i = 1;  i <= numberOfCards; i++) {
                player.Bounty.Add(player.Cards.First()); 
                this.dealtCards += String.Format("<br/>{0} is dealt the {1}", player.Name, player.Cards.First().Name); 
                player.Cards.RemoveAt(0);
            }
        }
 
        private void addBountyToCards(Player winningPlayer)  {
            winningPlayer.Cards.AddRange(_player1.Bounty);
            winningPlayer.Cards.AddRange(_player2.Bounty);
            _player1.Bounty.Clear();
            _player2.Bounty.Clear();
        }

    }
}
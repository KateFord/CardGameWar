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
        private int _turn { get; set; }

        public Game(string player1Name, string player2Name) {
            this._player1 = new Player();
            this. _player1.Name = player1Name;
            this. _player2 = new Player();
            this._player2.Name = player2Name;
            this. _deck = new Deck();
            this._turn = 0;
         }

        public string GameOfWar()
        {
            _deck.SetupDeck();
            _deck.Shuffle();
            _deck.Deal(_player1, _player2);

            playTurn(false);
            return displayResults();
        }

         private void playTurn(bool war)  {

            while (this._turn <= 10 && _player1.Cards.Count > 0 && _player2.Cards.Count > 0)
            {
                if (war)
                    battle(4);
                else  {
                    battle(1);
                    this._turn++;  }
                evaluateBattle();
            }
         }

        private void battle(int cardCount)
        {
            addCardsToBounty(_player1, cardCount);
            addCardsToBounty(_player2, cardCount);
        }

        private void evaluateBattle()  //REFACTOR
        {
            if (_player1.Bounty.Last().ValueInt > _player2.Bounty.Last().ValueInt)
            {
                addBountyToCards(_player1);
                playTurn(false);
            }
            else if (_player1.Bounty.Last().ValueInt < _player2.Bounty.Last().ValueInt)
            {
                addBountyToCards(_player2);
                playTurn(false);
            }
            else if (_player1.Bounty.Last().ValueInt == _player2.Bounty.Last().ValueInt) 
                playTurn(true);
        }
      
        private void addCardsToBounty(Player player, int numberOfCards)
        {
            for (int i = 1;  i <= numberOfCards; i++) {
                player.Bounty.Add(player.Cards.First()); 
                player.Cards.RemoveAt(0);
            }
        }
 
        private void addBountyToCards(Player winningPlayer)  {
            winningPlayer.Cards.AddRange(_player1.Bounty);
            winningPlayer.Cards.AddRange(_player2.Bounty);
            _player1.Bounty.Clear();
            _player2.Bounty.Clear();
        }

        private string displayResults()
        {
            string result = "";
            return result;
        }

    }
}
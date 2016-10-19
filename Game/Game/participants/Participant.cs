using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.Strategy;

namespace Game.participants
{
    abstract class Participant
    {
        protected Deck deck;
        protected AbstractStrategy strategy;

        protected Participant(Deck deck, AbstractStrategy strategy)
        {
            this.deck = deck;
            this.strategy = strategy;
        }

        /// <summary>
        /// Used to signify the end of the round
        /// </summary>
        /// <param name="dealerValue">The points that the dealers hand adds up to</param>
        /// <param name="isBlackJack">IF the dealer had black jack</param>
        public abstract void EndRound(int dealerValue, bool isBlackJack);

    }
}

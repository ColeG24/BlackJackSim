using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.Strategy;

namespace Game.participants
{
    public abstract class Participant
    {
        protected Deck deck;
        protected AbstractStrategy strategy;

        protected Participant(AbstractStrategy strategy)
        {
            this.strategy = strategy;
        }

        /// <summary>
        /// Used to signify the end of the round
        /// </summary>
        /// <param name="dealerValue">The points that the dealers hand adds up to</param>
        public abstract void EndRound(int dealerValue);

        public abstract void PlayOutRound(Card dealerUpCard);

        public abstract void DoInitialDraw();

        public void SetDeck(Deck deck)
        {
            this.deck = deck;
        }

    }
}

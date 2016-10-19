using Game.cards;
using Game.cards.logic;
using Game.participants.actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Strategy
{
    public abstract class AbstractStrategy
    {
        public abstract HandAction DetermineActionForHand(int count, Hand hand, Card upCard);

        public abstract bool TakeInsurance(int count, Hand hand);

        public abstract decimal BetAmount(int count);

        public abstract int GetCountValueOfCard(Card card);

    }
}

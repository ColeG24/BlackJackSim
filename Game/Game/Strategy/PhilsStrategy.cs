using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.cards.logic;
using Game.participants.actions;

namespace Game.Strategy
{
    class PhilsStrategy : AbstractStrategy
    {
        public override decimal BetAmount(int count)
        {
            if (count > 5)
            {
                return 15;
            }
            else
                return 5;
        }

        public override HandAction DetermineActionForHand(int count, Hand hand, Card upCard)
        {
            if (hand.Value == 3)
            {

            }
            throw new NotImplementedException();
        }

        public override int GetCountValueOfCard(Card card)
        {
            throw new NotImplementedException();
        }

        public override bool TakeInsurance(int count, Hand hand)
        {
            throw new NotImplementedException();
        }
    }
}

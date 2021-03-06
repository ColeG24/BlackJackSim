﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.cards.logic;
using Game.participants.actions;

namespace Game.Strategy
{
    public class DealerStrategy : AbstractStrategy
    {
        public override decimal BetAmount(int count)
        {
            return 0;
        }

        public override HandAction DetermineActionForHand(int count, Hand hand, Card upCard)
        {
            if (hand.Value > 17)
            {
                return HandAction.STAND;
            } 
            else if (hand.Value == 17 && hand.IsSoft == false)
            {
                return HandAction.STAND;
            }
            else
            {
                return HandAction.HIT;
            }
        }

        public override int GetCountValueOfCard(Card card)
        {
            return 0;
        }

        public override bool TakeInsurance(int count, Hand hand)
        {
            return false;
        }
    }
}

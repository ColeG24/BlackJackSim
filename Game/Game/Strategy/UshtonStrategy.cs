using Game.cards;
using Game.cards.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Strategy
{
    public class UshtonStrategy : BasicStrategy
    {
        public override bool TakeInsurance(int count, Hand hand)
        {
            if (count > 5)
            {
                return true;
            }
            else
                return false;
        }

        public override int GetCountValueOfCard(Card card)
        {
            switch (card.TypeOfCard)
            {
                case CardType.TWO: return 1;
                case CardType.THREE: return 2;
                case CardType.FOUR: return 2;
                case CardType.FIVE: return 3;
                case CardType.SIX: return 2;
                case CardType.SEVEN: return 2;
                case CardType.EIGHT: return 1;
                case CardType.NINE: return -1;
                case CardType.ACE: return 0;
                default: return -3;
            }
        }

        public override decimal BetAmount(int count)
        {
            if (count > 20)
            {
                return 50;
            }
            if (count > 15)
            {
                return 40;
            }
            if (count > 10)
            {
                return 30;
            }
            else if (count > 5)
            {
                return 5;
            }
            else
                return 1;
        }

    }
}

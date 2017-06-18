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
    public class ZenStrategy : BasicStrategy
    {
        public override bool TakeInsurance(int count, Hand hand)
        {
            if (count >= 8)
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
                case CardType.THREE: return 1;
                case CardType.FOUR: return 2;
                case CardType.FIVE: return 2;
                case CardType.SIX: return 2;
                case CardType.SEVEN: return 1;
                case CardType.EIGHT: return 0;
                case CardType.NINE: return 0;
                case CardType.ACE: return -1;
                default: return -2;
            }
        }

        ///// <summary>
        /////  deviates with 15v10, 15v9
        ///// </summary>
        //public override HandAction handValue15(int count, Hand hand, Card upCard)
        //{
        //    if (hand.IsSoft)
        //    {
        //        if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
        //        {
        //            return HandAction.HIT;
        //        }
        //        else
        //            return HandAction.DOUBLE_DOWN;
        //    }
        //    else
        //    {
        //        if ((int)upCard.GetCardValue() == 10) // 15v10
        //        {
        //            if (count >= 6)
        //            {
        //                return HandAction.STAND;
        //            }
        //            else
        //            {
        //                return HandAction.HIT;
        //            }
        //        }
        //        if ((int)upCard.GetCardValue() == 9) // 15v9
        //        {
        //            if (count >= 13)
        //            {
        //                return HandAction.STAND;
        //            }
        //            else
        //            {
        //                return HandAction.HIT;
        //            }
        //        }
        //        if (((int)upCard.GetCardValue() >= 2 || (int)upCard.GetCardValue() <= 6))
        //        {
        //            return HandAction.STAND;
        //        }
        //        else
        //            return HandAction.HIT;
        //    }
        //}

        ///// <summary>
        ///// Takes count into effect for 16v10 and 16v9
        ///// <returns></returns>
        //public override HandAction handValue16(int count, Hand hand, Card upCard)
        //{
        //    if (hand.IsSoft)
        //    {
        //        if ((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3 || (int)upCard.GetCardValue() >= 7)
        //        {
        //            return HandAction.HIT;
        //        }
        //        else
        //            return HandAction.DOUBLE_DOWN;
        //    }
        //    else if (hand.CanSplit())
        //    {
        //        return HandAction.SPLIT;
        //    }
        //    else
        //    {
        //        if ((int)upCard.GetCardValue() == 10) // 16v10
        //        {
        //            if (count >= 0)
        //            {
        //                return HandAction.STAND;
        //            }
        //            else
        //            {
        //                return HandAction.HIT;
        //            }
        //        }
        //        if ((int)upCard.GetCardValue() == 9) // 16v9
        //        {
        //            if (count >= 8)
        //            {
        //                return HandAction.STAND;
        //            }
        //            else
        //            {
        //                return HandAction.HIT;
        //            }
        //        }
        //        if (((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6))
        //        {
        //            return HandAction.STAND;
        //        }
        //        else
        //            return HandAction.HIT;
        //    }
        //}

        public override decimal BetAmount(int count)
        {
            if (count > 20)
            {
                return 100;
            }
            if (count > 15)
            {
                return 75;
            }
            if (count >= 10)
            {
                return 50;
            }
            else if (count >= 8)
            {
                return 15;
            }
            else if (count >= 8)
            {
                return 10;
            }
            else if (count >= 4)
            {
                return 5;
            }
            else
            {
                return 2;
            }
        }

    }
}

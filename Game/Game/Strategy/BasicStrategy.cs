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
    public class BasicStrategy : AbstractStrategy
    {
        public override decimal BetAmount(int count)
        {
            return 5;
        }

        public override HandAction DetermineActionForHand(int count, Hand hand, Card upCard)
        {
            if (hand.Value == 4)
            {
                return handValue4(count, hand, upCard);
            }
            else if (hand.Value == 5)
            {
                return HandAction.HIT;
            }
            else if (hand.Value == 6)
            {
                return handValue6(count, hand, upCard);
            }
            else if (hand.Value == 7)
            {
                return HandAction.HIT;
            }

            else if (hand.Value == 8)
            {
                return handValue8(count, hand, upCard);
            }

            else if (hand.Value == 9)
            {
                return handValue9(count, hand, upCard);
            }

            else if (hand.Value == 10)
            {
                return handValue10(count, hand, upCard);
            }

            else if (hand.Value == 11)
            {
                return HandAction.DOUBLE_DOWN;
            }

            else if (hand.Value == 12)
            {
                return handValue12(count, hand, upCard);
            }

            else if (hand.Value == 13)
            {
                return handValue13(count, hand, upCard);
            }

            else if (hand.Value == 14)
            {
                return handValue14(count, hand, upCard);
            }

            else if (hand.Value == 15)
            {
                return handValue15(count, hand, upCard);
            }

            else if (hand.Value == 16)
            {
                return handValue16(count, hand, upCard);
            }

            else if (hand.Value == 17)
            {
                return handValue17(count, hand, upCard);
            }

            else if (hand.Value == 18)
            {
                return handValue18(count, hand, upCard);
            }

            else if (hand.Value == 19)
            {
                return handValue19(count, hand, upCard);
            }

            else
            {
                return HandAction.STAND;
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

        public HandAction handValue4(int count, Hand hand, Card upCard)
        {
            if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() >= 3 && (int)upCard.GetCardValue() <= 7)
                {
                    return HandAction.SPLIT;
                }
                else
                    return HandAction.HIT;
            }
            else
                return HandAction.HIT;
        }

        public HandAction handValue6(int count, Hand hand, Card upCard)
        {
            if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() >= 4 && (int)upCard.GetCardValue() <= 7)
                {
                    return HandAction.SPLIT;
                }
                else
                    return HandAction.HIT;
            }
            else
                return HandAction.HIT;
        }

        public HandAction handValue8(int count, Hand hand, Card upCard)
        {
            if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() == 5 || (int)upCard.GetCardValue() == 6)
                {
                    return HandAction.DOUBLE_DOWN;
                }
                else
                    return HandAction.HIT;
            }
            else
            {
                if ((int)upCard.GetCardValue() == 5 || (int)upCard.GetCardValue() == 6)
                {
                    return HandAction.DOUBLE_DOWN;
                }
                else
                    return HandAction.HIT;
            }
        }
        public HandAction handValue9(int count, Hand hand, Card upCard)
        {
            if ((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6)
            {
                return HandAction.DOUBLE_DOWN;
            }
            else
                return HandAction.HIT;
        }

        public HandAction handValue10(int count, Hand hand, Card upCard)
        {
            if ((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 9)
            {
                return HandAction.DOUBLE_DOWN;
            }
            else
                return HandAction.HIT;
        }
        public HandAction handValue12(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                return HandAction.SPLIT;
            }
            else if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6)
                {
                    return HandAction.SPLIT;
                }
                else
                    return HandAction.HIT;
            }
            else
            {
                if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.STAND;
            }
        }

        public HandAction handValue13(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.DOUBLE_DOWN;
            }
            else
            {
                if (((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6))
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
        }

        public HandAction handValue14(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.DOUBLE_DOWN;
            }
            else if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 7)
                {
                    return HandAction.SPLIT;
                }
                else if ((int)upCard.GetCardValue() == 10)
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
            else
            {
                if (((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6))
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
        }

        public virtual HandAction handValue15(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.DOUBLE_DOWN;
            }
            else
            {
                if (((int)upCard.GetCardValue() >= 2 || (int)upCard.GetCardValue() <= 6))
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
        }

        public virtual HandAction handValue16(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if (((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 3) || (int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.DOUBLE_DOWN;
            }
            else if (hand.CanSplit())
            {
                return HandAction.SPLIT;
            }
            else
            {
                if (((int)upCard.GetCardValue() >= 2 && (int)upCard.GetCardValue() <= 6))
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
        }

        public HandAction handValue17(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if ((int)upCard.GetCardValue() >= 7)
                {
                    return HandAction.HIT;
                }
                else
                    return HandAction.DOUBLE_DOWN;
            }
            else
            {
                return HandAction.STAND;
            }
        }

        public HandAction handValue18(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if (((int)upCard.GetCardValue() >= 3) && (int)upCard.GetCardValue() <= 6)
                {
                    return HandAction.DOUBLE_DOWN;
                }
                else if ((int)upCard.GetCardValue() == 2 || (int)upCard.GetCardValue() == 7 || (int)upCard.GetCardValue() == 8)
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.HIT;
            }
            else if (hand.CanSplit())
            {
                if ((int)upCard.GetCardValue() == 7 || (int)upCard.GetCardValue() == 10 || upCard.GetCardValue().Equals(CardType.ACE))
                {
                    return HandAction.STAND;
                }
                else
                    return HandAction.SPLIT;
            }
            else
            {
                return HandAction.STAND;
            }
        }

        public HandAction handValue19(int count, Hand hand, Card upCard)
        {
            if (hand.IsSoft)
            {
                if ((int)upCard.GetCardValue() == 6)
                {
                    return HandAction.DOUBLE_DOWN;
                }
                else
                    return HandAction.STAND;
            }
            else
            {
                return HandAction.STAND;
            }
        }
    }
}

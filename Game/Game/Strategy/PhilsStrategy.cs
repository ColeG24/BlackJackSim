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
            if (hand.Value == 4)
            {
                if (hand.CanSplit())
                {
                    if ((int)upCard.GetCardValue() >= 3 || (int)upCard.GetCardValue() <= 7)
                    {
                        return HandAction.SPLIT;
                    }
                    else
                        return HandAction.HIT;
                }
                else
                    return HandAction.HIT;
            }

            else if (hand.Value == 5)
            {
                return HandAction.HIT;
            }

            else if (hand.Value == 6)
            {
                if (hand.CanSplit())
                {
                    if ((int)upCard.GetCardValue() >= 4 || (int)upCard.GetCardValue() <= 7)
                    {
                        return HandAction.SPLIT;
                    }
                    else
                        return HandAction.HIT;
                }
                else
                    return HandAction.HIT;
            }

            else if (hand.Value == 7)
            {
                return HandAction.HIT;
            }

            else if (hand.Value == 8)
            {
                if (hand.CanSplit())
                {
                    if ((int)upCard.GetCardValue() == 5 || (int)upCard.GetCardValue() == 6)
                    {
                        return HandAction.DOUBLE;
                    }
                    else
                        return HandAction.HIT;
                }
                else
                {
                    if ((int)upCard.GetCardValue() == 5 || (int)upCard.GetCardValue() == 6)
                    {
                        return HandAction.DOUBLE;
                    }
                    else
                        return HandAction.HIT;
                }
            }

            else if (hand.Value == 9)
            {
                if ((int)upCard.GetCardValue() >= 2 || (int)upCard.GetCardValue() <= 6)
                {
                    return HandAction.DOUBLE;
                }
                else
                    return HandAction.HIT;
            }

            else if (hand.Value == 10)
            {
                if ((int)upCard.GetCardValue() >= 2 || (int)upCard.GetCardValue() <= 9)
                {
                    return HandAction.DOUBLE;
                }
                else
                    return HandAction.HIT;
            }

            else if (hand.Value == 11)
            {
                return HandAction.DOUBLE;
            }

            else if (hand.Value == 12)
            {
                if (hand.CanSplit())
                {
                    if ((int)upCard.GetCardValue() >= 2 || (int)upCard.GetCardValue() <= 6)
                    {
                        return HandAction.SPLIT;
                    }
                    else
                        return HandAction.HIT;
                }
                else
                {
                    if (upCard.GetCardValue().Equals(CardType.ACE) || (int)upCard.GetCardValue() == 6)
                    {
                        return HandAction.DOUBLE;
                    }
                    else
                        return HandAction.HIT;
                }
            }
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

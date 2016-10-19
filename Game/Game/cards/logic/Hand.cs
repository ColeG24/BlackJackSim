using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.cards.logic
{
    public class Hand
    {
        private IList<Card> hand = new List<Card>();
        public decimal InitialBet
        {
            get;
            private set;
        }

        public decimal CurrentBet
        {
            get;
            set;
        }

        public Hand(decimal initialBet)
        {
            InitialBet = initialBet;
        }

        public bool IsSoft
        {
            get;
            private set;
        }

        /// <summary>
        /// Adds up each card in hand. If there is an ace, counts it as an 11, unless that would put the hand over 21, then counts it as 1
        /// </summary>
        public int Value
        {
            get
            {
                int value = 0;
                bool soft = false;
                foreach(Card card in hand)
                {
                    Object cardValue = card.GetCardValue();
                    if (cardValue is int)
                    {
                        value += (int)cardValue;
                    }
                    else if (cardValue is CardType)
                    {
                        CardType cardType = (CardType)cardValue;
                        if (cardType == CardType.ACE)
                        {
                            int aceValue = DetermineValueOfAce(value);
                            if (aceValue == 1)
                            {
                                soft = soft && false; // If the hand is soft already, dont change that
                            }
                            else
                            {
                                soft = true;
                            }
                            value += aceValue;
                        }
                        else
                        {
                            throw new Exception("The card in hand did not have an int value and is not an ace");
                        }
                    }
                    else
                    {
                        throw new Exception("The card in hand did not have an int value and is not an ace");
                    }
                }
                return value;
            }
        }

        private int DetermineValueOfAce(int value)
        {
            if (value + 11 < 21)
            {
                return 11;
            }
            else
            {
                return 1;
            }
        }

        public void AddCard(Card card)
        {
            hand.Add(card);
        }

        public IEnumerable<Card> GetCards()
        {
            foreach(Card card in hand)
            {
                yield return card;
            }
        }

        public bool CanSplit()
        {
            return hand.Count == 2 && hand[0].TypeOfCard == hand[1].TypeOfCard;
        }
    }
}

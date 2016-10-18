using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.cards
{
    public class Card
    {
        private Suit suit;
        private CardType cardType;
        private int bjValue;
        private int countValue;

        public Card(Suit suit, CardType type, int countValue)
        {
            this.suit = suit;
            this.cardType = type;
            this.countValue = countValue;
            this.bjValue = DetermineBjValue(cardType);
        }

        public Object GetCardValue()
        {
            if (cardType == CardType.ACE)
            {
                return cardType;
            }
            else
            {
                return bjValue;
            }
        }

        public int getCountValue()
        {
            return countValue;
        }

        private int DetermineBjValue(CardType cardType)
        {
            switch(cardType)
            {
                case CardType.TWO: return 2;
                case CardType.THREE: return 3;
                case CardType.FOUR: return 4;
                case CardType.FIVE: return 5;
                case CardType.SIX: return 6;
                case CardType.SEVEN: return 7;
                case CardType.EIGHT: return 8;
                case CardType.NINE: return 9;
                case CardType.ACE: return 0;
                default: return 10;
            }
        }
    }
}

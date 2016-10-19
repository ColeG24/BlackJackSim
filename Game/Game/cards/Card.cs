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
        public CardType TypeOfCard
        {
            get;
            private set;
        }
        private int bjValue;

        public Card(Suit suit, CardType type)
        {
            this.suit = suit;
            this.TypeOfCard = type;
            this.bjValue = DetermineBjValue(TypeOfCard);
        }
        
        public Object GetCardValue()
        {
            if (TypeOfCard == CardType.ACE)
            {
                return TypeOfCard;
            }
            else
            {
                return bjValue;
            }
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

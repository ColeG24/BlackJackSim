using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.cards
{
    public class Deck
    {
        private Dictionary<CardType, int> countSystem;
        private IList<Card> originalDeck = new List<Card>();

        public Deck(int numDecks) : this(NoCountSytem(), numDecks)
        {
        }

        public Deck(Dictionary<CardType, int> countSystem, int numDecks)
        {
            for(int i = 0; i < numDecks; i++)
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        Card card = new Card(suit, type, countSystem[type]);
                        originalDeck.Add(card);
                    }
                }
            }
        }

        private static Dictionary<CardType, int> NoCountSytem()
        {
            Dictionary<CardType, int> countSystem = new Dictionary<CardType, int>();
            foreach (CardType type in Enum.GetValues(typeof(CardType)))
            {
                countSystem.Add(type, 0);
            }
            return countSystem;
        }
    }
}

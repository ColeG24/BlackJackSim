using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.cards
{
    public class Deck
    {
        private IList<Card> originalDeck = new List<Card>();
        private IList<Card> currentDeckState = new List<Card>();

        private int randomSeed = -1;

        public Deck(int numDecks)
        {
            for(int i = 0; i < numDecks; i++)
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        Card card = new Card(suit, type);
                        originalDeck.Add(card);
                    }
                }
            }
            ShuffleDeck();
        }

        public Deck(int numDecks, int randomSeed)
        {
            this.randomSeed = randomSeed;
            for (int i = 0; i < numDecks; i++)
            {
                foreach (CardType type in Enum.GetValues(typeof(CardType)))
                {
                    foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                    {
                        Card card = new Card(suit, type);
                        originalDeck.Add(card);
                    }
                }
            }
            ShuffleDeck();
        }

        /// <summary>
        /// Used to make
        /// </summary>
        /// <param name="cards"></param>
        public Deck(IList<Card> cards)
        {
            foreach(Card card in cards)
            {
                originalDeck.Add(card);
            }
            foreach (Card card in originalDeck)
            {
                currentDeckState.Add(card);
            }
        }

        /// <summary>
        /// Resets the deck without shuffling
        /// </summary>
        public void ResetDeck()
        {
            currentDeckState.Clear();
            foreach (Card card in originalDeck)
            {
                currentDeckState.Add(card);
            }
        }

        public void ShuffleDeck()
        {
            Random rng;
            if (randomSeed != -1)
            {
                rng = new Random(randomSeed);
            }
            else
            {
                rng = new Random();
            }
            int n = originalDeck.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Card value = originalDeck[k];
                originalDeck[k] = originalDeck[n];
                originalDeck[n] = value;
            }
            currentDeckState.Clear();
            foreach(Card card in originalDeck)
            {
                currentDeckState.Add(card);
            }
        }

        public Card Draw()
        {
            if (currentDeckState.Count < 1)
            {
                    throw new DeckOutOFCardsException();
            }
            Card card = currentDeckState.ElementAt(0);
            currentDeckState.RemoveAt(0);
            return card;
        }

        public int CardsLeft()
        {
            return currentDeckState.Count;
        }

    }

    /// <summary>
    /// Thrown when a deck is out of cards
    /// </summary>
    [Serializable]
    public class DeckOutOFCardsException : Exception
    {
        public DeckOutOFCardsException() { }
        public DeckOutOFCardsException(string message) : base(message) { }
        public DeckOutOFCardsException(string message, Exception inner) : base(message, inner) { }
        protected DeckOutOFCardsException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}

﻿using System;
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

        public Deck(List<Card> cards)
        {
            foreach(Card card in cards)
            {
                originalDeck.Add(card);
            }
            ShuffleDeck();
        }

        public void ShuffleDeck()
        {
            Random rng = new Random();
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

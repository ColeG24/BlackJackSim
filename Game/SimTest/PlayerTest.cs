using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.participants;
using Game.Strategy;
using Game.cards;
using System.Collections.Generic;

namespace SimTest
{
    [TestClass]
    public class PlayerTest
    {
        [TestMethod]
        public void PlayerWonTest()
        {
            IList<Card> fixedCards = new List<Card>();
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.TEN));
            fixedCards.Add(new Card(Suit.CLUB, CardType.TEN));

            Deck deck = new Deck(fixedCards);
            Player player = new Player(new BasicStrategy(), "test");
            player.SetDeck(deck);

            player.DoInitialDraw();
            player.PlayOutRound(new Card(Suit.SPADE, CardType.NINE));
            player.EndRound(17, false);

            Assert.AreEqual(5, player.Balance);
        }

        [TestMethod]
        public void DealerWonTest()
        {
            IList<Card> fixedCards = new List<Card>();
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.TEN));
            fixedCards.Add(new Card(Suit.CLUB, CardType.TEN));

            Deck deck = new Deck(fixedCards);
            Player player = new Player(new BasicStrategy(), "test");
            player.SetDeck(deck);

            player.DoInitialDraw();
            player.PlayOutRound(new Card(Suit.SPADE, CardType.NINE));
            player.EndRound(20, false);

            Assert.AreEqual(0, player.Balance);
        }

        [TestMethod]
        public void PlayerHasBjTest()
        {
            IList<Card> fixedCards = new List<Card>();
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.TEN));
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.ACE));

            Deck deck = new Deck(fixedCards);
            Player player = new Player(new BasicStrategy(), "test");
            player.SetDeck(deck);

            player.DoInitialDraw();
            player.PlayOutRound(new Card(Suit.SPADE, CardType.NINE));
            player.EndRound(17, false);

            Assert.AreEqual(7.5M, player.Balance);
        }

        [TestMethod]
        public void PlayerAndDealerHaveBjTest()
        {
            IList<Card> fixedCards = new List<Card>();
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.TEN));
            fixedCards.Add(new Card(Suit.DIAMOND, CardType.ACE));

            Deck deck = new Deck(fixedCards);
            Player player = new Player(new BasicStrategy(), "test");
            player.SetDeck(deck);

            player.DoInitialDraw();
            player.PlayOutRound(new Card(Suit.HEART, CardType.TEN));
            player.EndRound(21, true);

            Assert.AreEqual(0, player.Balance);
        }

    }
}

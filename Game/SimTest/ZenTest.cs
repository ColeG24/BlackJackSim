using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Strategy;
using Game.participants.actions;
using Game.cards.logic;
using Game.cards;
using System.Collections.Generic;
using Game.participants;

namespace SimTest
{
    [TestClass]
    public class ZenTest
    {
        [TestMethod]
        public void CountTest1()
        {
            ZenStrategy zs = new ZenStrategy();
            Player p = new Player(zs, "bob");

            List<Card> cardsSeen = new List<Card>();

            cardsSeen.Add(new Card(Suit.DIAMOND, CardType.KING));
            cardsSeen.Add(new Card(Suit.DIAMOND, CardType.FIVE));
            cardsSeen.Add(new Card(Suit.DIAMOND, CardType.TWO));
            cardsSeen.Add(new Card(Suit.DIAMOND, CardType.ACE));


            p.AdjustCount(cardsSeen);
            
            Assert.AreEqual(0, p.Count);

            cardsSeen.Add(new Card(Suit.DIAMOND, CardType.FOUR));

            p.AdjustCount(cardsSeen);

            Assert.AreEqual(2, p.Count);


            Hand playersHand = new Hand(5);
            playersHand.AddCard(new Card(Suit.DIAMOND, CardType.KING));
            playersHand.AddCard(new Card(Suit.DIAMOND, CardType.FIVE));

            p.SetDeck(new Deck(1));
            p.DoInitialDraw();
            p.PlayOutRound(new Card(Suit.DIAMOND, CardType.TEN));
            Assert.AreEqual(2, p.Count);
        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.Strategy;
using Game.participants;
using Game.participants.actions;
using Game.cards.logic;
using Game.cards;

namespace SimTest
{
    [TestClass]
    public class BasicStrategyTest
    {
        [TestMethod]
        public void TestLowAgainstLow()
        {
            BasicStrategy bs = new BasicStrategy();
            HandAction ha = HandAction.HIT;
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.TWO);
            Card playersSecondCard = new Card(Suit.HEART, CardType.TWO);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.TWO);
            Assert.AreEqual(ha, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }

        [TestMethod]
        public void TestHighAgainstLow()
        {
            BasicStrategy bs = new BasicStrategy();
            HandAction ha = HandAction.STAND;
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.KING);
            Card playersSecondCard = new Card(Suit.HEART, CardType.EIGHT);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.FIVE);
            Assert.AreEqual(ha, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }

        [TestMethod]
        public void TestHighAgainstHigh()
        {
            BasicStrategy bs = new BasicStrategy();
            HandAction ha = HandAction.STAND;
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.KING);
            Card playersSecondCard = new Card(Suit.HEART, CardType.EIGHT);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.KING);
            Assert.AreEqual(ha, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }

        [TestMethod]
        public void TestAcesAgainstHigh()
        {
            BasicStrategy bs = new BasicStrategy();
            HandAction ha = HandAction.SPLIT;
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.ACE);
            Card playersSecondCard = new Card(Suit.HEART, CardType.ACE);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.KING);
            Assert.AreEqual(ha, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }

        [TestMethod]
        public void TestDoubleDownOn11()
        {
            BasicStrategy bs = new BasicStrategy();
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.NINE);
            Card playersSecondCard = new Card(Suit.HEART, CardType.TWO);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.KING);
            Assert.AreEqual(HandAction.DOUBLE_DOWN, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }

        [TestMethod]
        public void TestSplit8s()
        {
            BasicStrategy bs = new BasicStrategy();
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.EIGHT);
            Card playersSecondCard = new Card(Suit.HEART, CardType.EIGHT);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.KING);
            Assert.AreEqual(HandAction.SPLIT, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }


        [TestMethod]
        public void TestSplitAces()
        {
            BasicStrategy bs = new BasicStrategy();
            Hand playersHand = new Hand(0);
            Card playersFirstCard = new Card(Suit.DIAMOND, CardType.ACE);
            Card playersSecondCard = new Card(Suit.HEART, CardType.ACE);
            playersHand.AddCard(playersFirstCard);
            playersHand.AddCard(playersSecondCard);
            Card dealerUpCard = new Card(Suit.CLUB, CardType.KING);
            Assert.AreEqual(HandAction.SPLIT, bs.DetermineActionForHand(0, playersHand, dealerUpCard));
        }
    }
}

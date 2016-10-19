using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.cards.logic;

namespace SimTest
{
    [TestClass]
    public class HandTest
    {
        [TestMethod]
        public void BetTest()
        {
            Hand hand = new Hand(20);
            Assert.AreEqual(20, hand.InitialBet);
            Assert.AreEqual(20, hand.CurrentBet);
        }
    }
}

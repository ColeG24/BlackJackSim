using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.participants;
using Game.cards;
using Game.Strategy;

namespace SimTest
{
    [TestClass]
    public class DealerTest
    {
        [TestMethod]
        public void BasicTest()
        {
            Dealer dealer = new Dealer(new DealerStrategy());
            dealer.SetDeck(new Deck(1));
            dealer.DoInitialDraw();
            dealer.PlayOutRound(dealer.FaceUpCard);
            Card card = dealer.FaceUpCard;
            int score = dealer.RoundValue;
            dealer.EndRound(score, false);
            Assert.IsTrue(score >= 17);
        }

    }
}

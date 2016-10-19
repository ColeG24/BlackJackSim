using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Game.cards;

namespace SimTest
{
    [TestClass]
    public class CardAndDeckTest
    {
        [TestMethod]
        [ExpectedException(typeof(DeckOutOFCardsException))]
        public void DeckOutOfCardsTest()
        {
            Deck d = new Deck(1);
            for (int i = 0; i < 53; i++)
            {
                d.Draw();
            }
        }

        [TestMethod]
        public void CorrectDeckSizeTest()
        {
            Deck d = new Deck(1);
            Assert.AreEqual(52, d.CardsLeft());
            d.Draw();
            Assert.AreEqual(51, d.CardsLeft());
            d.ShuffleDeck();
            Assert.AreEqual(52, d.CardsLeft());

            d = new Deck(2);
            Assert.AreEqual(104, d.CardsLeft());
            d.Draw();
            Assert.AreEqual(103, d.CardsLeft());
            d.ShuffleDeck();
            Assert.AreEqual(104, d.CardsLeft());

        }
    }
}

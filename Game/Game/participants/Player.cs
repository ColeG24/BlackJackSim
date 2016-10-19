using Game.cards.logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.participants.actions;
using Game.cards;
using Game.Strategy;

namespace Game.participants
{
    class Player: Participant
    {
        private IList<Hand> hands = new List<Hand>();
        private int count;

        public Player(Deck deck, AbstractStrategy strategy) : base(deck, strategy)
        {
        }

        private void Split(int handToSplit)
        {
            Hand originalHand = hands[handToSplit];
            if (originalHand.CanSplit())
            {
                hands.Remove(originalHand);
                Hand hand1 = new Hand(originalHand.InitialBet);
                hand1.AddCard(originalHand.GetCards().First());

                Hand hand2 = new Hand(originalHand.InitialBet);
                hand2.AddCard(originalHand.GetCards().Last());
            }
        }

        public override void EndRound(int dealerValue, bool isBlackJack)
        {
            throw new NotImplementedException();
        }
    }
}

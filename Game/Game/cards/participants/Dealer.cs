using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.Strategy;
using Game.cards.logic;
using Game.participants.actions;

namespace Game.participants
{
    public class Dealer : Participant
    {
        private Hand hand = new Hand(0);
        public Card FaceUpCard
        {
            get;
            private set;
        }

        public int RoundValue
        {
            get;
            private set;
        }

        public Dealer(Deck deck, DealerStrategy strategy) : base(deck, strategy)
        {
        }

        public override void EndRound(int dealerValue, bool isBlackJack)
        {
            FaceUpCard = null; // no face up card at the end of round
            RoundValue = 0;
            hand = new Hand(0);
        }

        public override void PlayOutRound()
        {
            while (strategy.DetermineActionForHand(0, hand, FaceUpCard) != HandAction.STAND)
            {
                if (strategy.DetermineActionForHand(0, hand, FaceUpCard) == HandAction.HIT)
                {
                    hand.AddCard(deck.Draw());
                }
            }
            RoundValue = hand.Value;
        }

        public override void DoInitialDraw()
        {
            hand.AddCard(deck.Draw());
            hand.AddCard(deck.Draw());
            FaceUpCard = hand.GetCards().First();
        }

        public bool CanTakeInsurance()
        {
            return FaceUpCard.TypeOfCard == CardType.ACE;
        }


    }
}

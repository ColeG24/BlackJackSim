using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.Strategy;
using Game.cards.logic;

namespace Game.participants
{
    class Dealer : Participant
    {
        private Hand hand = new Hand(0);
        public Card FaceUpCard
        {
            get;
            private set;
        }

        public Dealer(Deck deck, AbstractStrategy strategy) : base(deck, strategy)
        {
        }

        public override void EndRound(int dealerValue, bool isBlackJack)
        {
            throw new NotImplementedException();
        }

        public override void PlayOutRound()
        {
            throw new NotImplementedException();
        }

        public override void DoInitialDraw()
        {
            throw new NotImplementedException();
        }
    }
}

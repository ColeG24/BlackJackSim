using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.cards;
using Game.Strategy;

namespace Game.participants
{
    class Dealer : Participant
    {
        public Dealer(Deck deck, AbstractStrategy strategy) : base(deck, strategy)
        {
        }
    }
}

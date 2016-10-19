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
        private Card upCard;
        private decimal balance;

        public Player(Deck deck, AbstractStrategy strategy) : base(deck, strategy)
        {
        }

        private void Split(Hand hand)
        {
            Hand originalHand = hand;
            if (originalHand.CanSplit())
            {
                hands.Remove(originalHand);
                Hand hand1 = new Hand(originalHand.InitialBet);
                hand1.AddCard(originalHand.GetCards().First());

                Hand hand2 = new Hand(originalHand.InitialBet);
                hand2.AddCard(originalHand.GetCards().Last());
            }
            else
            {
                throw new Exception("You can not split noob");

            }
        }

        /// <summary>
        /// Hits the hand. Returns true if this causes a bust, and false otherwise
        /// </summary>
        /// <param name="hand">The hand to hit</param>
        /// <returns>If hitting would cause a bust</returns>
        private bool Hit(Hand hand)
        {
            Hand originalHand = hand;
            if (hand.Value <= 21)
            {
                hand.AddCard(deck.Draw());
                return hand.Value <= 21;
            }
            else
            {
                throw new Exception("You can not hit on a hand that is over 21 noob");
            }
        }

        public override void EndRound(int dealerValue, bool isBlackJack)
        {
            foreach(Hand hand in hands)
            {
                if (hand.Value > 21)
                {
                    balance -= hand.CurrentBet;
                }
                else if (hand.Value > dealerValue || dealerValue > 21)
                {
                    balance += hand.CurrentBet;
                }
                else if (hand.Value < dealerValue)
                {
                    balance -= hand.CurrentBet;
                }
            }
        }

        public override void PlayOutRound()
        {
            PlayOutHand(hands[0]);
        }

        private void PlayOutHand(Hand hand)
        {
            HandAction action = strategy.DetermineActionForHand(count, hand, upCard);
            while (action != HandAction.STAND)
            {
               switch(action)
                {
                    case HandAction.HIT:
                        if (Hit(hand))
                        {
                            return;
                        }
                        else
                        {
                            break;
                        }
                    case HandAction.SPLIT:
                        Split(hand);
                        PlayOutHand(hands[hands.Count - 2]);
                        PlayOutHand(hands[hands.Count - 2]);
                        return;
                    case HandAction.DOUBLE_DOWN:
                        DoubleDown(hand);
                        return;     
                }
            }
        }

        private void DoubleDown(Hand hand)
        {
            hand.CurrentBet = hand.CurrentBet * 2; // Double hands current bet
            Hit(hand);
        }

        public void SetDealerUpCard(Card card)
        {
            upCard = card;
        }

        public override void DoInitialDraw()
        {
            Hand hand = new Hand(strategy.BetAmount(count));
            hand.AddCard(deck.Draw());
            hand.AddCard(deck.Draw());
            hands.Add(hand);
        }
    }
}

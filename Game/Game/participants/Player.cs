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
    public class Player: Participant
    {
        private IList<Hand> hands = new List<Hand>();
        private int count;
        private Card upCard;
        private bool hasBJ;
        private Dictionary<int, double> countratio = new Dictionary<int, double>();
        private Dictionary<int, int> insuranceRatio = new Dictionary<int, int>();
        private int currentRoundMultiplier = 1;



        public decimal Balance
        {
            get;
            private set;
        }
        public string name
        {
            get;
            private set;
        }
        public int InsuranceTaken
        {
            get;
            private set;
        }

        private decimal insuranceBet;

        public Player(AbstractStrategy strategy, string name) : base(strategy)
        {
            this.name = name;
        }

        public void ResetCount()
        {
            count = 0;
        }

        private void Split(Hand hand)
        {
            Hand originalHand = hand;
            if (originalHand.CanSplit())
            {
                hands.Remove(originalHand);
                Hand hand1 = new Hand(originalHand.InitialBet);
                Card card1 = originalHand.GetCards().First();
                hand1.AddCard(card1);
                Hand hand2 = new Hand(originalHand.InitialBet);
                hand2.AddCard(originalHand.GetCards().Last());

                if (card1.TypeOfCard == CardType.ACE)
                {
                    hand1.HitsLeft = 1;
                    hand2.HitsLeft = 1;
                }
                hands.Add(hand1);
                hands.Add(hand2);
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
            if (!hand.CanHit())
            {
                throw new Exception("You can not hit this hand noob");
            }
            if (hand.Value <= 21)
            {
                hand.AddCard(deck.Draw());
                hand.HitsLeft--;
                return hand.Value <= 21;
            }
            else
            {
                throw new Exception("You can not hit on a hand that is over 21 noob");
            }
        }

        public override void EndRound(int dealerValue, bool dealerHasBj)
        {
            if (!countratio.ContainsKey(count))
            {
                countratio.Add(count, 0);
            }
            foreach (Hand hand in hands)
            {
                if (hand.Value > 21)
                {
                    countratio[count] -= currentRoundMultiplier;
                    double currentCount = countratio[count];
                    Balance -= hand.CurrentBet;
                }
                else if (hasBJ && !dealerHasBj)
                {
                    countratio[count] = countratio[count] + 1.5;
                    double currentCount = countratio[count];
                    Balance += hand.CurrentBet * 1.5M;
                }
                else if (hand.Value > dealerValue || dealerValue > 21)
                {
                    countratio[count] += currentRoundMultiplier;
                    double currentCount = countratio[count];
                    Balance += hand.CurrentBet; // Dealer val is not updating correctly
                }
                else if (hand.Value < dealerValue)
                {
                    countratio[count] -= currentRoundMultiplier;
                    double currentCount = countratio[count];
                    Balance -= hand.CurrentBet;
                }
            }

            // Reset player to preround state
            currentRoundMultiplier = 1;
            hasBJ = false;
            hands.Clear();
            insuranceBet = 0;
            upCard = null;
        }

        public double GetWinAmountFor(int count)
        {
            return countratio[count];
        }

        public int GetInsuranceWinAmountFor(int count)
        {
            return insuranceRatio[count];
        }


        public override void PlayOutRound(Card dealerUpCard)
        {
            if (hasBJ)
            {
                return;
            }
            this.upCard = dealerUpCard;
            PlayOutHand(hands[0]);
        }

        public bool TakeInsurance(Card dealerUpCard)
        {
            if (dealerUpCard.TypeOfCard == CardType.ACE)
            {
                if (strategy.TakeInsurance(count, hands[0]))
                {
                    insuranceBet = hands[0].InitialBet / 2;
                    return true;
                }
            }
            return false;
        }

        public IEnumerable<Card> GetCurrentRoundCards()
        {
            foreach (Hand hand in hands)
            {
                foreach(Card card in hand.GetCards())
                {
                    yield return card;
                }
            }
        }

        public void AdjustCount(IEnumerable<Card> cardsSeen)
        {
            foreach(Card card in cardsSeen)
            {
                count += strategy.GetCountValueOfCard(card);
            }
        }



        private void PlayOutHand(Hand hand)
        {
            HandAction action = strategy.DetermineActionForHand(count, hand, upCard);
            while (action != HandAction.STAND)
            {
                action = strategy.DetermineActionForHand(count, hand, upCard);
                switch (action)
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
                        PlayOutHand(hands[hands.Count - 1]);
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
            currentRoundMultiplier = 2;
            hand.CurrentBet = hand.CurrentBet * 2; // Double hands current bet
            hand.HitsLeft = 1;
            Hit(hand);
        }

        public override void DoInitialDraw()
        {
            decimal betAmount = strategy.BetAmount(count);
            Hand hand = new Hand(betAmount);
            hand.AddCard(deck.Draw());
            hand.AddCard(deck.Draw());
            hands.Add(hand);
            if (hand.IsBlackJack())
            {
                hasBJ = true;
            }

        }

        public void AdjustBalanceFromInsuranceBet(bool dealerHasBlackjack)
        {
            if (!insuranceRatio.ContainsKey(count))
            {
                insuranceRatio.Add(count, 0);
            }
            if (dealerHasBlackjack)
            {
                insuranceRatio[count] += 2;
                Balance += insuranceBet * 2;
            }
            else
            {
                insuranceRatio[count]--;
                Balance -= insuranceBet;
            }
        }

    }
}

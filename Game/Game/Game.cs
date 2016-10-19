using Game.cards;
using Game.participants;
using Game.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public class Game
    {
        private IList<Player> players;
        public Game(int roundsToPlay, IList<Player> players, Deck deck, double penetrationPercent)
        {
            this.players = players;

            double initialDeckSize = deck.CardsLeft();
            double penetrationAsDouble = penetrationPercent / 100;      
                
            Dealer dealer = new Dealer(new DealerStrategy());
            dealer.SetDeck(deck);

            foreach (Player player in players)
            {
                player.SetDeck(deck);
            }

            while (roundsToPlay > 0)
            {
                double currentCardsLeft = deck.CardsLeft();
                double currentPenetration = 1 - (currentCardsLeft / initialDeckSize);
                if (currentPenetration > penetrationAsDouble)
                {
                    deck.ShuffleDeck();
                }

                dealer.DoInitialDraw();
                foreach(Player player in players)
                {
                    player.DoInitialDraw();
                }

                Card upCard = dealer.FaceUpCard;

                if (dealer.CanTakeInsurance())
                {
                    bool hasBlackJack = dealer.HasBlackJack();

                    foreach (Player player in players)
                    {
                        if (player.TakeInsurance(upCard))
                        {
                            player.AdjustBalanceFromInsuranceBet(hasBlackJack);
                        }
                        if (hasBlackJack)
                        {
                            player.EndRound(dealer.RoundValue);
                        }
                    }

                    if (hasBlackJack) // Then end round
                    {
                        dealer.EndRound(dealer.RoundValue);
                        continue;
                    }
                }

                foreach (Player player in players)
                {
                    player.PlayOutRound(upCard);
                }

                dealer.PlayOutRound(upCard);

                foreach (Player player in players)
                {
                    player.EndRound(dealer.RoundValue);
                }

                dealer.EndRound(dealer.RoundValue);
            }
        }
    }
}

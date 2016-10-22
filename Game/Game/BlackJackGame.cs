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
    public class BlackJackGame
    {
        private IList<Player> players;
        private int roundsToPlay;
        private Deck deck;
        private Dealer dealer;
        private double initialDeckSize;
        private double penetrationAsDouble;

        public BlackJackGame(int roundsToPlay, IList<Player> players, Deck deck, double penetrationPercent)
        {
            this.players = players;
            this.roundsToPlay = roundsToPlay;

            initialDeckSize = deck.CardsLeft();
            penetrationAsDouble = penetrationPercent / 100;      
                
            dealer = new Dealer(new DealerStrategy());
            this.deck = deck;
            dealer.SetDeck(deck);

            foreach (Player player in players)
            {
                player.SetDeck(deck);
            }
        }

        public void PlayRound()
        {
            // Check if we need to reshuffle
            double currentCardsLeft = deck.CardsLeft();
            double currentPenetration = 1 - (currentCardsLeft / initialDeckSize);
            if (currentPenetration > penetrationAsDouble)
            {
                deck.ShuffleDeck();
                foreach (Player player in players)
                {
                    player.ResetCount();
                }
            }

            dealer.DoInitialDraw();
            foreach (Player player in players)
            {
                player.DoInitialDraw();
            }

            Card upCard = dealer.FaceUpCard;

            if (dealer.CanTakeInsurance())
            {
                bool hasBlackJack = dealer.HasBlackJack();

                    foreach (Player player in players)
                    {
                        if (player.TakeInsurance(upCard)) // If player took insurance
                        {
                            player.AdjustBalanceFromInsuranceBet(hasBlackJack); // adjust balance based off if dealer had bj
                        }
                    }

                if (hasBlackJack) // Then end round
                {
                    // Track cards that were seen
                    IList<Card> cardsSeen = new List<Card>();
                    foreach (Player player in players)
                    {
                        foreach (Card card in player.GetCurrentRoundCards())
                        {
                            cardsSeen.Add(card);
                        }
                    }
                    foreach (Card card in dealer.GetCurrentRoundCards())
                    {
                        cardsSeen.Add(card);
                    }

                        //Adjust count for players
                        foreach (Player player in players)
                        {
                            player.AdjustCount(cardsSeen);
                            player.EndRound(dealer.RoundValue, hasBlackJack);
                        }

                    dealer.EndRound(dealer.RoundValue, hasBlackJack);
                    roundsToPlay--;
                    return;
                }
            }

            // Play out round for dealer and player, and track cards seen
            IList<Card> cardsSeenThisRound = new List<Card>();
            foreach (Player player in players)
            {
                player.PlayOutRound(upCard);
                foreach (Card card in player.GetCurrentRoundCards())
                {
                    cardsSeenThisRound.Add(card);
                }
            }
            dealer.PlayOutRound(upCard);
            foreach (Card card in dealer.GetCurrentRoundCards())
            {
                cardsSeenThisRound.Add(card);
            }

                // Ends game for players and dealer
                foreach (Player player in players)
                {
                    player.EndRound(dealer.RoundValue, false);
                }

                dealer.EndRound(dealer.RoundValue, false);


                //Adjust count for players
                foreach (Player player in players)
                {
                    player.AdjustCount(cardsSeenThisRound);
                }

                roundsToPlay--;
            }

        public double ApproximateHoursOfPlay() // According to some website
        {
            int numberOfPlayers = players.Count;
            double roundsPerHour;
            switch (numberOfPlayers)
            {
                case 1:
                    roundsPerHour = 209;
                    break;
                case 2:
                    roundsPerHour = 139;
                    break;
                case 3:
                    roundsPerHour = 105;
                    break;
                case 4:
                    roundsPerHour = 84;
                    break;
                case 5:
                    roundsPerHour = 70;
                    break;
                case 6:
                    roundsPerHour = 60;
                    break;
                case 7:
                    roundsPerHour = 52;
                    break;
                default:
                    throw new Exception("Illegal number of players");
            }
            return (double)roundsToPlay / roundsPerHour;
        }
    }
}

using Game;
using Game.cards;
using Game.participants;
using Game.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    class EntryPoint
    {
        private static Dictionary<String, decimal> balance = new Dictionary<string, decimal>();

        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread2 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread3 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread4 = new Thread(new ThreadStart(WriteGameResults));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
 

            Console.Read();

        }

        private static void PlayOutRounds(BlackJackGame game, int numRounds)
        {
            for (int i = 0; i < numRounds; i++)
            {
                game.PlayRound();
            }
        }

        private static void WriteGameResults()
        {
            Player player1 = new Player(new UshtonStrategy(), "Ushton");
            Player player2 = new Player(new ZenStrategy(), "Zen");
            Deck deck = new Deck(1);

            IList<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);

            foreach (Player player in players)
            {
                player.SetDeck(deck);
            }


            BlackJackGame game = new BlackJackGame(players, deck, 50.0);
            int roundsToPlay = 1000000;
            PlayOutRounds(game, roundsToPlay);
            double approxHours = game.ApproximateHoursOfPlay(roundsToPlay);

            lock(game) {
                foreach (Player player in players)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Name: " + player.name);
                    Console.WriteLine("Balance: " + player.Balance);
                    Console.WriteLine("Rate: " + (double)player.Balance / approxHours);
                    for (int i = 0; i < 25; i++)
                    {
                        Console.WriteLine("Win rate at count = " + i + " :" + player.GetWinAmountFor(i));
                        Console.WriteLine("Insurance rate at count = " + i + " :" + player.GetInsuranceWinAmountFor(i));
                    }
                    if (balance.ContainsKey(player.name))
                    {
                        balance[player.name] += player.Balance;
                    }
                    else
                    {
                        balance.Add(player.name, player.Balance);
                    }
                }
            }
          

        }
    }
}

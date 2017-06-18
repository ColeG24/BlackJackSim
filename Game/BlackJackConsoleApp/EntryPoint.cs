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
        //private static Dictionary<String, decimal> balance = new Dictionary<string, decimal>();
        private static Object lockObject = new Object();
        private static long avgCardsPlayed;

        private static Dictionary<String, Results> results = new Dictionary<string, Results>();

        private static int seed = -1;
        private static int rounds = -1;


        private static int threadsDone = 0;
        private static Action onThreadComplete;

        static void Main(string[] args)
        {
            Start();
        }

        private static void Start()
        {
            results.Clear();
            threadsDone = 0;

            Console.WriteLine("Enter how many rounds");
            int num1;
            if (int.TryParse(Console.ReadLine(), out num1))
            {
                if (num1 > 0)
                    rounds = num1;
                else
                {
                    rounds = 1000;
                }
            }
            else
            {
                rounds = 1000;
            }
            Console.WriteLine("Enter a number for seed");
            int num;
            if (int.TryParse(Console.ReadLine(), out num))
            {
                seed = num;
            }

            onThreadComplete = OnThreadComplete;
            Thread thread1 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread2 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread3 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread4 = new Thread(new ThreadStart(WriteGameResults));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
        }

        private static void OnThreadComplete()
        {
            while (true)
            {
                String[] line = Console.ReadLine().Split(' ');
                if (threadsDone != 4)
                {
                    Console.WriteLine("Wait up");
                }

                if (line.Length > 0)
                {
                    switch (line[0].ToLower())
                    {
                        case "exit":
                        case "quit":
                            return;
                        case "balance":
                            HandleBalance(line);
                            break;
                        case "count":
                            HandleCount(line);
                            break;
                        case "insurance":
                            HandleInsurance(line);
                            break;
                        case "pen":
                            Console.WriteLine("Average Cards Left On Reshuffle: " + avgCardsPlayed / 4); // Dont think this is correct. need some tests around this
                            break;
                        case "restart":
                            Start();
                            return;
                        default:
                            Console.WriteLine("Unrecognized command");
                            break;
                    }
                }
            }
        }

        private static void HandleBalance(String[] line)
        {
            if (line.Length >= 2)
            {
                String name = line[1];
                if (results.ContainsKey(name))
                {
                    Console.WriteLine(name + " Balance: " + results[name].Balance);
                }
                else
                {
                    Console.WriteLine("No player named " + name + " found");
                }
            }
            else
            {
                Console.WriteLine("Unrecognized command");
            }
        }


        private static void HandleCount(String[] line)
        {
            if (line.Length >= 3)
            {
                String name = line[1];
                if (results.ContainsKey(name))
                {
                    int count;
                    if (int.TryParse(line[2], out count))
                    {
                        decimal amount = results[name].getWinAmountAtCount(count);
                        Console.WriteLine(name + " win at count of " + count + ": " + amount);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                }
                else
                {
                    Console.WriteLine("No Player named " + name + " found");
                }
            }
            else
            {
                Console.WriteLine("Unrecognized command");
            }
        }

        private static void HandleInsurance(String[] line)
        {
            if (line.Length >= 3)
            {
                String name = line[1];
                if (results.ContainsKey(name))
                {
                    int count;
                    if (int.TryParse(line[2], out count))
                    {
                        decimal amount = results[name].getInsuranceWinAmountAtCount(count);
                        Console.WriteLine(name + " insurance win at count of " + count + ": " + amount);
                    }
                    else
                    {
                        Console.WriteLine("Error");
                    }

                }
                else
                {
                    Console.WriteLine("No Player named " + name + " found");
                }
            }
            else
            {
                Console.WriteLine("Unrecognized command");
            }
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
            Player player1 = new Player(new UshtonStrategy(), "u");
            Player player2 = new Player(new ZenStrategy(), "zen");
            Player player3 = new Player(new BasicStrategy(), "b");

            Deck deck;
            if (seed != -1)
            {
                lock (lockObject)
                {
                    deck = new Deck(1, seed++);
                }
            }
            else
            {
                deck = new Deck(1);
            }


            IList<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);

            foreach (Player player in players)
            {
                player.SetDeck(deck);
            }


            BlackJackGame game = new BlackJackGame(players, deck, 50.0);
            //int roundsToPlay = 50000;
            PlayOutRounds(game, rounds);
            double approxHours = game.ApproximateHoursOfPlay(rounds);

            lock(lockObject) {
                foreach (Player player in players)
                {
                    Console.WriteLine("---------------------------------------------------");
                    Console.WriteLine("Name: " + player.name);
                    Console.WriteLine("Balance: " + player.Balance);
                    Console.WriteLine("Rate: " + (double)player.Balance / approxHours);

                    if (!results.ContainsKey(player.name))
                    {
                        results.Add(player.name, new Results());
                    }
                    results[player.name].Balance += player.Balance;

                    for (int i = -25; i < 25; i++)
                    {
                        //Console.WriteLine("Win rate at count = " + i + " :" + player.GetWinAmountFor(i));
                        results[player.name].AddWinAmountAtCount(i, player.GetWinAmountFor(i));
                        results[player.name].AddInsuranceWinAmountAtCount(i, player.GetInsuranceWinAmountFor(i));
                        //Console.WriteLine("Insurance rate at count = " + i + " :" + player.GetInsuranceWinAmountFor(i));
                    }
                }
                threadsDone++;
                if (threadsDone == 4)
                {
                    OnThreadComplete();
                }
                avgCardsPlayed += game.AverageCardsLeft();
            }

        }
    }
}

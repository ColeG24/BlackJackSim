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
        static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(WriteGameResultsPhilsVersion));
            //Thread thread2 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread3 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread4 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread5 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread6 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread7 = new Thread(new ThreadStart(WriteGameResults));
            //Thread thread8 = new Thread(new ThreadStart(WriteGameResults));

            thread1.Start();
            //thread2.Start();
            //thread3.Start();
            //thread4.Start();
            //thread5.Start();
            //thread6.Start();
            //thread7.Start();
            //thread8.Start();


            Console.Read();

        }

        private static void WriteGameResultsPhilsVersion()
        {
           // Player player1 = new Player(new ZenStrategy(), "Bob");
            Player player2 = new Player(new UshtonStrategy(), "John");
            // players.Add(player1);
            // players.Add(player2);
            
            int numOfPlayers = 7;
            int numOfRounds = 2;
            while (numOfPlayers > 0)
            {
                List<Player> players = new List<Player>();
                Deck deck = new Deck(1);
                EntryPoint ep = new EntryPoint();
                ep.createPlayers(numOfPlayers, players);
                // Adjust rounds accordingly
                if (numOfPlayers == 4)
                {
                    numOfRounds = 3;
                }
                if (numOfPlayers == 3)
                {
                    numOfRounds = 4;
                }
                if (numOfPlayers == 2)
                {
                    numOfRounds = 5;
                }
                if (numOfPlayers == 1)
                {
                    numOfRounds = 6;
                }

                BlackJackGame game = new BlackJackGame(numOfRounds, players, deck);
                // Print round and player info
                Console.WriteLine("\t" + "Number of Rounds: " + numOfRounds.ToString() + ", Number of Players: " + numOfPlayers.ToString());
                // Print each player and their balance
                foreach (Player player in players)
                {
                    Console.WriteLine(player.name + ": " + player.Balance);
                }
                numOfPlayers--;
            }
        }



        // Creates a certain number of players
        public void createPlayers(int numOfPlayers, List<Player> playersList)
        {
            while (numOfPlayers > 0)
            {
                Player player = new Player(new BasicStrategy(), "player:" + numOfPlayers.ToString());
                playersList.Add(player);
                numOfPlayers--;
            }
        }
    }
}

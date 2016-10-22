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
            Thread thread1 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread2 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread3 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread4 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread5 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread6 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread7 = new Thread(new ThreadStart(WriteGameResults));
            Thread thread8 = new Thread(new ThreadStart(WriteGameResults));

            thread1.Start();
            thread2.Start();
            thread3.Start();
            thread4.Start();
            thread5.Start();
            thread6.Start();
            thread7.Start();
            thread8.Start();


            Console.Read();

        }

        private static void WriteGameResults()
        {
            Player player1 = new Player(new ZenStrategy(), "Bob");
            Player player2 = new Player(new UshtonStrategy(), "John");

            Deck deck = new Deck(1);

            IList<Player> players = new List<Player>();
          //  players.Add(player1);
            players.Add(player2);

            BlackJackGame game = new BlackJackGame(1000000, players, deck, 50.0);

            for (int i = 0; i < 10000; i++)
            {
                game.PlayRound();
            }

            foreach (Player player in players)
            {
                Console.WriteLine(player.name + ": " + player.Balance + " w/l:6 " + player.GetWinAmountFor(6) + " insurance w/l:6 " + player.GetInsuranceWinAmountFor(6));
            }
        }
    }
}

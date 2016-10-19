using Game;
using Game.cards;
using Game.participants;
using Game.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackJackConsoleApp
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(new BasicStrategy(), "Bob");
            Player player2 = new Player(new BasicStrategy(), "John");
            Deck deck = new Deck(1);

            IList<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            BlackJackGame game = new BlackJackGame(100000, players, deck, 50.0);

            foreach(Player player in players)
            {
                Console.WriteLine(player.name + ": " + player.Balance);
            }
            Console.Read();
        }
    }
}

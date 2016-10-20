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
            List<Card> orderedDeck = new List<Card>();
            for (int i = 0; i < 53; i++)
            {
                    foreach (CardType type in Enum.GetValues(typeof(CardType)))
                    {
                        foreach (Suit suit in Enum.GetValues(typeof(Suit)))
                        {
                            Card card = new Card(suit, type);
                            orderedDeck.Add(card);
                        }
                    }
            }

            Deck deck = new Deck(1);

            IList<Player> players = new List<Player>();
            players.Add(player1);
            players.Add(player2);
            BlackJackGame game = new BlackJackGame(1000000, players, deck, 80.0);

            foreach(Player player in players)
            {
                Console.WriteLine(player.name + ": " + player.Balance);
            }
            Console.Read();
        }
    }
}

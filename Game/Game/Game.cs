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
        public Game(int roundsToPlay, IList<Player> players, Deck deck, double penetrationPercent)
        { 
            Dealer dealer = new Dealer(deck, new DealerStrategy());
            while (roundsToPlay > 0)
            {
                dealer.DoInitialDraw();
                foreach(Player player in players)
                {
                    player.DoInitialDraw();
                }
            }
        }
    }
}

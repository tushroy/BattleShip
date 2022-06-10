using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses
{
    public class BattleShipGame
    {
        private Sea sea;
        private Player player;
        

        public BattleShipGame()
        {
            sea = new Sea();
            player = new Player(sea);
        }

        public string Fire(int row, int col)
        {
            var shootMsg = player.Shoot(row, col);
            return shootMsg;
        }

        public bool isGameEnd()
        {
            return (sea.TotalHitsRequired == player.HitCounter);
        }

        public void ShowGameBoard(bool showShip)
        {
            foreach (var line in Helpers.PrepareBoard(sea.Grid, showShip))
            {
                Console.WriteLine(line);
            }
        }


        
    }
}

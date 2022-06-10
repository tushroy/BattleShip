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
            sea.InitializeSeaWithShips();
            player = new Player(sea.Grid);
        }

        public void Fire(int row, int col)
        {
            player.Shoot(row, col);
        }

        public bool isGameEnd()
        {
            return (sea.TotalHitsRequired == player.HitCounter);
        }

        public void ShowGameBoard(bool showShip)
        {
            //Console.Clear();
            foreach (var line in PrepareBoard(sea.Grid, showShip))
            {
                Console.WriteLine(line);
            }
        }

        private List<string> PrepareBoard(char[,] grid, bool showShip)
        {
            List<string> result = new List<string>();
            int row;
            int column;
            StringBuilder line = new StringBuilder();

            result.Add("  | 1 2 3 4 5 6 7 8 9 0");
            result.Add("--+--------------------");
            for (row = 0; row < 10; row++)
            {
                line.Clear();
                line.Append(Constants.CharArrRows[row] + " | ");
                for (column = 0; column < 10; column++)
                {
                    if (showShip)
                    {
                        line.Append(grid[row, column] + " ");
                    }
                    else
                    {
                        char ch = grid[row, column];
                        if (ch != Constants.Ship && ch != Constants.NoShot)
                        {
                            line.Append(grid[row, column] + " ");
                        }
                        else
                        {
                            line.Append(Constants.NoShot + " ");
                        }
                    }
                }
                result.Add(line.ToString());
            }
            result.Add(string.Empty);
            return result;
        }
    }
}

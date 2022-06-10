using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses
{
    public class Player
    {
        public int HitCounter = 0;

        public int ShotCounter = 0;
        public string Message { get; set; }

        private char[,] Grid;
        public Player(char[,] grid)
        {
            Grid = grid;
        }

        public void Shoot(int row, int col)
        {
            if (Grid[row, col].Equals(Constants.Ship))
            {
                Grid[row, col] = Constants.Hit;
                Message = "Hit!";
                HitCounter += 1;
                ShotCounter += 1;

                foreach (var s in Sea.Ships)
                {
                    var a = (from b in s.Positions
                             where b.row == row && b.col == col
                             select b).FirstOrDefault();

                    if (a != null)
                    {
                        s.Positions.Remove(a); //remove position of the ship

                        if (s.Positions.Count == 0)
                        {
                            Message = string.Format("Congratulations! {0} sank", s.Name);
                        }
                    }
                }
            }
            else if (Grid[row, col].Equals(Constants.NoShot))
            {
                Grid[row, col] = Constants.Miss;
                Message = "Miss!";
                ShotCounter += 1;
            }
            else
            {
                Message = "Already shot this!";
            }

            Console.WriteLine(Message);
        }
    }
}

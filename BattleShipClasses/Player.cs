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

        private char[,] Grid;
        private Sea PlayerSea;
        public Player(Sea playerSea)
        {
            PlayerSea = playerSea;
        }

        public string Shoot(int row, int col)
        {
            string message = "";
            if (PlayerSea.Grid[row, col].Equals(Constants.Ship))
            {
                PlayerSea.Grid[row, col] = Constants.Hit;
                message = "Hit!";
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
                            message = string.Format("Congratulations! {0} sank", s.Name);
                        }
                    }
                }
            }
            else if (Grid[row, col].Equals(Constants.NoShot))
            {
                Grid[row, col] = Constants.Miss;
                message = "Miss!";
                ShotCounter += 1;
            }
            else
            {
                message = "Already shot this!";
            }

            return message;
        }
    }
}

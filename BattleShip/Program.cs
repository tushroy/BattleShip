using BattleShipClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShip
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var battleShipGame = new BattleShipGame();

            battleShipGame.ShowGameBoard(true);
            while (!battleShipGame.isGameEnd())
            {
                int row = -1;
                int col = -1;
                string line = Console.ReadLine();
                if (Helpers.ValidateUserInput(line, out row, out col))
                {
                    string msg = battleShipGame.Fire(row, col);
                    Console.WriteLine(msg);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

                battleShipGame.ShowGameBoard(true);
            }

            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
    }
}

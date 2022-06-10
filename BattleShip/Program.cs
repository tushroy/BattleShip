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

            while (!battleShipGame.isGameEnd())
            {
                battleShipGame.ShowGameBoard(true);

                int row = -1;
                int col = -1;
                string line = Console.ReadLine();
                if (Helpers.ValidateUserInput(line, out row, out col))
                {
                    battleShipGame.Fire(row, col);
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }

            Console.WriteLine("Game Over");
            Console.ReadLine();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses
{
    /// <summary>
    /// Different constants used in program
    /// </summary>
    public static class Constants
    {
        public static char[] CharArrRows = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public static char NoShot = '.';
        public static char Miss = '-';
        public static char Hit = 'X';
        public static char Ship = 'S';
    }
    /// <summary>
    /// for generation of orientation of ship in grid
    /// </summary>
    enum Orientation
    {
        Down,
        Right
    }

    /// <summary>
    /// Different helper functions
    /// </summary>
    public static class Helpers
    {
        /// <summary>
        /// Validate user input if user input is in format of A5
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        public static bool ValidateUserInput(string input, out int row, out int col)
        {
            row = -1;
            col = -1;

            if (input.Length < 1)
            {
                return false;
            }
            else if (input.Length > 3)
            {
                return false;
            }


            if (!ValidateRow(input, out row))
            {
                return false;
            }

            if (!ValidateCol(input, out col))
            {
                return false;
            }

            return true;
        }
        /// <summary>
        /// validate/format user input to column index
        /// </summary>
        /// <param name="input"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private static bool ValidateCol(string input, out int col)
        {
            col = -1;
            string l = input.Substring(1);
            int x;
            if (int.TryParse(l, out x))
            {
                if (x > 10)
                {
                    return false;
                }
                col = x - 1;
            }
            else
            {
                return false;
            }
            return true;
        }
        /// <summary>
        /// validate/format user input to row index
        /// </summary>
        /// <param name="input"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private static bool ValidateRow(string input, out int row)
        {
            char r1 = input[0].ToString().ToUpper()[0];
            int y = Array.IndexOf(Constants.CharArrRows, r1);
            if (y > -1)
            {
                row = y;
                return true;
            }
            else
            {
                row = -1;
                return false;
            }
        }
        /// <summary>
        /// prepare grid for console output
        /// </summary>
        /// <param name="grid"></param>
        /// <param name="showShip"></param>
        /// <returns></returns>
        public static List<string> PrepareBoard(char[,] grid, bool showShip)
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

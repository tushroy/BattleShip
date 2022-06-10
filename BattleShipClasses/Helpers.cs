using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses
{
    public static class Constants
    {
        public static char[] CharArrRows = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J' };
        public static char NoShot = '.';
        public static char Miss = '-';
        public static char Hit = 'X';
        public static char Ship = 'S';
    }
    enum Orientation
    {
        Down,
        Right
    }
    public static class Helpers
    {

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

        private static bool ValidateCol(string input,out int col)
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

        private static bool ValidateRow(string input,out int row)
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
    }
}

using BattleShipClasses.Ships;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses
{
    public class Sea
    {
   
        public char[,] Grid = new char[10, 10]; // the 10x10 grid to place the ships

        public static List<Baseship> Ships;

        public int TotalHitsRequired { get; private set; }

        readonly Random RandomGenerator = null;
        public Sea()
        {
            Ships = new List<Baseship>();
            RandomGenerator = new Random(DateTime.Now.Millisecond);

            // fill empty grid
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    Grid[row, column] = Constants.NoShot;
                }
            }

            InitializeSeaWithShips();
        }

        public void InitializeSeaWithShips()
        {
            // 1 x Battleship (5 squares)
            var battleship1 = new Battleship();
            PlaceShip(battleship1);
            Ships.Add(battleship1);
            TotalHitsRequired += battleship1.TotalSquares;

            // 2 x Destroyers (4 squares)
            var destroyer1 = new Destroyer();
            PlaceShip(destroyer1);
            Ships.Add(destroyer1);
            TotalHitsRequired += destroyer1.TotalSquares;

            var destroyer2 = new Destroyer();
            PlaceShip(destroyer2);
            Ships.Add(destroyer2);
            TotalHitsRequired += destroyer2.TotalSquares;
        }
        /// <summary>
        /// place a ship on grid
        /// </summary>
        /// <param name="ship"></param>
        private void PlaceShip(Baseship ship)
        {
            // generate random orientation for ship
            var r = RandomGenerator.Next();
            Orientation orientation = (Orientation)(r % 2); 

            switch (orientation)
            {
                
                case Orientation.Down: // place ship row wise
                    {
                        //generate initial cell index to start placing the ship
                        var row = RandomGenerator.Next(0, 9 - ship.TotalSquares);
                        var col = RandomGenerator.Next(0, 9);

                        if (ShipNotOverlapped(row, col, ship.TotalSquares, Orientation.Down))
                        {
                            // place ship as per size
                            for (var i = 0; i < ship.TotalSquares; i++)
                            {
                                ship.Positions.Add(new SquarePosition { row = row + i, col = col });
                                SetOnGrid(row + i, col);
                            }
                        }
                        else
                        {
                            //if overlapped try placing the ship again
                            PlaceShip(ship);
                        }
                        break;
                    }
                case Orientation.Right: // place ship column wise
                    {
                        var col = RandomGenerator.Next(0, 9 - ship.TotalSquares);
                        var row = RandomGenerator.Next(0, 9);

                        if (ShipNotOverlapped(row, col, ship.TotalSquares, Orientation.Right))
                        {
                            for (var i = 0; i < ship.TotalSquares; i++)
                            {
                                ship.Positions.Add(new SquarePosition { row = row, col = col + i });
                                SetOnGrid(row, col + i);
                            }
                        }
                        else
                        {
                            PlaceShip(ship);
                        }
                        break;
                    }
            }
        }
        /// <summary>
        /// check for if ship is overlapped with other ship
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="shipSize"></param>
        /// <param name="orientation"></param>
        /// <returns></returns>
        private bool ShipNotOverlapped(int row, int col, int shipSize, Orientation orientation)
        {
            for (var i = 0; i < shipSize; i++)
            {
                switch (orientation)
                {
                    case Orientation.Down:
                        {
                            if (!IsEmptyCell(row + i, col))
                            {
                                return false;
                            }
                            break;
                        }
                    case Orientation.Right:
                        {
                            if (!IsEmptyCell(row, col + i))
                            {
                                return false;
                            }
                            break;
                        }
                }
            }
            return true;
        }
        /// <summary>
        /// mark cell on ship as ship
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        private void SetOnGrid(int row, int col)
        {
            Grid[row, col] = Constants.Ship;
        }
        /// <summary>
        /// check is cell is empty
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool IsEmptyCell(int row, int col)
        {
            if (Grid[row, col].Equals(Constants.Ship))
            {
                return false;
            }
            return true;
        }
    }
}

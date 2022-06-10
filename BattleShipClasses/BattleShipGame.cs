﻿using System;
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

        public List<List<char>> GridDataForWeb()
        {
            var list = new List<List<char>>();
            for (var i = 0; i < sea.Grid.GetLength(1); i++)
            {
                var charList = new List<char>();
                for (var j = 0; j < sea.Grid.GetLength(0); j++)
                {
                    charList.Add(sea.Grid[i, j]);
                }
                list.Add(charList);
            }

            return list;
        }

    }
}

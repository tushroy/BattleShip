using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleShipClasses.Ships
{
    public abstract class Baseship
    {
        public int TotalSquares { get; set; }
        public List<SquarePosition> Positions { get; set; }
        public string Name { get; set; }

        public Baseship()
        {
            Positions = new List<SquarePosition>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
     public class Position // Stores position of tile
    {
        private int _x, _y;
        
        public Position(int x, int y)
        {
            _x = x;
            _y = y;
        }
        public int X { get { return _x ; } }
        public int Y { get { return _y; } }
    }
}

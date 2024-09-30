using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    abstract public class Tile // parent class to make other more specific classes from
    {
        private Position _position;

        public Tile(Position position)
        {
            _position = position;
        }

        
        public int X { get{ return _position.X; } }
        public int Y { get { return _position.Y; } }

        abstract public char Display { get; }

        //method used to update the X and Y positions for the Swaptiles method
        public void SetPosition(int X, int Y)
        {
            _position = new Position(X, Y);
        }
    }
}

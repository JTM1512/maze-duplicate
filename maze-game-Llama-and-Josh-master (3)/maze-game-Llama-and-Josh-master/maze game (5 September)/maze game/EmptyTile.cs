using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class EmptyTile : Tile // sets up tiles that can be walked on by hero or enemies
    {
       public EmptyTile(Position position): base(position)
       { 
          
       }

        public override char Display { get { return '.'; } } // means empty tile
    }
}

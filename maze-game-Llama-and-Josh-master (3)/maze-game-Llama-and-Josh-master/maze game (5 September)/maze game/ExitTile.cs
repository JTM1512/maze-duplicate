using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class ExitTile : Tile
    {
        public ExitTile(Position position) : base(position) 
        { 
            
        }

       public override char Display { get { return '░'; } }

    }
}

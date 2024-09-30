using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class WallTile:Tile
    {
        public WallTile(Position pos):base(pos)
        {
            //WallTile wall = new WallTile(pos);
        }

        public override char Display { get { return '█'; } } //walls for level
    }
}

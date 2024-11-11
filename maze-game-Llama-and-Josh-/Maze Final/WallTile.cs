using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class WallTile : Tile
    {
        public WallTile(Position pos) : base(pos)
        {

        }

        public override char Display { get { return '█'; } } //walls for level
    }
}

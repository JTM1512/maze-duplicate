using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
        abstract public class EnemyTile : CharacterTile
        {
            public EnemyTile(Position position, int HP = 10, int AP = 1) : base(position, HP, AP)
            {

            }

            abstract public bool GetMove(out Tile tile);
            abstract public CharacterTile[] GetTargets();
        }
}

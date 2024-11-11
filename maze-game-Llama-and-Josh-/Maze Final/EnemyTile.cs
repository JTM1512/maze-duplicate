using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    abstract public class EnemyTile : CharacterTile         //Base class for all enemies, inherits from CharacterTile
    {
        public EnemyTile(Level level, Position position, int HP = 10, int AP = 1) : base(position, HP, AP)
        {

        }
        protected Level level;
        abstract public bool GetMove(out Tile tile);
        abstract public CharacterTile[] GetTargets();
    }
}

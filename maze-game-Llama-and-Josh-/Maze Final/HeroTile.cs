using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class HeroTile : CharacterTile
    {
        public HeroTile(Position position, int HP = 40, int AP = 5) : base(position, HP, AP)
        {

        }
        public override char Display
        {
            get
            {
                if (IsDead == true)
                {
                    return 'X';
                }
                else
                {
                    return '▼';
                }

            }
        }

    }
}

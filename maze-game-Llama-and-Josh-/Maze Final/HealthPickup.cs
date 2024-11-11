using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class HealthPickupTile : PickupTile
    {
        public HealthPickupTile(Position position) : base(position)
        {
        }

        public override void ApplyEffect(CharacterTile character)
        {
            character._HP += 10;
            if (character._HP > character._MaxHP)
            {
                character._HP = character._MaxHP;
            }
        }

        public override char Display
        {
            get
            {
                return '+';
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    internal class AttackBuffPickupTile : PickupTile
    {
        public AttackBuffPickupTile(Position location) : base(location)
        {

        }

        public override void ApplyEffect(CharacterTile character)
        {
            int num = 3;
            if (character is HeroTile)
            {
                character.setDoubleDamage(num);
            }
        }

        public override char Display
        {
            get
            {
                return '*';
            }
        }
    }

}

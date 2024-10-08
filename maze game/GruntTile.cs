using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class GruntTile : EnemyTile
    {
        public GruntTile(Position position) : base(position, 10, 1)
        {

        }

        public override char Display
        {
            get
            {
                if (IsDead == true)
                {
                    return 'x';
                }
                else
                {
                    return 'Ϫ';
                }

            }
        }

        public override bool GetMove(out Tile tile)
        {
            tile = null;

            foreach (Tile outTile in exposedVision)
            {
                if (outTile is EmptyTile)
                {
                    Random random = new Random();
                    tile = exposedVision[random.Next(0, 3)];
                    return true;
                }
                else if (outTile is HeroTile)
                {
                    tile = null;
                    return false;
                }

            }
            return false;
        }

        public override CharacterTile[] GetTargets()
        {
            List<CharacterTile> list = new List<CharacterTile>();
            for (int i = 0; i < this.exposedVision.Length; i++)
            {
                if (exposedVision[i] is HeroTile)
                {
                    list.Add((CharacterTile)exposedVision[i]);
                }

            }
            return list.ToArray();

        }
    }
}


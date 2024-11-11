using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class GruntTile : EnemyTile                  // New enemy type that inherits from EnemyTile
    {
        public GruntTile(Level level, Position position) : base(level, position, 10, 1)
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
                    return 'Ϫ';             //How it will look inmaze
                }

            }
        }

        public override bool GetMove(out Tile tile)             //Moves to a empty tile thats not hero tile
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

        public override CharacterTile[] GetTargets()                //If hero is up, down, left or right it will make it a target
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

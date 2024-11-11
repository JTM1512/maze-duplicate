using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class WarlockTile : EnemyTile            // New enemy type that inherits from EnemyTile
    {
        public WarlockTile(Level level, Position position) : base(level, position, 10, 5)
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
                    return 'ᐂ';             //How it will look in maze
                }

            }
        }

        public override bool GetMove(out Tile tile)     //Warlocks cannot move, so tile must always be null to return false
        {
            tile = null;


            return false;
        }


        public override CharacterTile[] GetTargets()                        //Targets is ALL character tiles surrounding Warlock
        {
            int visionX, visionY;
            int directX = 1;
            int directY = 1;
            Tile visionTile;
            List<CharacterTile> list = new List<CharacterTile>();

            for (int i = -1; i < directX; i++)
            {

                for (int j = -1; j < directY; j++)
                {
                    visionX = this.X + i;
                    visionY = this.Y + j;
                    if ((visionX > 0) && (visionX < this.level.Width) && (visionY > 0) && (visionY < this.level.Height))        //Checks to see if it is within parameter of maze
                    {
                        visionTile = this.level.tiles[visionX, visionY];

                        if (!(visionTile is ExitTile) && !(visionTile is EmptyTile) && !(visionTile is PickupTile))             //Checks for a CharacterTile
                        {
                            CharacterTile character = (CharacterTile)visionTile;
                            list.Add(character);
                        }
                    }

                }


            }
            return list.ToArray();

        }
    }
}

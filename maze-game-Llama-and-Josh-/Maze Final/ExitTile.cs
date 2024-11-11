using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class ExitTile : Tile                //Allows to leave maze to go to next stage
    {
        public ExitTile(Position position) : base(position)
        {

        }

        private bool locked = true;
        // Method to unlock the exit
        public void Unlock()
        {
            locked = false;
        }

        // Method to lock the exit
        public void Lock()
        {
            locked = true;
        }

        //Method to check if tile is locked
        public bool isLocked()
        { return locked; }

        public override char Display
        {
            get
            {
                if (locked == false)
                {
                    return '░';
                }
                else
                {
                    return '▓';
                }

            }
        }
    }
}

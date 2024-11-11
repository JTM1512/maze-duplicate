using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace Maze_Final
{
    [Serializable]
    public class State
    {
        public int Level { get; set; }
        public int numLevels = 10;
        public Level CurrentLevel { get; set; }
    }
}

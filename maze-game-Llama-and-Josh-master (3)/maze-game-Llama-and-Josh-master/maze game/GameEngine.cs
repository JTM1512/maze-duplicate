using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    internal class GameEngine
    {
        private Level currentLevel;
        private int _numberLevels;
        Random random;
        private int MIN_SIZE = 10;
        private int MAX_SIZE = 20;

        public GameEngine(int numberLevels) //sets up the dimensions of maze level and number of levels
        {
            _numberLevels = numberLevels;
            random = new Random();
            int width = random.Next(MIN_SIZE, MAX_SIZE);
            int height = random.Next(MIN_SIZE,MAX_SIZE);
            currentLevel = new Level(width,height);
        }

        public override string ToString() //displays our level
        {
            return currentLevel.ToString();
        }
    }
}

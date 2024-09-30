using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace maze_game
{
    public enum GameState
    {
        InProgress, Complete, GameOver
    }
    internal class GameEngine
    {
        private Level currentLevel;
        private int _numberLevels = 1;
        Random random;
        private const int MIN_SIZE = 10;
        private const int MAX_SIZE = 20;
        public GameState currentGameState = GameState.InProgress;


        public void NextLevel()
        {
            _numberLevels++;
            
            HeroTile currentHero = currentLevel.Hero;
            
            random = new Random();
            int width = random.Next(MIN_SIZE, MAX_SIZE);
            int height = random.Next(MIN_SIZE, MAX_SIZE);

            currentLevel = new Level(width, height, currentHero);
        }

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
            if (currentGameState == GameState.Complete)
            {   //displays message if the game is finished
                return "The game has been completed";
            }
            else if (currentGameState == GameState.InProgress)
            {   //displays the new level if the game is in progress
                return currentLevel.ToString();
            }
            return currentLevel.ToString();
        }

        private bool MoveHero(Level.Direction movement)
        {   
            HeroTile hero = currentLevel.Hero;
                       
            hero.UpdateVision(currentLevel);

            int number = (int)movement;
            Tile targetTile = hero.exposedVision[number];

            if (targetTile is ExitTile)
            {   
                //if the level count has hit the max level
                if (_numberLevels == 10)
                {
                    currentGameState = GameState.Complete;
                    return false;
                }
                else 
                {
                    //new level is created if the current level isn't max
                    NextLevel();
                    return true;
                }

            }

            if (targetTile is EmptyTile)
            {
                currentLevel.SwapTiles(hero, targetTile);
                hero.UpdateVision(currentLevel);
                return true;                
            }
            else
                return false;
        }

       public void TriggerMovement(Level.Direction movement)
        {
            MoveHero(movement);
        }
    }
}


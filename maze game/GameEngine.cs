using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection.Emit;
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
        public int count = 0;
        public int currentLevelNumber = 1;
        public int numEnemies = 1;
        public int numPickups = 1;
        public HeroTile _herotile;
        private List<EnemyTile> enemyList;
        private List<PickupTile> pickupList;


        public void NextLevel(int currentLevelNumber)
        {
            currentLevelNumber++;
            numEnemies++;

            HeroTile currentHero = currentLevel.Hero;

            Random random1 = new Random();
            int width = random1.Next(MIN_SIZE, MAX_SIZE);
            int height = random1.Next(MIN_SIZE, MAX_SIZE);

            currentLevelNumber = currentLevelNumber + 1;
            currentLevel = new Level(width, height, numEnemies, numPickups, currentHero);
        }

        public GameEngine(int numberLevels) //sets up the dimensions of maze level and number of levels
        {
            _numberLevels = numberLevels;
            Random random2 = new Random();
            int width = random2.Next(MIN_SIZE, MAX_SIZE);
            int height = random2.Next(MIN_SIZE, MAX_SIZE);

            currentLevel = new Level(width, height, numEnemies, numPickups);
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
            else if (currentGameState == GameState.GameOver)
            {   //displays the game over message
                return "YOU DIED";
            }
            return currentLevel.ToString();
        }

        private bool MoveHero(Level.Direction movement)
        {
            HeroTile hero = currentLevel.Hero;

            hero.UpdateVision(currentLevel);

            int number = (int)movement;
            Tile targetTile = hero.exposedVision[number];

            if (targetTile == null) return false;

            if (targetTile is HealthPickupTile health) //checks if hero is moving to a health pickup and creates a variable if so
            {
                //healing effect is applied
                health.ApplyEffect(currentLevel.Hero);
                
                currentLevel.SwapTiles(hero,health);

                //changes health pickup to an empty tile
                Position newPos = new Position(targetTile.X, targetTile.Y);
                EmptyTile newEmpty = new EmptyTile(newPos);
                currentLevel.tiles[health.X, health.Y] = newEmpty;

                hero.UpdateVision(currentLevel);

                return true;
            }

            if (targetTile is ExitTile)
            {
                //if the level count has hit the max level
                if (currentLevelNumber == 10)
                {
                    currentGameState = GameState.Complete;
                    return false;
                }
                else
                {
                    //new level is created if the current level isn't max
                    NextLevel(currentLevelNumber);
                    return true;
                }

            }

            if (targetTile is WallTile)
            {
                return false;
            }

            if (targetTile is EmptyTile)
            {
                currentLevel.SwapTiles(hero, targetTile);
                currentLevel.UpdateVision(currentLevel);
                return true;
            }
            else
                return false;
        }

        public void TriggerMovement(Level.Direction movement)
        {
            //Guard clause
            if (currentGameState == GameState.GameOver)
                return;

            bool move = MoveHero(movement);

            if (move == true)
            {   
                count++;
                if (count == 2)
                {
                    MoveEnemies();
                    count = 0;
                }
            }

        }

        private void MoveEnemies()
        {
            Tile thisTile;

            Level level = currentLevel;


            EnemyTile[] enemy = currentLevel.enemy;
            for (int i = 0; i < enemy.Length; i++)
            {
                if (enemy[i].IsDead == false)
                {
                    bool answer2 = enemy[i].GetMove(out thisTile);
                    if (answer2 == true)
                    {
                        Random random2 = new Random();
                        int randomIndex = random2.Next(0, 4);
                        Tile targetTile = enemy[i].exposedVision[randomIndex];
                        while ((targetTile is WallTile) || (targetTile is HealthPickupTile))
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                targetTile = enemy[i].exposedVision[j];
                            }

                        }

                        currentLevel.SwapTiles(enemy[i], targetTile);

                        level.UpdateVision(currentLevel);
                    }
                }
            }
        }
        private bool HeroAttack(Level.Direction direction)
        {
            bool success = false;
            HeroTile hero = currentLevel.Hero;

            hero.UpdateVision(currentLevel);

            int number = (int)direction;
            Tile targetTile = hero.exposedVision[number];

            if (targetTile == null) return false;

            if (targetTile is EnemyTile enemy)
            {
                hero.Attack(enemy);
                success = true;
            }

            return success;
        }

        public void TriggerAttack(Level.Direction direction)
        {
            //Guard clause
            if (currentGameState == GameState.GameOver)
                return;

            bool Attack = HeroAttack(direction);

            if (Attack == true)
            {
                EnemiesAttack();
                Attack = false;

                if (_herotile.IsDead == true)
                {
                    currentGameState = GameState.GameOver;
                }

            }
        }

        private void EnemiesAttack()
        {
            EnemyTile[] enemies = currentLevel.enemy;
            for (int i = 0; i < enemies.Length; i++)
            {
                GruntTile grunt = (GruntTile)enemies[i];
                if (enemies[i].IsDead == false)
                {
                    var targets = grunt.GetTargets();

                    foreach (var target in targets)
                    {
                        if (target == null) continue;

                        if (target is HeroTile hero)
                        {
                            grunt.Attack(hero);
                        }
                    }
                }
            }
            
        }

        public string HeroStats
        {
            get
            {
                return "Current HP: "+Convert.ToString(currentLevel.Hero._HP)+"/40";
            }
        }
    }

}


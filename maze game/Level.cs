using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public class Level // creates entire level
    {
        private Tile[,] array;
        private int _width, _height;
        private Random _random;
        private HeroTile _hero;
        private ExitTile _exit;
        private EnemyTile[] _enemy;
        private PickupTile[] _pickup;
        //int numEnemies;

        public Level(int width, int height, int numEnemies, int numPickups, HeroTile hero = null)
        {
            _width = width;
            _height = height;
            array = new Tile[width, height];
            _random = new Random();
            _enemy = new EnemyTile[numEnemies];
            _pickup = new PickupTile[numPickups];

            InitialiseTiles(array);

            //Creates new enemies in a random empty position
            for (int i = 0; i < numEnemies; i++)
            {
                TileType enemytile = TileType.Enemy;
                Position location = GetRandomEmptyPosition();
                enemy[i] = new GruntTile(location);
                array[location.X, location.Y] = CreateTile(enemytile, location);
            }

            //Creates new health pickups in a random empty position
            for (int i = 0; i < numPickups; i++)
            {
                TileType pickuptile = TileType.Pickup;
                Position loc = GetRandomEmptyPosition();
                array[loc.X, loc.Y] = CreateTile(pickuptile, loc);
            }

            Position randomPos = GetRandomEmptyPosition();
            Position exitPos = GetRandomEmptyPosition();

            //creates hero tile in a random empty position
            if (hero == null)
            {
                _hero = new HeroTile(randomPos, 40, 5);
                CreateTile(TileType.Hero, randomPos);
                array[randomPos.X, randomPos.Y] = _hero;
            }
            else
            {
                _hero = hero;
                array[_hero.X, _hero.Y] = _hero;

            }

            //exit tile creation
            _exit = new ExitTile(exitPos);
            CreateTile(TileType.Exit, exitPos);
        }
        public Tile[,] tiles { get { return array; } }
        public int Width { get { return _width; } }
        public int Height { get { return _height; } }
        public HeroTile Hero { get { return _hero; } }
        public ExitTile Exit { get { return _exit; } }
        public EnemyTile[] enemy { get { return _enemy; } }
        private PickupTile[] Pickup { get { return _pickup; } }

        public enum TileType
        {
            Empty, Wall, Hero, Exit, Enemy, Pickup
        }

        private Tile CreateTile(TileType type, Position position) //dictates tiles based on enum value
        {
            //char sign;
            Tile tile = null;
            switch (type)
            {
                case TileType.Empty:
                    tile = new EmptyTile(position);
                    break;

                case TileType.Wall:
                    tile = new WallTile(position);
                    break;

                case TileType.Hero:
                    tile = new HeroTile(position, 40, 5);
                    break;

                case TileType.Exit:
                    tile = new ExitTile(position);
                    break;

                case TileType.Enemy:
                    tile = new GruntTile(position);
                    break;

                case TileType.Pickup:
                    tile = new HealthPickupTile(position);
                    break;

            }
            array[position.X, position.Y] = tile;
            return tile;
        }

        public void InitialiseTiles(Tile[,] array) // applies enums to tiles
        {
            Position position;
            TileType type;
            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    /*array[i, j] = CreateTile(type, z);*/
                    position = new Position(i, j);
                    if (i == 0 || j == 0 || i == _width - 1 || j == _height - 1)
                    {
                        type = TileType.Wall;
                    }
                    //else if(i == _width -1 || j == _height - 1)
                    //{
                    //type = TileType.Wall;
                    //}
                    else
                    {
                        type = TileType.Empty;
                    }
                    array[position.X, position.Y] = CreateTile(type, position);


                }
            }
        }

        public override string ToString() //level display
        {
            string form = "";
            for (int i = 0; i < _width; i++)
            {

                for (int j = 0; j < _height; j++)
                {
                    form = form + array[i, j].Display;
                }
                form = form + "\n";
            }

            return form;
        }

        private Position GetRandomEmptyPosition()
        {
            List<Position> emptyTiles = new List<Position>();//list of empty tiles 

            for (int i = 0; i < _width; i++)
            {
                for (int j = 0; j < _height; j++)
                {
                    if (array[i, j] is EmptyTile)
                    {
                        emptyTiles.Add(new Position(i, j));//empty tile gets added
                    }
                }
            }

            int randomIndex = _random.Next(emptyTiles.Count);
            return emptyTiles[randomIndex];//random tile in list is selected and returned
        }

        public void SwapTiles(Tile tile1, Tile tile2)
        {
            int x1 = tile1.X;
            int y1 = tile1.Y;

            int x2 = tile2.X;
            int y2 = tile2.Y;

            array[x1, y1] = tile2;
            array[x2, y2] = tile1;

            tile1.SetPosition(x2, y2);
            tile2.SetPosition(x1, y1);
        }

        public enum Direction : int
        {
            Up = 0,
            Right = 1,
            Down = 2,
            Left = 3,
            None = 4

        }

        public void UpdateVision(Level level)
        {
            foreach (EnemyTile enemy in _enemy)
            {
                if (enemy != null)
                { enemy.UpdateVision(level); }
            }

            if (Hero != null)
            { Hero.UpdateVision(level); }
            
        }

    }

}



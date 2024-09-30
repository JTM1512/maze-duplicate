using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    internal class Level // creates entire level
    {
        private Tile[,] array;
        private int _width, _height;

        public Level(int width, int height) 
        { 
            _width = width;
            _height = height;
            array = new Tile[width, height];
            InitialiseTiles(array);
        }

        public int Width { get { return _width; } }
        public int Height { get { return _height; } }

        public enum TileType
        {
            Empty, Wall, Hero
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
                    
            }
            array[position.X, position.Y] = tile;
            return tile;
        }

        public void InitialiseTiles(Tile[,] array) // applies enums to tiles
        {
            Position position;
            TileType type;
            for (int i = 0; i < _width ; i++)
            {
                for(int j=0; j < _height ; j++)
                {
                    /*array[i, j] = CreateTile(type, z);*/
                    position = new Position(i, j);
                    if (i == 0 || j == 0 || i == _width - 1  || j == _height - 1 )
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

        public override string ToString() //level display YEs

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


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
    public class TyrantTile : EnemyTile         // New enemy type that inherits from EnemyTile
    {
        public TyrantTile(Level level, Position position) : base(level, position, 15, 5)
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
                    return '§';         //How it will look in maze
                }

            }
        }

        public override bool GetMove(out Tile tile)             //Must move towards position of hero
        {
            bool answer = false;
            int pointerX = level.Hero.Position.X - this.Position.X;                 //Heros' position minus enemys' position
            int pointerY = level.Hero.Position.Y - this.Position.Y;

            tile = null;


            if ((Math.Sign(pointerX) == 1) && (Math.Sign(pointerY) == 1))           //If the difference is positive and positive then the hero is higher and more to the right of the enemy
            {
                tile = level.tiles[this.X + 1, this.Y + 1];
            }
            if ((Math.Sign(pointerX) == 1) && (Math.Sign(pointerY) == -1))          //If the difference is positive and negative then the hero is higher and more to the left of the enemy
            {
                tile = level.tiles[this.X + 1, this.Y - 1];
            }
            if ((Math.Sign(pointerX) == -1) && (Math.Sign(pointerY) == 1))          //If the difference is negative and positive then the hero is lower and more to the right of the enemy
            {
                tile = level.tiles[this.X - 1, this.Y + 1];
            }
            if ((Math.Sign(pointerX) == -1) && (Math.Sign(pointerY) == -1))         //If the difference is negative and negative then the hero is lower and more to the left of the enemy
            {
                tile = level.tiles[this.X - 1, this.Y - 1];
            }
            if ((Math.Sign(pointerX) == 0) && (Math.Sign(pointerY) == 1))           //If the difference is 0 and positve then the hero is in the same row and more to the right of the enemy
            {
                tile = level.tiles[this.X, this.Y + 1];
            }
            if ((Math.Sign(pointerX) == 0) && (Math.Sign(pointerY) == -1))         //If the difference is 0 and negative then the hero is in the same row and more to the left of the enemy
            {
                tile = level.tiles[this.X, this.Y - 1];
            }
            if ((Math.Sign(pointerX) == 1) && (Math.Sign(pointerY) == 0))           //If the difference is positive and 0 then the hero is higher and in the same column of the enemy
            {
                tile = level.tiles[this.X + 1, this.Y];
            }
            if ((Math.Sign(pointerX) == -1) && (Math.Sign(pointerY) == 0))          //If the difference is negative and 0 then the hero is lowher and in the same column of the enemy
            {
                tile = level.tiles[this.X - 1, this.Y];
            }

            if (tile is HeroTile)
            {
                answer = false;
            }
            else if (tile is EmptyTile)
            {
                answer = true;
            }
            return answer;

        }

        public override CharacterTile[] GetTargets()                //Targets is ALL character tiles in full current row and column
        {

            List<CharacterTile> list = new List<CharacterTile>();

            int j = 1;
            while (!(level.tiles[this.X - j, this.Y] is WallTile))              //Checks row from characters position backwards to the wall
            {
                if (level.tiles[this.X - j, this.Y] is CharacterTile)
                {
                    CharacterTile character = (CharacterTile)level.tiles[this.X - j, this.Y];
                    list.Add(character);

                }
                j++;
            }

            int i = 1;
            while (!(level.tiles[this.X + i, this.Y] is WallTile))              //Checks row from characters position forwards to the wall
            {
                if (level.tiles[this.X + i, this.Y] is CharacterTile)
                {
                    CharacterTile character = (CharacterTile)level.tiles[this.X + i, this.Y];
                    list.Add(character);

                }
                i++;
            }

            int k = 1;
            while (!(level.tiles[this.X, this.Y - k] is WallTile))             //Checks column from characters position upwards to the wall
            {
                if (level.tiles[this.X, this.Y - k] is CharacterTile)
                {
                    CharacterTile character = (CharacterTile)level.tiles[this.X, this.Y - k];
                    list.Add(character);

                }
                k++;
            }

            int L = 1;
            while (!(level.tiles[this.X, this.Y + L] is WallTile))              //Checks column from characters position downwards to the wall
            {
                if (level.tiles[this.X, this.Y + L] is CharacterTile)
                {
                    CharacterTile character = (CharacterTile)level.tiles[this.X, this.Y + L];
                    list.Add(character);

                }
                L++;
            }

            return list.ToArray();

        }
    }
}

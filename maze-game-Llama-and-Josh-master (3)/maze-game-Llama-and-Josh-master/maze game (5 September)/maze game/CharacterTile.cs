using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    abstract public class CharacterTile : Tile
    {   
        //attack and HP
        public int _HP = 40;
        public int _AP = 5;
        public int _MaxHP;
        //array storing character vision
        private Tile[] vision; 

        public CharacterTile(Position position, int HP, int AP) : base(position)
        {
            _AP = AP;
            _HP = HP;
            _MaxHP = HP;
            vision = new Tile[4];
        }

        public Tile[] exposedVision { get { return vision; } }


        public void UpdateVision(Level level)
        {
            vision[0] = level.tiles[X - 1, Y];//up
            vision[1] = level.tiles[X, Y + 1];//right
            vision[2] = level.tiles[X + 1, Y];//down
            vision[3] = level.tiles[X, Y - 1];//left
        }


        public Tile[] GetVision()
        {
            return vision;
        }

        public int TakeDamage(int damage)
        {
            _HP -= damage;
            if (_HP>0)
            {
                return _HP;
            }
            else
            {
                //Ensures HP doesn't fall below 0
                return 0;
            }
            
        }

        public void Attack(CharacterTile targetCharacter)
        {
            targetCharacter.TakeDamage(_AP);
        }

        public bool IsDead 
        { 
            get 
            {
                if (_HP > 0)
                    return false;
                else
                    return true;          
            } 
        }

        public Position Position { get; set; }
    }
}


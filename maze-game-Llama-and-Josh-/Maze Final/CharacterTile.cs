using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maze_Final
{
    [Serializable]
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
            vision[0] = level.tiles[X, Y - 1];//up
            vision[1] = level.tiles[X + 1, Y];//right
            vision[2] = level.tiles[X, Y + 1];//down
            vision[3] = level.tiles[X - 1, Y];//left
        }

        public Tile[] GetVision()
        {
            return vision;
        }

        public int TakeDamage(int damage)
        {
            _HP -= damage;
            if (_HP > 0)
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
            if (doubleDamageCount > 0)
            {
                doubleDamageCount--;
            }
            else if (doubleDamageCount == 0)
            {
                _AP = 5;
            }

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

        public void Heal(int restore)
        {
            if (_HP + restore <= _MaxHP)
            {
                _HP = +restore;
            }
            else
            {
                _HP = _MaxHP;
            }

        }

        private int doubleDamageCount;          //Represents how many turns the effect will apply

        public void setDoubleDamage(int num)        //Sets how many turns
        {
            doubleDamageCount = doubleDamageCount + num;

            if (doubleDamageCount <= 0)
            {
                doubleDamageCount = 0;
            }

            int originalAP = _AP;

            if (doubleDamageCount > 0)                              //Checking if the buff was picked up
            {
                _AP = _AP * 2;
            }
        }
    }
}

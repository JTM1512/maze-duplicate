﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace maze_game
{
    public abstract class PickupTile : Tile
    {
        public PickupTile(Position location) : base(location)
        {

        }

        abstract public void ApplyEffect(CharacterTile character);

    }
}

﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Levels {
    internal interface ILevel {
        public int[,] TileIds
        {
            get;
        }
        public List<Vector2> SnowmanCoords
        {
            get;
        }
        public List<Vector2> GiftCoords
        {
            get;
        }
    }
}

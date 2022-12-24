﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Levels {
    internal class Level1 : ILevel {
        private int[,] tileIds = {
            { 15, 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 9, 0, 8, 0, 14 },
            { 15,16, 0, 0, 9, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 3, 24, 25, 25, 25, 26, 0, 14 },
            { 15,20, 21, 12, 12, 12, 13, 27, 27, 27, 21, 13, 0, 0, 0, 0, 0, 11, 13, 0, 0, 0, 0, 0, 0, 14 },
            { 15,15, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 21, 12, 12, 12, 17, 18, 16, 0, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 19, 19, 19, 19, 19, 19, 23, 0, 0, 0, 5, 10, 3, 14 },
            { 15,16, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 12, 12, 12, 18 },
            { 15,16, 24, 25, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 19, 19, 19, 15 },
            { 15,16, 0, 0, 0, 0, 0, 13, 2, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 20, 13, 0, 0, 0, 11, 17, 27, 27, 27, 21, 13, 2, 0, 0, 0, 0, 0, 14 },
            { 15,16, 0, 0, 0, 0, 0, 15, 20, 13, 10, 8, 14, 15, 28, 28, 28, 15, 20, 21, 13, 0, 8, 7, 0, 14 },
            { 15,20, 21, 12, 12, 17, 27, 15, 15, 20, 12, 17, 18, 15, 28, 28, 28, 15, 15, 15, 20, 12, 12, 12, 17, 18 } };
        public int[,] TileIds => tileIds;

        public List<Vector2> SnowmanCoords => new List<Vector2>()
        {
            new Vector2(3000, 1500),
            new Vector2(1900,700),

        };

        public List<Vector2> GiftCoords => new List<Vector2>()
        {
            new Vector2(683,473),
            new Vector2(1329,250),
            new Vector2(1984,600),
            new Vector2(2510,390),
            new Vector2(3078,750),
            new Vector2(2504,699),
            new Vector2(3068,1365),
            new Vector2(2240,1265),
            new Vector2(1408,1490),
            new Vector2(1259,960),
            new Vector2(328,1000),

        };
    }
}

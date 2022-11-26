using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class World {
        public static List<IGameObject> Tiles = new List<IGameObject>();
        private Texture2D texture;
        private int[,] tileIds = {
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 2, 3, 11, 11, 11,11,11,11,11,16,9,9,9, 3,11,11,11,11,11,11,11,11,11,16,17 }
        };


        public World(Texture2D texture) {
            this.texture = texture;
            for (int y = 0; y < 14; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    if (tileIds[y, x] != 0)
                        Tiles.Add(new GameTile(texture, tileIds[y, x], x, y));
                }
            }
        }
        public void Draw(SpriteBatch spritebatch) {
            foreach (var tile in Tiles)
            {
                tile.Draw(spritebatch);
            }
        }

    }
}

using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movables;
using GameProject.Content.Game.Movables.Crate;
using GameProject.Content.Game.Movables.Santa;
using GameProject.Content.Game.Movables.Snowman;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class World : IScreen {
        private const int tileWidth = 128;
        private const int tileHeight = 128;
        public static List<GameObject> Tiles;
        private Texture2D tilesTexture;
        private Texture2D santaTexture;
        private Texture2D snowManSledTexture;
        private Texture2D snowManTexture;
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

        private Santa santa;
        private SnowmanSled snowmanSled;
        private Progressbar progressbar;
        private GameCounter counter;
        private List<Vector2> snowmanCoords = new List<Vector2>()
        {
            new Vector2(3000, 1300),
            new Vector2(1900,600),

        };

        private List<Vector2> giftCoords = new List<Vector2>()
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
        private int catchedGifts = 0;


        public World(ContentManager content) {
            Tiles = new List<GameObject>();
            this.santaTexture = content.Load<Texture2D>("./images/santaClaus_small");
            this.tilesTexture = content.Load<Texture2D>("./images/tileset");
            this.snowManTexture = content.Load<Texture2D>("./images/snowman_small");
            GameObjectFactory.Init(content.Load<Texture2D>("./images/crate"), content.Load<Texture2D>("./images/cadeau_2"));
            this.snowManSledTexture = content.Load<Texture2D>("./images/snowman_sled3");
            for (int y = 0; y < tileIds.GetLength(0); y++)
            {
                for (int x = 0; x < tileIds.GetLength(1); x++)
                {
                    if (tileIds[y, x] != 0)
                        Tiles.Add(new GameTile(tilesTexture,tileIds[y, x], x * tileWidth, y * tileHeight));
                }
            }
            for (int i = 0; i < giftCoords.Count; i++)
            {
                GameObject cadeau = GameObjectFactory.CreateGameObject("cadeau", (int)giftCoords[i].X, (int)giftCoords[i].Y);
                Tiles.Add(cadeau);
            }
            this.santa = new Santa(santaTexture, 5, 140, 400);
            Tiles.Add(santa);
            this.snowmanSled = new SnowmanSled(snowManSledTexture, 128, 40, santa, 4);
            Tiles.Add(snowmanSled);
            foreach (var snowman in snowmanCoords)
            {
                Tiles.Add(new Snowman(snowManTexture, 3, (int)snowman.X, (int)snowman.Y));
            }
            progressbar = new Progressbar(content.Load<Texture2D>("./images/progressbar"), content.Load<Texture2D>("./images/progress"));
            counter = new GameCounter(content.Load<SpriteFont>("font/santa_christmas"));
        }

        public void Draw(SpriteBatch spritebatch) {
            foreach (var tile in Tiles)
            {
                tile.Draw(spritebatch);
            }
            progressbar.Draw(spritebatch);
            counter.Draw(spritebatch);
        }
        public GameState Update(GameTime gameTime) {
            List<GameObject> toRemove = new List<GameObject>();
            for (int i = 0; i < Tiles.Count; i++)
            {
                if (Tiles[i] is MovableGameObject)
                    (Tiles[i] as MovableGameObject).Update(gameTime);
                if (Tiles[i].ToBeRemoved)
                    toRemove.Add(Tiles[i]);
            }
            foreach (var tile in toRemove)
            {
                Tiles.Remove(tile);
                //if santa is on the to remove list, santa is dead :(
                if (tile is Santa)
                    return GameState.StartScreen;
                else if (tile is Gift)
                    catchedGifts++;

            }
            progressbar.Update(giftCoords.Count, catchedGifts, gameTime);
            counter.Update(gameTime);
            return GameState.Level1;
        }
    }
}

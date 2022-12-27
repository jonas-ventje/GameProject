using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Levels;
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

namespace GameProject.Content.Game.Screens
{
    internal class World : IScreen
    {
        private ContentManager content;
        private const int tileWidth = 128;
        private const int tileHeight = 128;
        public static List<GameObject> Tiles;
        private Texture2D tilesTexture;
        private Texture2D santaTexture;
        private Texture2D snowManSledTexture;
        private Texture2D snowManTexture;

        private Santa santa;
        private SnowmanSled snowmanSled;
        private Progressbar progressbar;
        private GameCounter counter;
        private SantaSled santaSled;

        private int catchedGifts = 0;
        private int giftAmount = 0;


        public World(ContentManager content, ILevel level)
        {
            this.content = content;
            Tiles = new List<GameObject>();
            //setup textures and classes
            santaTexture = content.Load<Texture2D>("./images/santaClaus_small");
            tilesTexture = content.Load<Texture2D>("./images/tileset");
            snowManTexture = content.Load<Texture2D>("./images/snowman_small");
            snowManSledTexture = content.Load<Texture2D>("./images/snowman_sled3");
            GameObjectFactory.Init(content.Load<Texture2D>("./images/crate"), content.Load<Texture2D>("./images/cadeau_2"));
            santa = new Santa(santaTexture, 5, 240, 400);
            snowmanSled = new SnowmanSled(snowManSledTexture, 128, 40, santa, 4, santa);
            progressbar = new Progressbar(content.Load<Texture2D>("./images/progressbar"), content.Load<Texture2D>("./images/progress"));
            counter = new GameCounter(content.Load<SpriteFont>("font/santa_christmas"), santa);
            santaSled = new SantaSled(content.Load<Texture2D>("./images/santa_sled"), (int)level.santaSledCoords.X, (int)level.santaSledCoords.Y, new Frame(new Rectangle(0,0,230,229)));




            //add tiles to static list
            foreach (var layer in level.Layers)
            {
                for (int y = 0; y < layer.GetLength(0); y++)
                {
                    for (int x = 0; x < layer.GetLength(1); x++)
                    {
                        if (layer[y, x] != 0)
                            Tiles.Add(new GameTile(content, layer[y, x], x * tileWidth, y * tileHeight));
                    }
                }
            }


            //add gifts to static list
            giftAmount = level.GiftCoords.Count;
            for (int i = 0; i < level.GiftCoords.Count; i++)
            {
                GameObject cadeau = GameObjectFactory.CreateGameObject("cadeau", (int)level.GiftCoords[i].X, (int)level.GiftCoords[i].Y);
                Tiles.Add(cadeau);
            }

            //add snowmans to static list
            foreach (var snowman in level.SnowmanCoords)
            {
                Tiles.Add(new Snowman(snowManTexture, 3, (int)snowman.X, (int)snowman.Y, santa, santa));
            }

            //add individual componentes to static list
            Tiles.Add(santa);
            Tiles.Add(snowmanSled);
            Tiles.Add(santaSled);
        }

        public void Draw(SpriteBatch spritebatch)
        {
            foreach (var tile in Tiles)
            {
                tile.Draw(spritebatch);
            }
            progressbar.Draw(spritebatch);
            counter.Draw(spritebatch);
        }
        public IScreen Update(GameTime gameTime)
        {
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
                    return new GameOverScreen(content);
                else if (tile is Gift)
                    catchedGifts++;

            }
            progressbar.Update(giftAmount, catchedGifts, gameTime);
            counter.Update(gameTime);
            return this;
        }
    }
}

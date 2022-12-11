using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movables;
using GameProject.Content.Game.Movables.Crate;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game
{
    internal class World:IScreen {
        private const int tileWidth = 128;
        private const int tileHeight = 128;
        public static List<IGameObject> Tiles = new List<IGameObject>();
        private Texture2D tilesTexture;
        private Texture2D santaTexture;
        private Texture2D snowManSledTexture;
        private int[,] tileIds = {
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,19,0,0,0,0,0,0,0,19,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,11,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 6, 8, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,6,8,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 15, 0, 0, 0, 0,0,0,0,11,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,13 },
            { 2, 3, 11, 11, 11,11,11,11,11,16,9,9,9, 3,11,11,11,11,11,11,11,11,11,16,17 }
        };

        private Santa santa;
        private SnowmanSled snowmanSled;

        private List<Vector2> cadeauCoords = new List<Vector2>()
        {
            new Vector2(150,800),
            new Vector2(500,400),
            new Vector2(600,1500)
        };


        public World(ContentManager content) {
            this. santaTexture = content.Load<Texture2D>("./images/santaClaus_small");
            this.tilesTexture = content.Load<Texture2D>("./images/tileset");
            GameObjectFactory.Init(content.Load<Texture2D>("./images/crate"), content.Load<Texture2D>("./images/cadeau"));
            this.snowManSledTexture = content.Load<Texture2D>("./images/snowman_sled3");
            for (int y = 0; y < 14; y++)
            {
                for (int x = 0; x < 25; x++)
                {
                    if (tileIds[y, x] != 0)
                        Tiles.Add(LoadGameObject(tileIds[y, x], x*tileWidth, y*tileHeight));
                }
            }
            for (int i = 0; i < cadeauCoords.Count; i++)
            {
                IGameObject cadeau = GameObjectFactory.CreateGameObject("cadeau", (int)cadeauCoords[i].X, (int)cadeauCoords[i].Y);
                Tiles.Add(cadeau);
            }
            this.santa = new Santa(santaTexture, 5, new Vector2(0,500));
            Tiles.Add(santa);
            this.snowmanSled = new SnowmanSled(snowManSledTexture, new Vector2(128, 40), santa, 2);
            Tiles.Add(snowmanSled);
        }

        public void Draw(SpriteBatch spritebatch) {
            foreach (var tile in Tiles)
            {
                tile.Draw(spritebatch);
            }
        }
        public GameState Update(GameTime gameTime) {
            List<IGameObject> toRemove = new List<IGameObject>();
            for(int i = 0; i< Tiles.Count; i++)
            {
                if (Tiles[i] is IMovableGameObject)
                    (Tiles[i] as IMovableGameObject).Update(gameTime);
                if (Tiles[i].ToBeRemoved)
                    toRemove.Add(Tiles[i]);
            }
            foreach (var tile in toRemove)
                Tiles.Remove(tile);
            return GameState.Level1;
        }
        private IGameObject LoadGameObject(int id, int x, int y) {
            switch (id)
            {
                case 1:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 0, 128, 128)), x, y);
                case 2:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 0, 128, 128)), x, y);
                case 3:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 0, 128, 128)), x, y);
                case 4:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 0, 128, 128)), x, y);
                case 5:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 0, 128, 128)), x, y);
                case 6:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 0, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 7:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 8:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 9:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 29, 128, 128)), x, y);
                case 10:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 128, 128, 128)), x, y);
                case 11:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 128, 128, 128)), x, y);
                case 12:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 128, 128, 128)), x, y);
                case 13:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 256, 128, 128)), x, y);
                case 14:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 256, 128, 128)), x, y);
                case 15:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 256, 128, 128)), x, y);
                case 16:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 256, 128, 128)), x, y);
                case 17:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 256, 128, 128)), x, y);
                case 18:
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 256, 128, 128)), x, y);
                case 19:
                    return GameObjectFactory.CreateGameObject("crate", x, y);

                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
    }
}

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
        public static List<IGameObject> Tiles;
        private Texture2D tilesTexture;
        private Texture2D santaTexture;
        private Texture2D snowManSledTexture;
        private int[,] tileIds = {
            { 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 3, 9, 0, 8, 0, 14 },
            { 16, 0, 0, 9, 0, 0, 0, 0, 0, 0, 2, 0, 0, 0, 0, 0, 6, 0, 24, 25, 25, 25, 26, 0, 14 },
            { 20, 21, 12, 12, 12, 13, 27, 27, 27, 21, 13, 0, 0, 0, 0, 0, 11, 13, 0, 0, 0, 0, 0, 0, 14 },
            { 15, 19, 19, 19, 19, 19, 19, 19, 19, 19, 20, 21, 12, 12, 12, 17, 18, 16, 0, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 19, 19, 19, 19, 19, 19, 23, 0, 0, 0, 5, 10, 3, 14 },
            { 16, 7, 6, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 11, 12, 12, 12, 18 },
            { 16, 24, 25, 26, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 22, 19, 19, 19, 15 },
            { 16, 0, 0, 0, 0, 0, 13, 2, 0, 0, 0, 0, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 20, 13, 0, 0, 0, 11, 17, 27, 27, 27, 21, 13, 2, 0, 0, 0, 0, 0, 14 },
            { 16, 0, 0, 0, 0, 0, 15, 20, 13, 10, 8, 14, 15, 28, 28, 28, 15, 20, 21, 13, 0, 8, 7, 0, 14 },
            { 20, 21, 12, 12, 13, 27, 15, 15, 20, 12, 17, 18, 15, 28, 28, 28, 15, 15, 15, 20, 12, 12, 12, 17, 18 } };

        private Santa santa;
        private SnowmanSled snowmanSled;

        private List<Vector2> cadeauCoords = new List<Vector2>()
        {
            new Vector2(150,800),
            new Vector2(500,400),
            new Vector2(600,1500)
        };


        public World(ContentManager content) {
            Tiles = new List<IGameObject>();
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
            this.santa = new Santa(santaTexture, 5, new Vector2(140,400));
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
            {
                Tiles.Remove(tile);
                //if santa is on the to remove list, santa is dead :(
                if (tile is Santa)
                    return GameState.StartScreen;
            }
            return GameState.Level1;
        }
        private IGameObject LoadGameObject(int id, int x, int y) {
            switch (id)
            {
                case 1:
                    //crate
                    throw new System.IndexOutOfRangeException();
                    break;
                case 2:
                    //objectname crystal
                    return new GameTile(tilesTexture, new Frame(new Rectangle(101, 384, 97, 78),false), x, y);
                case 3:
                    //objectname icebox
                    return new GameTile(tilesTexture, new Frame(new Rectangle(198, 384, 101, 101)), x, y);
                case 4:
                    //objectname igloo
                    return new GameTile(tilesTexture, new Frame(new Rectangle(299, 384, 511, 201), false), x, y);
                case 5:
                    //objectname sign_1
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 585, 87, 94), false), x, y);
                case 6:
                    //objectname sign_2
                    return new GameTile(tilesTexture, new Frame(new Rectangle(87, 585, 87, 93), false), x, y);
                case 7:
                    //objectname snowman
                    return new GameTile(tilesTexture, new Frame(new Rectangle(174, 585, 193, 210), false), x, y);
                case 8:
                    //objectname stone
                    return new GameTile(tilesTexture, new Frame(new Rectangle(367, 585, 124, 78), false), x, y);
                case 9:
                    //objectname tree_1
                    return new GameTile(tilesTexture, new Frame(new Rectangle(768, 0, 364, 280), false), x, y);
                case 10:
                    //objectname tree_2
                    return new GameTile(tilesTexture, new Frame(new Rectangle(810, 280, 228, 280), false), x, y);
                case 11:
                    //tilename 1
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 0, 128, 128)), x, y);
                case 12:
                    //tilename 2
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 128, 128, 128)), x, y);
                case 13:
                    //tilename 3
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 128, 128, 128)), x, y);
                case 14:
                    //tilename 4
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 256, 128, 128)), x, y);
                case 15:
                    //tilename 5
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 256, 128, 128)), x, y);
                case 16:
                    //tilename 6
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 256, 128, 128)), x, y);
                case 17:
                    //tilename 7
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 256, 128, 128)), x, y);
                case 18:
                    //tilename 8
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 256, 128, 128)), x, y);
                case 19:
                    //tilename 9
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 256, 128, 128)), x, y);
                case 20:
                    //tilename 10
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 0, 128, 128)), x, y);
                case 21:
                    //tilename 11
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 0, 128, 128)), x, y);
                case 22:
                    //tilename 12
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 0, 128, 128)), x, y);
                case 23:
                    //tilename 13
                    return new GameTile(tilesTexture, new Frame(new Rectangle(512, 0, 128, 128)), x, y);
                case 24:
                    //tilename 14
                    return new GameTile(tilesTexture, new Frame(new Rectangle(640, 0, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 25:
                    //tilename 15
                    return new GameTile(tilesTexture, new Frame(new Rectangle(0, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 26:
                    //tilename 16
                    return new GameTile(tilesTexture, new Frame(new Rectangle(128, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 0, 128, 92)), x, y);
                case 27:
                    //tilename 17
                    return new GameTile(tilesTexture, new Frame(new Rectangle(256, 128, 128, 128), ContentLoadingTools.CoordToRect(0, 29, 128, 128)), x, y);
                case 28:
                    //tilename 18
                    return new GameTile(tilesTexture, new Frame(new Rectangle(384, 128, 128, 128)), x, y);

                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
    }
}

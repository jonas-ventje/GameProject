using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject.Content.Game {
    internal class GameTile : IGameObject {
        private const int tileWidth = 128;
        private const int tileHeight = 128;
        private Texture2D texture;
        private Frame tileFrame;
        private Vector2 position;
        public GameTile(Texture2D texture, int id, int x, int y) {
            this.texture = texture;
            position = new Vector2(x * tileWidth, y * tileHeight);
            this.tileFrame = LoadTile(id);
        }

        public Rectangle IntersectionBlock
        {
            get
            {
                //position + left boundry, position + top boundry
                return new Rectangle((int)position.X + tileFrame.Hitbox.Left, (int)position.Y + tileFrame.Hitbox.Top, tileFrame.Hitbox.Width, tileFrame.Hitbox.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, tileFrame.BoundingBox, Color.White);
        }

        private Frame LoadTile(int id) {
            switch (id)
            {
                case 1:
                    return new Frame(new Rectangle(0, 0, 128, 128));
                case 2:
                    return new Frame(new Rectangle(128, 0, 128, 128));
                case 3:
                    return new Frame(new Rectangle(256, 0, 128, 128));
                case 4:
                    return new Frame(new Rectangle(384, 0, 128, 128));
                case 5:
                    return new Frame(new Rectangle(512, 0, 128, 128));
                case 6:
                    return new Frame(new Rectangle(640, 0, 128, 128));
                case 7:
                    return new Frame(new Rectangle(0, 128, 128, 128));
                case 8:
                    return new Frame(new Rectangle(128, 128, 128, 128));
                case 9:
                    return new Frame(new Rectangle(256, 128, 128, 128), ContentLoadingTools.CoordToRect(0,29, 128,128));
                case 10:
                    return new Frame(new Rectangle(384, 128, 128, 128));
                case 11:
                    return new Frame(new Rectangle(512, 128, 128, 128));
                case 12:
                    return new Frame(new Rectangle(640, 128, 128, 128));
                case 13:
                    return new Frame(new Rectangle(0, 256, 128, 128));
                case 14:
                    return new Frame(new Rectangle(128, 256, 128, 128));
                case 15:
                    return new Frame(new Rectangle(256, 256, 128, 128));
                case 16:
                    return new Frame(new Rectangle(384, 256, 128, 128));
                case 17:
                    return new Frame(new Rectangle(512, 256, 128, 128));
                case 18:
                    return new Frame(new Rectangle(640, 256, 128, 128));

                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
    }
}
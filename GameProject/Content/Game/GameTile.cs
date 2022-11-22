using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject.Content.Game {
    internal class GameTile : IStaticGameObject {
        private const int tileWidth = 128;
        private const int tileHeight = 128;
        private Texture2D texture;
        private Rectangle tileRectangle;
        private Vector2 position;
        public GameTile(Texture2D texture, int id, int x, int y) {
            this.texture = texture;
            position = new Vector2(x * tileWidth, y * tileHeight);
            this.tileRectangle = LoadTile(id);
        }

        public Rectangle IntersectionBlock
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, tileRectangle.Width, tileRectangle.Height);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, tileRectangle, Color.White);
        }

        private Rectangle LoadTile(int id) {
            switch (id)
            {
                case 1:
                    return new Rectangle(0, 0, 128, 128);
                case 2:
                    return new Rectangle(128, 0, 128, 128);
                case 3:
                    return new Rectangle(256, 0, 128, 128);
                case 4:
                    return new Rectangle(384, 0, 128, 128);
                case 5:
                    return new Rectangle(512, 0, 128, 128);
                case 6:
                    return new Rectangle(640, 0, 128, 128);
                case 7:
                    return new Rectangle(0, 128, 128, 128);
                case 8:
                    return new Rectangle(128, 128, 128, 128);
                case 9:
                    return new Rectangle(256, 128, 128, 128);
                case 10:
                    return new Rectangle(384, 128, 128, 128);
                case 11:
                    return new Rectangle(512, 128, 128, 128);
                case 12:
                    return new Rectangle(640, 128, 128, 128);
                case 13:
                    return new Rectangle(0, 256, 128, 128);
                case 14:
                    return new Rectangle(128, 256, 128, 128);
                case 15:
                    return new Rectangle(256, 256, 128, 128);
                case 16:
                    return new Rectangle(384, 256, 128, 128);
                case 17:
                    return new Rectangle(512, 256, 128, 128);
                case 18:
                    return new Rectangle(640, 256, 128, 128);

                default:
                    throw new System.IndexOutOfRangeException();
            }
        }
    }
}
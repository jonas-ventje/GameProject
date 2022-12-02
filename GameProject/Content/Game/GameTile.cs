using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject.Content.Game
{
    internal class GameTile : IGameObject {

        private Texture2D texture;
        private Frame tileFrame;
        private Vector2 position;
        private bool toBeRemoved = false;
        public GameTile(Texture2D texture, Frame tileFrame, int x, int y) {
            this.texture = texture;
            position = new Vector2(x, y);
            this.tileFrame = tileFrame;
        }

        public Rectangle IntersectionBlock
        {
            get
            {
                //position + left boundry, position + top boundry
                return new Rectangle((int)position.X + tileFrame.Hitbox.Left, (int)position.Y + tileFrame.Hitbox.Top, tileFrame.Hitbox.Width, tileFrame.Hitbox.Height);
            }
        }

        public bool ToBeRemoved => toBeRemoved;

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, tileFrame.BoundingBox, Color.White);
        }
    }
}
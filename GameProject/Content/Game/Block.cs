using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content
{
    internal class Block : IStaticGameObject {
        private Rectangle block;
        private Vector2 position;
        private Texture2D texture;
        private static List<Block> blocks = new List<Block>();

        public static List<Block> Blocks
        {
            get
            {
                return blocks; 
            }
        }
        public Rectangle IntersectionBlock
        {
            get
            {
                return new Rectangle((int)position.X, (int)position.Y, block.Width, block.Height);
            }
        }

        public Block(Texture2D texture, int width, int height, Vector2 position) {
            blocks.Add(this);
            this.texture = texture;
            this.position = position;
            block = new Rectangle(0,0, width, height);
        }
        public void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, block, Color.White);
        }
    }
}

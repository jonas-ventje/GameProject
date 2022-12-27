using GameProject.Content.Game.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GameProject.Content.Game {
    internal class Progressbar {
        private Texture2D textureBg;
        private Texture2D textureBar;
        private Vector2 position = new Vector2(40, 150);
        private Rectangle visibleProgressbar;
        private World world;


        private const int speed = 5;
        private double secondCounter;
        private const int fps = 15;
        public Progressbar(Texture2D textureBg, Texture2D textureBar, World world) {
            this.textureBg = textureBg;
            this.textureBar = textureBar;
            this.world = world;
            visibleProgressbar = new Rectangle(0, 0, textureBar.Width, 0);
        }

        public void Update(GameTime gameTime) {

            int totalLength = textureBar.Height;
            int finalHeight = (int)(totalLength * world.CatchedRatio);

            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (secondCounter >= 1d / fps)
            {
                if (finalHeight >= visibleProgressbar.Height + speed)
                    visibleProgressbar.Height += speed;
                else if (world.CatchedRatio == 1)
                    visibleProgressbar.Height = textureBar.Height;
            }
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(textureBg, position, Color.White);
            spriteBatch.Draw(textureBar, new Vector2(position.X + 14, position.Y + 726 - visibleProgressbar.Height), visibleProgressbar, Color.White);
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens {
    internal class CountDownScreen {
        private const int millisVisible = 5000;
        private int timeLeftMillis;
        public CountDownScreen() {
            timeLeftMillis = millisVisible;
        }
        public void Draw(SpriteBatch spriteBatch) {
            Texture2D rectangleTextue = new Texture2D(spriteBatch.GraphicsDevice, 1, 1, false, SurfaceFormat.Color);
            rectangleTextue.SetData(new[] { Color.MediumVioletRed });
            spriteBatch.Draw(rectangleTextue, Vector2.Zero, new Rectangle(0, 0, Game1.virtualWidth * timeLeftMillis / millisVisible, 40), Color.White);
        }

        public bool isVisible(GameTime gameTime) {
            timeLeftMillis -= gameTime.ElapsedGameTime.Milliseconds;
            return timeLeftMillis <= 0 ? false : true;
        }
    }
}

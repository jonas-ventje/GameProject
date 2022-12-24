using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens {
    internal class GameOverScreen:CountDownScreen, IScreen {
        private Texture2D gameOverTexture;
        private ContentManager content;

        public GameOverScreen(ContentManager content) {
            gameOverTexture = content.Load<Texture2D>("./images/gameover");
            this.content = content;
        }
        public new void Draw(SpriteBatch spriteBatch) {
            int centerX = (Game1.virtualWidth - gameOverTexture.Width) / 2;
            int centerY = (Game1.virtualHeight - gameOverTexture.Height) / 2;
            spriteBatch.Draw(gameOverTexture, new Vector2(centerX, centerY), Color.White);

            base.Draw(spriteBatch);
        }

        public IScreen Update(GameTime gameTime) {
            if (!isVisible(gameTime))
                return new StartScreen(content);
            return this;
        }
    }
}

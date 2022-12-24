using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace GameProject.Content.Game.Screens {
    internal class VictoryScreen : CountDownScreen, IScreen {
        private Texture2D victoryTexture;
        private SpriteFont font;
        private string score;
        private ContentManager content;

        public VictoryScreen(ContentManager content, string score) {
            victoryTexture = content.Load<Texture2D>("./images/victory");
            font = content.Load<SpriteFont>("font/santa_christmas");
            this.content = content;
            this.score = score;

        }
        public new void Draw(SpriteBatch spriteBatch) {
            int centerX = (Game1.virtualWidth - victoryTexture.Width) / 2;
            int centerY = (Game1.virtualHeight - victoryTexture.Height) / 2;
            spriteBatch.Draw(victoryTexture, new Vector2(centerX, centerY), Color.White);

            base.Draw(spriteBatch);

            // Places text in center of the screen
            Vector2 textMiddlePoint = font.MeasureString(score) / 2;
            spriteBatch.DrawString(font, score, new Vector2(Game1.virtualWidth/2, 1340), Color.White, 0, textMiddlePoint, 1.3f, SpriteEffects.None, 0.5f);
        }

        public IScreen Update(GameTime gameTime) {
            if (!isVisible(gameTime))
                return new StartScreen(content);
            return this;
        }
    }
}

using Microsoft.VisualBasic.Logging;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens {
    internal class InfoScreen : IScreen {
        private Texture2D infoTexture;
        private Texture2D logoTexture;
        private ContentManager content;
        private Button backButton;

        public InfoScreen(ContentManager content) {
            this.content = content;
            infoTexture = content.Load<Texture2D>("./images/info");
            logoTexture = content.Load<Texture2D>("./images/Logo");
            backButton = new Button(content.Load<Texture2D>("./images/button2"), content.Load<SpriteFont>("./font/sugar_snow"), 2200, 200, "X");
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(logoTexture, new Vector2(Game1.virtualWidth / 2, 100), null, Color.White, 0f, new Vector2(logoTexture.Width / 2, 0), .9f, SpriteEffects.None, 1f);
            spriteBatch.Draw(infoTexture, new Vector2(Game1.virtualWidth / 2, 600), null, Color.White, 0f, new Vector2(infoTexture.Width / 2, 0), .9f, SpriteEffects.None, 1f);
            backButton.Draw(spriteBatch);

        }

        public IScreen Update(GameTime gameTime) {
            if (backButton.Update())
                return new StartScreen(content);
            return this;
        }
    }
}

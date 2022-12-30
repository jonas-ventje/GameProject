using GameProject.Content.Game.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens {

    internal class StartScreen : IScreen {
        private SpriteFont font;
        private Texture2D buttonTexture;
        private Texture2D buttonBackgroundTexture;
        private Dictionary<Button, Type> buttons;
        private ContentManager content;
        public StartScreen(ContentManager content) {
            buttonTexture = content.Load<Texture2D>("./images/button");
            buttonBackgroundTexture = content.Load<Texture2D>("./images/buttonBackground");
            font = content.Load<SpriteFont>("font/santa_christmas");
            buttons = new Dictionary<Button, Type>();
            this.content = content;
            PlaceButtons();
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(buttonBackgroundTexture, new Vector2(Game1.virtualWidth / 2, Game1.virtualHeight / 2), null, Color.White, 0f, new Vector2(buttonBackgroundTexture.Width / 2, buttonBackgroundTexture.Height / 2), 1.5f, SpriteEffects.None, 1f);
            foreach (var button in buttons)
            {
                button.Key.Draw(spriteBatch);
            }
        }

        public IScreen Update(GameTime gameTime) {
            foreach (var button in buttons)
            {
                if (button.Key.Update() == true)
                {
                    Type type = button.Value;
                    if (typeof(ILevel).IsAssignableFrom(type))
                        return new World(content, (ILevel)Activator.CreateInstance(type));
                }
            }
            return this;
        }

        public void PlaceButtons() {
            const int rows = 2;
            int columns = (int)Math.Ceiling(Scores.LevelScores.Count / (double)rows);
            const int marginHorizontal = 600;
            const int marginVertical = 300;
            const int startY = 800;
            int startX = (Game1.virtualWidth - marginHorizontal * (columns - 1) - buttonTexture.Width) / 2;

            for (int i = 0; i < Scores.LevelScores.Count; i++)
            {
                int nthRow = i / columns;
                int nthColumn = (i) % columns;
                int x = startX + nthColumn * marginHorizontal;
                int y = startY + nthRow * marginVertical;
                Type level = Scores.LevelScores.ElementAt(i).Key;
                string levelName = level.Name.Substring(5);
                bool isDisabled = i==0?false:Scores.LevelScores.ElementAt(i - 1).Value == 0;
                buttons.Add(new Button(buttonTexture, font, x, y, levelName, isDisabled), level);

            }
            int centerX = (Game1.virtualWidth - buttonTexture.Width) / 2;
            buttons.Add(new Button(buttonTexture, font, centerX, 1400, "level info"), typeof(StartScreen));
        }
    }
}

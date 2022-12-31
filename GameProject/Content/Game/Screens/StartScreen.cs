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
        private Texture2D logo;
        private Dictionary<Button, Type> levelButtons;
        private ContentManager content;
        private Button infoButton;
        public StartScreen(ContentManager content) {
            buttonTexture = content.Load<Texture2D>("./images/button2");
            font = content.Load<SpriteFont>("font/sugar_snow");
            logo = content.Load<Texture2D>("./images/logo");
            levelButtons = new Dictionary<Button, Type>();
            this.content = content;
            PlaceLevelButtons();
            infoButton = new Button(content.Load<Texture2D>("./images/button2"), content.Load<SpriteFont>("./font/sugar_snow"), 2200, 200, "?");

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(logo, new Vector2(Game1.virtualWidth / 2, 100), null, Color.White, 0f, new Vector2(logo.Width / 2, 0), .9f, SpriteEffects.None, 1f);
            foreach (var button in levelButtons)
            {
                button.Key.Draw(spriteBatch);
            }
            infoButton.Draw(spriteBatch);
        }

        public IScreen Update(GameTime gameTime) {
            foreach (var button in levelButtons)
            {
                if (button.Key.Update() == true)
                {
                    Type type = button.Value;
                    if (typeof(ILevel).IsAssignableFrom(type))
                        return new World(content, (ILevel)Activator.CreateInstance(type));
                }
            }
            if (infoButton.Update())
                return new InfoScreen(content);
            return this;
        }

        public void PlaceLevelButtons() {
            const int rows = 3;
            //int columns = (int)Math.Ceiling(Scores.LevelScores.Count / (double)rows);
            int columns = 5;
            const int marginHorizontal = 400;
            const int marginVertical = 400;
            const int startY = 600;
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
                //bool isDisabled = false;
                levelButtons.Add(new Button(buttonTexture, font, x, y, levelName, isDisabled), level);
            }
            for (int i = Scores.LevelScores.Count; i < rows*columns; i++)
            {
                int nthRow = i / columns;
                int nthColumn = (i) % columns;
                int x = startX + nthColumn * marginHorizontal;
                int y = startY + nthRow * marginVertical;
                levelButtons.Add(new Button(buttonTexture, font, x, y, "X", true), typeof(StartScreen));
            }

        }
    }
}

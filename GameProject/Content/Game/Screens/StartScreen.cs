using GameProject.Content.Game.Levels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens
{

    internal class StartScreen : IScreen
    {
        private enum NewScreen {Level1,Level2, Info}
        private SpriteFont font;
        private Texture2D buttonTexture;
        private Dictionary<Button, NewScreen> buttons;
        private ContentManager content;
        public StartScreen(ContentManager content)
        {
            buttonTexture = content.Load<Texture2D>("./images/button");
            font = content.Load<SpriteFont>("font/santa_christmas");
            buttons = new Dictionary<Button, NewScreen>();
            this.content = content;


            int centerX = (Game1.virtualWidth - buttonTexture.Width) / 2;
            buttons.Add(new Button(buttonTexture, font, centerX, 800, "level 1"), NewScreen.Level1);
            buttons.Add(new Button(buttonTexture, font, centerX, 1100, "level 2"), NewScreen.Level2);
            buttons.Add(new Button(buttonTexture, font, centerX, 1400, "level info"), NewScreen.Info);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var button in buttons)
            {
                button.Key.Draw(spriteBatch);
            }
        }

        public IScreen Update(GameTime gameTime)
        {
            foreach (var button in buttons)
            {
                if (button.Key.Update() == true)
                {
                    switch (button.Value)
                    {
                        case NewScreen.Level1:
                            return new World(content, new Level1());
                            break;
                        case NewScreen.Level2:
                            throw new NotImplementedException();
                            break;
                        case NewScreen.Info:
                            throw new NotImplementedException();
                            break;
                        default:
                            break;
                    }
                }
            }
            return this;
        }
    }
}

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
        SpriteFont font;
        Texture2D buttonTexture;
        Dictionary<Button, IScreen> buttons;
        public StartScreen(ContentManager content)
        {
            buttonTexture = content.Load<Texture2D>("./images/button");
            font = content.Load<SpriteFont>("font/santa_christmas");
            buttons = new Dictionary<Button, IScreen>();


            int centerX = (Game1.virtualWidth - buttonTexture.Width) / 2;
            buttons.Add(new Button(buttonTexture, font, centerX, 800, "level 1"), new World(content, new Level1()));
            buttons.Add(new Button(buttonTexture, font, centerX, 1100, "level 2"), new World(content, new Level1()));
            buttons.Add(new Button(buttonTexture, font, centerX, 1400, "level info"), new World(content, new Level1()));
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
                    return button.Value;
                }
            }
            return this;
        }
    }
}

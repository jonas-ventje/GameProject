using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {

    internal class StartScreen:IScreen {
        SpriteFont font;
        Texture2D buttonTexture;
        Dictionary<Button, GameState> buttons;
        public StartScreen(ContentManager content) {
            buttonTexture = content.Load<Texture2D>("./images/button");
            font = content.Load<SpriteFont>("font/santa_christmas");
            buttons= new Dictionary<Button, GameState>();


            int buttonPositionX = (Game1.virtualWidth - buttonTexture.Width) / 2;
            buttons.Add(new Button(buttonTexture, font, buttonPositionX, 800, "level 1"), GameState.Level1);
            buttons.Add(new Button(buttonTexture, font, buttonPositionX, 1100, "level 2"), GameState.Level2);
            buttons.Add(new Button(buttonTexture, font, buttonPositionX, 1400, "level info"), GameState.Info);
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var button in buttons)
            {
                button.Key.Draw(spriteBatch);
            }
        }

        public GameState Update(GameTime gameTime) {
            foreach (var button in buttons)
            {
                if (button.Key.Update() == true)
                {
                    return button.Value;
                }
            }
            return GameState.StartScreen;
        }
    }
}

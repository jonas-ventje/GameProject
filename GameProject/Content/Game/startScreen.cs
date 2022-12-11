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
        Dictionary<string, Button> buttons;
        public StartScreen(ContentManager content) {
            buttonTexture = content.Load<Texture2D>("./images/button");
            font = content.Load<SpriteFont>("font/santa_christmas");
            buttons= new Dictionary<string, Button>();


            int buttonPositionX = (Game1.virtualWidth - buttonTexture.Width) / 2;
            buttons.Add( "lv1", new Button(buttonTexture, font, buttonPositionX, 800, "level 1"));
            buttons.Add("lv2", new Button(buttonTexture, font, buttonPositionX, 1100, "level 2"));
            buttons.Add("info", new Button(buttonTexture, font, buttonPositionX, 1400, "level info"));
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach (var button in buttons)
            {
                button.Value.Draw(spriteBatch);
            }
        }

        public GameState Update(GameTime gameTime) {
            GameState nextGameState = GameState.StartScreen;
            foreach (var button in buttons)
            {
                if (button.Value.Update() == true)
                {
                    if (button.Key == "lv1")
                        nextGameState = GameState.Level1;
                    if(button.Key == "lv2")
                        nextGameState= GameState.Level2;
                    if (button.Key == "info")
                        nextGameState = GameState.Info;
                }
            }
            return nextGameState;
        }
    }
}

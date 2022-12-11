using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {

    internal class startScreen:IScreen {
        SpriteFont font;
        Texture2D buttonTexture;
        Dictionary<string, Button> buttons;
        public startScreen(ContentManager content) {
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

        public void Update(GameTime gameTime) {
            foreach (var button in buttons)
            {
                button.Value.Update();
            }
        }
    }
}

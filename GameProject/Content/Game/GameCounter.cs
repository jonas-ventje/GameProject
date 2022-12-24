using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class GameCounter {
        private SpriteFont font;
        private double millisElapsed;
        private string millisPrint = "";

        public string Score
        {
            get => millisPrint;
        }

        public GameCounter(SpriteFont font) {
            this.font = font;
        }
        public void Update(GameTime gameTime) {
            millisElapsed = gameTime.TotalGameTime.TotalMilliseconds;
            millisPrint = ((int)millisElapsed).ToString();
            millisPrint = millisPrint.Substring(0, millisPrint.Length - 1);
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, millisPrint, new Vector2(20, 20), Color.White);
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class GameCounter : ISantaObserver {
        private SpriteFont font;
        private double gameMillis = 0;
        private double millisStarted = 0;
        private string millisPrint = "";
        private bool santaMoved;

        public string Score
        {
            get => millisPrint;
        }

        public GameCounter(SpriteFont font, IObserverSubject subject) {
            this.font = font;
            subject.RegisterObserver(this);
            santaMoved = false;
        }
        public void Update(GameTime gameTime) {
            if (santaMoved)
            {
                if (millisStarted == 0)
                    millisStarted = gameTime.TotalGameTime.TotalMilliseconds;
                gameMillis = gameTime.TotalGameTime.TotalMilliseconds - millisStarted;
            }
            millisPrint = ((int)gameMillis).ToString();
            millisPrint = millisPrint.Substring(0, millisPrint.Length - 1);
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.DrawString(font, millisPrint, new Vector2(20, 20), Color.White);
        }

        public void update(bool santaMoved) {
            this.santaMoved = santaMoved;
        }
    }
}

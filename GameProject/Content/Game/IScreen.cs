using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    enum GameState {StartScreen, Info, Level1, Level2, GameOver}
    internal interface IScreen {
        void Draw(SpriteBatch spriteBatch);
        GameState Update(GameTime gameTime);

    }
}

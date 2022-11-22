using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class InputReaderKeyboard : IInputReader {
        public Vector2 InputMovement() {
            KeyboardState state = Keyboard.GetState();
            var movement = new Vector2(0, 0);
            if (state.IsKeyDown(Keys.Left))
                movement.X -= 1;
            if (state.IsKeyDown(Keys.Right))
                movement.X += 1;
            if (state.IsKeyDown(Keys.Down))
                movement.Y -= 1;
            if (state.IsKeyDown(Keys.Up))
                movement.Y += 1;
            if (state.IsKeyDown(Keys.Space))
                movement.Y += 1;
            return movement;
        }
    }
}

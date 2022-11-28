using GameProject.Content.Game.Movables;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movement
{
    internal class ControllableMovementManager:GravityMovementManager {

        public void Move(IControllableObject movable, GameTime gameTime) {
            Vector2 direction = movable.InputReader.ReadInput();
            Vector2 movement = new Vector2(direction.X, 0);

            //check if there is a space or arrow up button pressed
            if (direction.Y < 0)
                base.StartJump();

            if (movement.X != 0)
            {

                if (movement.X < 0)
                    movable.SpriteDirection = SpriteEffects.FlipHorizontally;
                else
                    movable.SpriteDirection = SpriteEffects.None;
            }

            movement *= movable.HorizontalSpeed;
            base.Move(movable, gameTime, movement);
        }
    }
}

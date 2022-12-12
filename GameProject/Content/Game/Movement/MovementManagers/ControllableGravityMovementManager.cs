using GameProject.Content.Game.GameObjects;
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

namespace GameProject.Content.Game.Movement.MovementManagers
{
    internal class ControllableGravityMovementManager : GravityMovementManager {

        public void Move(IControllableGravityObject movable, GameTime gameTime) {
            if (movable.CurrentMovingState != MovingState.Dying)
            {

                Vector2 direction = movable.InputReader.ReadInput();
                Vector2 movement = new Vector2(direction.X, 0);

                //check if there is a space or arrow up button pressed
                if (direction.Y < 0)
                    StartJump();

                if (movement.X != 0)
                {
                    if (movement.X < 0)
                        movable.SpriteDirection = SpriteEffects.FlipHorizontally;
                    else
                        movable.SpriteDirection = SpriteEffects.None;
                }

                movement *= movable.HorizontalSpeed;
                base.Move(movable, gameTime, movement);
                //check which animation frame is required
                if (isInTheAir)
                    movable.CurrentMovingState = MovingState.Jumping;
                else if (movement.X == 0)
                    movable.CurrentMovingState = MovingState.Idle;
                if (movement.X != 0)
                    movable.CurrentMovingState = MovingState.Walking;
            }
        }
    }
}

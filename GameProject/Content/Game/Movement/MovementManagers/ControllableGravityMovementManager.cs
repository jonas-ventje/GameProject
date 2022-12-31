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

namespace GameProject.Content.Game.Movement.MovementManagers {
    internal class ControllableGravityMovementManager : GravityMovementManager {
        public void Move(ControllableGravityObject movable, GameTime gameTime) {
            if (movable.CurrentMovingState != MovingState.Dying)
            {

                Vector2 direction = movable.InputReader.ReadInput();
                Vector2 movement = new Vector2(direction.X, 0);
                bool descentLadderRequest = direction.Y > 0;
                if (!IsOnLadder)
                {
                    //check if there is a space or arrow up button pressed
                    if (direction.Y < 0)
                    {
                        StartJump();
                    }
                }
                else
                {
                    movement = direction;
                }

                if (movement.X != 0)
                {
                    if (movement.X < 0)
                        movable.SpriteDirection = SpriteEffects.FlipHorizontally;
                    else
                        movable.SpriteDirection = SpriteEffects.None;
                }

                movement *= movable.Speed;
                Move(movable, gameTime, movement, descentLadderRequest);


                //check which animation frame is required
                if (movable.CurrentMovingState != MovingState.Dying)
                {

                    if (isInTheAir)
                        if (jumpPower != 0)
                            movable.CurrentMovingState = MovingState.Jumping;
                        else
                            movable.CurrentMovingState = MovingState.Falling;
                    else if (movement.X == 0)
                        movable.CurrentMovingState = MovingState.Idle;
                    else if (movement.X != 0)
                        movable.CurrentMovingState = MovingState.Walking;
                }
            }
        }
    }
}

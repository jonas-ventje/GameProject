using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.GameObjects;

namespace GameProject.Content.Game.Movement.MovementManagers
{
    internal class ControllableNonGravityMovementManager:BasicMovementManager {
        public void Move(ControllableObject movable, GameTime gameTime) {
            Vector2 movement = movable.InputReader.ReadInput();
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

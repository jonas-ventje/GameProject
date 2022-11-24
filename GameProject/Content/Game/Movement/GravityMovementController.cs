using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game
{
    internal class GravityMovementController : GravityObject, IMovementController {

        private IInputReader inputReader;
        private Vector2 speed;
        public GravityMovementController(IInputReader inputReader, Vector2 speed) {
            this.speed = speed;
            this.inputReader = inputReader;
        }

#nullable enable
        public Vector2 Move(GameTime? gameTime, Frame frame, Vector2 position, SpriteEffects spriteEffect, out Vector2 noCollisionMovement) {
            if (gameTime == null)
                throw new NotImplementedException();
            Vector2 inputMovement = inputReader.InputMovement();
            Vector2 movement = new Vector2(inputMovement.X, 0);

            //check if there is a space or arrow up button pressed
            if (inputMovement.Y > 0)
                StartJump();

            movement *= speed;
            movement += UpdateGravity(gameTime);
            noCollisionMovement = movement;
            Vector2 actualMovement = CollisionController.CalculateAvailableMovement(frame, spriteEffect, position, movement);

            //check if object reaches the ground, and obviously needs to fall otherwise
            //an object reaches the ground when movement is movement is downwards and the actualmovemnt is zero or upwards
            //but if the movements are in the other direction, the top is reached and termination of the ascent is required
            if (movement.Y > 0 && actualMovement.Y <= 0)
                ReachGround();
            else if (movement.Y < 0 && actualMovement.Y >= 0)
                StopAscent();
            else
                StartFalling();

            return actualMovement;
        }
#nullable disable
    }
}

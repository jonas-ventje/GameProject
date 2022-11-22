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
    internal class MovementControllerSanta : GravityObject, IMovementController {

        private IInputReader inputReader;
        private Vector2 speed;
        public MovementControllerSanta(IInputReader inputReader, Vector2 speed) {
            this.speed = speed;
            this.inputReader = inputReader;
        }

#nullable enable
        public Vector2 Move(GameTime? gameTime, ref List<Frame> frameList, ref int activeFrame, ref SpriteEffects spriteEffect, Vector2 position) {
            Frame frame = frameList[activeFrame];
            if (gameTime == null)
                throw new NotImplementedException();
            Vector2 inputMovement = inputReader.InputMovement();
            Vector2 movement = new Vector2(inputMovement.X, 0);

            //check if there is a space or arrow up button pressed
            if (inputMovement.Y > 0)
                StartJump();

            movement *= speed;
            movement += UpdateGravity(gameTime);
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


            //check which animation frame is required
            List<Frame> prevFrameList = frameList;
            if (movement.X == 0)
                frameList = SantaFrames.idleFrames;
            else if (movement.X != 0)
            {
                frameList = SantaFrames.walkingFrames;
                if (movement.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                else
                    spriteEffect = SpriteEffects.None;
            }
            //activeFrames must be set to 0 again when animation changes because it does not have equal numbers of frames
            if (prevFrameList != frameList)
                activeFrame = 0;



            return actualMovement;
        }
#nullable disable
    }
}

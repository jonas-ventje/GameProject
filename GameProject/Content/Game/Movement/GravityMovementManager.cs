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

namespace GameProject.Content.Game.Movement
{
    internal class GravityMovementManager {
        private float gravityAcceleration = 10f;
        //add a mass (it's not in the free fall formulla, but it's easyer to implement then air resistance and mass etc)
        private float mass = 3.2f;
        protected bool isInTheAir = false;
        private double airTime = 0;
        //this must be 0 for fallings, and a vertical upward speed (negative number) for jumpings
        float jumpPower = 0;

        /// <summary>
        /// Move the movable object given, Check for collisions, handle flips and movingstate
        /// </summary>
        /// <param name="movable">movable object</param>
        /// <param name="gameTime">gametime</param>
        /// <param name="inputReaderMovement">only needed for the inheritted controllableMovementManager, for left and right...</param>
        public void Move(MovableGameObject movable, GameTime gameTime, Vector2 inputReaderMovement = new Vector2()) {
            Vector2 movement = inputReaderMovement;
            movement += UpdateGravity(gameTime);

            Vector2 undoMovement = new Vector2();

            foreach (var gameObject in World.Tiles)
            {
                CollidingSide side;
                Vector2 intersection = CollisionController.CollisionDepth(movable.IntersectionBlock, gameObject.IntersectionBlock, movement, out side);
                if (intersection != Vector2.Zero)
                {
                    movable.CollisionEffect(gameObject, side);
                    if (Math.Abs(intersection.Y) > Math.Abs(undoMovement.Y))
                        undoMovement.Y = intersection.Y;
                    if (Math.Abs(intersection.X) > Math.Abs(undoMovement.X))
                        undoMovement.X = intersection.X;
                }
            }
            Vector2 actualMovement = movement - undoMovement;
            //Vector2 actualMovement = CollisionController.CalculateAvailableMovement(movable.ActiveFrame, movable.SpriteDirection, movable.Position, movement);

            //check if object reaches the ground, and obviously needs to fall otherwise
            //an object reaches the ground when movement is movement is downwards and the actualmovemnt is zero or upwards
            //but if the movements are in the other direction, the top is reached and termination of the ascent is required
            if (movement.Y > 0 && undoMovement.Y > 0)
                ReachGround();
            else if (movement.Y < 0 && undoMovement.Y < 0)
                StopAscent();
            else
                StartFalling();

            movable.Position += actualMovement;
        }
        #region gravity

        /// <summary>
        /// calculate vertical velocity when falling or jumping
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>vector with virtical velocity, horizontal is zero</returns>
        private Vector2 UpdateGravity(GameTime gameTime) {
            if (isInTheAir)
            {
                airTime += gameTime.ElapsedGameTime.TotalSeconds;
                return (new Vector2(0, (int)(gravityAcceleration * (float)airTime*mass + jumpPower)));
            }
            return new Vector2(0, gravityAcceleration);
        }

        /// <summary>
        /// call this function when start jumping
        /// </summary>
        protected void StartJump() {
            isInTheAir = true;
            jumpPower = -20f;
        }

        /// <summary>
        /// call this function when start falling
        /// </summary>
        private void StartFalling() {
            isInTheAir = true;
        }

        /// <summary>
        /// call this function when ground is reached by the object.
        /// </summary>
        private void ReachGround() {
            isInTheAir = false;
            airTime = 0;
            jumpPower = 0;
        }
        /// <summary>
        /// push the "in the air" time forward til the point where velocity is zero and you stop falling.
        /// </summary>
        private void StopAscent() {
            airTime = -jumpPower / (gravityAcceleration * mass);
        }
        #endregion
    }
}

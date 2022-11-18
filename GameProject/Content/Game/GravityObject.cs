using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal abstract class GravityObject {
        private float gravityAcceleration = 9.81f;
        //add a mass (it's not in the free fall formulla, but it's easyer to implement then air resistance and mass etc)
        private float mass = 2.5f;
        private bool isInTheAir = false;
        private double gravityPhysicsTime = 0;

        //this must be 0 for fallings, and a vertical upward speed (negative number) for jumpings
        float jumpPower = 0;

        /// <summary>
        /// calculate vertical velocity when falling or jumping
        /// </summary>
        /// <param name="gameTime"></param>
        /// <returns>vector with virtical velocity, horizontal is zero</returns>
        protected Vector2 UpdateGravity(GameTime gameTime) {

            if (isInTheAir)
            {
                gravityPhysicsTime += gameTime.ElapsedGameTime.TotalSeconds;
                return (new Vector2(0, gravityAcceleration * (float)gravityPhysicsTime*mass + jumpPower));
            }
            return new Vector2(0,gravityAcceleration);
        }

        /// <summary>
        /// call this function when start jumping
        /// </summary>
        protected void StartJump() {
            isInTheAir = true;
            jumpPower = -12f;
        }

        /// <summary>
        /// call this function when start falling
        /// </summary>
        protected void startFalling() {
            isInTheAir = true;
        }

        /// <summary>
        /// call this function when ground is reached by the object.
        /// </summary>
        protected void ReachGround() {
            isInTheAir = false;
            gravityPhysicsTime = 0;
            jumpPower = 0;
        }
    }
}

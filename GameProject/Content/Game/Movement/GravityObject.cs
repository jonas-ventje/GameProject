﻿using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal abstract class GravityObject {
        private float gravityAcceleration = 10f;
        //add a mass (it's not in the free fall formulla, but it's easyer to implement then air resistance and mass etc)
        private float mass = 3.2f;
        private bool isInTheAir = false;
        private double airTime = 0;

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
                airTime += gameTime.ElapsedGameTime.TotalSeconds;
                return (new Vector2(0, gravityAcceleration * (float)airTime*mass + jumpPower));
            }
            return new Vector2(0,gravityAcceleration);
        }

        /// <summary>
        /// call this function when start jumping
        /// </summary>
        protected void StartJump() {
            isInTheAir = true;
            jumpPower = -16f;
        }

        /// <summary>
        /// call this function when start falling
        /// </summary>
        protected void StartFalling() {
            isInTheAir = true;
        }

        /// <summary>
        /// call this function when ground is reached by the object.
        /// </summary>
        protected void ReachGround() {
            isInTheAir = false;
            airTime = 0;
            jumpPower = 0;
        }
        /// <summary>
        /// push the "in the air" time forward til the point where velocity is zero and you stop falling.
        /// </summary>
        protected void StopAscent() {
            airTime = -jumpPower / (gravityAcceleration * mass);
        }
    }
}
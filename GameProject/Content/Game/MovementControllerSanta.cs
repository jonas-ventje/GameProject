﻿using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class MovementControllerSanta : GravityObject, IMovementController {

        private IInputReader inputReader;
        private Vector2 speed;
        public MovementControllerSanta(IInputReader inputReader, Vector2 speed) {
            this.speed = speed;
            this.inputReader = inputReader;
        }

#nullable enable
        public Vector2 Move(GameTime? gameTime, SantaFrame frame, SpriteEffects spriteEffect, Vector2 position) {
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
            if (movement.Y != actualMovement.Y)
                ReachGround();
            else
                startFalling();

            return actualMovement;
        }
#nullable disable
    }
}

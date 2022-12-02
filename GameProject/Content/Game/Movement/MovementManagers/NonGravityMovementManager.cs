﻿using GameProject.Content.Game.Movables.Santa;
using GameProject.Content.Game.Movables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.GameObjects;

namespace GameProject.Content.Game.Movement.MovementManagers
{
    internal class NonGravityMovementManager {
        /// <summary>
        /// do the move with collisions
        /// </summary>
        /// <param name="movable"></param>
        /// <param name="gameTime"></param>
        /// <param name="inputMovement"></param>
        /// <returns>the undoMovemend used in the GravityMovmentManager</returns>
        public Vector2 Move(IMovableGameObject movable, GameTime gameTime, Vector2 inputMovement = new Vector2()) {
            Vector2 movement = inputMovement;
            Vector2 undoMovement = new Vector2();

            foreach (var gameObject in World.Tiles)
            {
                CollidingSide side;
                Vector2 intersection = CollisionController.CollisionDepth(movable.IntersectionBlock, gameObject.IntersectionBlock, movement, out side);
                if (intersection != Vector2.Zero)
                {
                    //no move back when collision is a cadeau, but santa does need to know
                    if (!(gameObject is Cadeau) || movable is Santa)
                        movable.CollisionEffect(gameObject, side);
                    if (!(gameObject is Cadeau))
                    {
                        if (Math.Abs(intersection.Y) > Math.Abs(undoMovement.Y))
                            undoMovement.Y = intersection.Y;
                        if (Math.Abs(intersection.X) > Math.Abs(undoMovement.X))
                            undoMovement.X = intersection.X;
                    }
                }
            }
            Vector2 actualMovement = movement - undoMovement;
            movable.Position += actualMovement;
            return undoMovement;
        }
    }
}

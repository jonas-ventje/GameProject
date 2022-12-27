using GameProject.Content.Game.Movables.Santa;
using GameProject.Content.Game.Movables;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Screens;
using System.Diagnostics;

namespace GameProject.Content.Game.Movement.MovementManagers {
    internal class BasicMovementManager {
        private double accelerationTime = 0;
        private const double acceleration = 1.5f;

        protected bool IsOnLadder = false;
        /// <summary>
        /// do the move with collisions
        /// </summary>
        /// <param name="movable"></param>
        /// <param name="gameTime"></param>
        /// <param name="inputMovement"></param>
        /// <returns>the undoMovemend used in the GravityMovmentManager</returns>
        /// 
        public Vector2 Move(MovableGameObject movable, GameTime gameTime, Vector2 inputMovement = new Vector2()) {
            Vector2 movement = inputMovement;
            //acceleration
            if (movable.CanAccelerate)
            {
                if (movement.X == 0)
                    accelerationTime = 0;
                movement.X += (int)(accelerationTime * acceleration) * Math.Sign(movement.X);
            }

            //collision
            #region collision
            Vector2 undoMovement = CalcUndoMovement(movable, movement);
            IsOnLadder = IntersectsAnyLadder(movable.IntersectionBlock);
            if (IsOnLadder)
            {
                undoMovement = RecalculatreUndoMovement(movable, movement, undoMovement);
            }
            Vector2 actualMovement = movement - undoMovement;
            #endregion

            //acceleartion
            if (actualMovement.X != movement.X)
                accelerationTime = 0;
            else
                accelerationTime += gameTime.ElapsedGameTime.TotalSeconds;


            movable.Position += actualMovement;
            return undoMovement;
        }

        private Vector2 CalcUndoMovement(MovableGameObject movable, Vector2 movement) {
            return CalcUndoMovement(movable, movement, new List<GameObject>());
        }
        private Vector2 CalcUndoMovement(MovableGameObject movable, Vector2 movement, List<GameObject> ignoredObjects) {
            Vector2 undoMovement = new Vector2();


            foreach (var gameObject in World.Tiles)
            {
                if (gameObject == movable)
                    continue;
                if (ignoredObjects.Contains(gameObject))
                    continue;
                if (movable.IntersectionBlock.IsEmpty || gameObject.IntersectionBlock.IsEmpty)
                    continue;
                if (!(movable is Santa) && gameObject is Gift)
                    continue;
                CollidingSide side;
                Vector2 intersection = CollisionController.CollisionDepth(movable.IntersectionBlock, gameObject.IntersectionBlock, movement, out side);
                if (intersection != Vector2.Zero)
                {
                    movable.CollisionEffect(gameObject, side);

                    //no move back when passable (water, gifts...)
                    if (!gameObject.Passable)
                    {
                        if (Math.Abs(intersection.Y) > Math.Abs(undoMovement.Y))
                            undoMovement.Y = intersection.Y;
                        if (Math.Abs(intersection.X) > Math.Abs(undoMovement.X))
                            undoMovement.X = intersection.X;
                    }
                }
            }
            return undoMovement;
        }
        private bool IntersectsAnyLadder(Point point) {
            return World.Tiles.Where(tile => tile is GameTile)
                .Where(tile => (tile as GameTile).Id == 29 || (tile as GameTile).Id == 30)
                .Any(tile => tile.IntersectionBlock.Contains(point));
        }
        private bool IntersectsAnyLadder(Rectangle rect) {
            return World.Tiles.Where(tile => tile is GameTile)
                .Where(tile => (tile as GameTile).Id == 29 || (tile as GameTile).Id == 30)
                .Any(ladder => ladder.IntersectionBlock.Intersects(rect));
        }
        private bool FitsBetweenAnyLadder(Rectangle rect) {
            return World.Tiles.Where(tile => tile is GameTile)
                .Where(tile => (tile as GameTile).Id == 29 || (tile as GameTile).Id == 30)
                .Any(ladder => rect.Left >= ladder.IntersectionBlock.Left && rect.Right <= ladder.IntersectionBlock.Right);
        }

        private List<GameObject> GameTilesBehindLadders() {
            var laddersIntersectionBlocks = World.Tiles.Where(tile => tile is GameTile)
                .Where(tile => (tile as GameTile).Id == 29 || (tile as GameTile).Id == 30)
                .Select(tile => tile.IntersectionBlock)
                .ToList();
            var gameTilesBehindLadders = World.Tiles.Where(tile => tile is GameTile)
                .Where(tile => (tile as GameTile).Id != 29 && (tile as GameTile).Id != 30)
                .Where(tile => laddersIntersectionBlocks.Any(ladder => ladder.Contains(tile.IntersectionBlock)))
                .ToList();
            return gameTilesBehindLadders;
        }

        /// <summary>
        /// when you're on a ladder, it means the undomovements has to be totaly different
        /// </summary>
        /// <param name="movable"></param>
        /// <param name="movement"></param>
        /// <param name="undoMovement"></param>
        /// <returns></returns>
        private Vector2 RecalculatreUndoMovement(MovableGameObject movable, Vector2 movement, Vector2 undoMovement) {
            Rectangle movedIntersectionBlock = movable.IntersectionBlock;
            movedIntersectionBlock.X += (int)movement.X;
            movedIntersectionBlock.Y += (int)movement.Y;

            //check if movable is at the end of a ladder to determine wheter an undomovement is required.
            Point movableMovedBottomCenter = new Point(movedIntersectionBlock.Center.X, movedIntersectionBlock.Bottom);
            Point movableBottomCenter = new Point(movable.IntersectionBlock.Center.X, movable.IntersectionBlock.Bottom);

            //if the sprite is on the boundry it would intersect, but we don't want that.
            if (movableBottomCenter.Y % 128 == 0)
                movableBottomCenter.Y -= 1;

            if (FitsBetweenAnyLadder(movedIntersectionBlock))
                undoMovement.X = 0;
            else
            {
                //recalculatre undomovement, because of the tiles behind the ladders has to be ignored
                List<GameObject> gameTilesBehindLadders = GameTilesBehindLadders();
                undoMovement = CalcUndoMovement(movable, movement, gameTilesBehindLadders);
            }
            if (IntersectsAnyLadder(movableMovedBottomCenter) && IntersectsAnyLadder(movableBottomCenter))
                undoMovement.Y = 0;
            return undoMovement;
        }
    }
}

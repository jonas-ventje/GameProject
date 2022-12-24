using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameProject.Content.Game.Movables.Santa {
    internal class Santa : ControllableGravityObject, IAnimatable {
        private Animation animation;
        private ControllableGravityMovementManager movementController;

        public Animation Animation => animation;

        public override bool CanAccelerate => true;

        public Santa(Texture2D texture, int speed, int x, int y):base(texture, new Vector2(x, y), SantaFrames.idleFrames[0], speed) {
            inputReader = new InputReaderKeyboard();
            movementController = new ControllableGravityMovementManager();
            animation = new Animation(SantaFrames.idleFrames, 15);
        }
        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (collisionObject is Gift)
                (collisionObject as Gift).ToBeRemoved = true;
            else if (collisionObject is Snowman.Snowman)
            {
                if (side == CollidingSide.Bottom)
                    (collisionObject as Snowman.Snowman).CurrentMovingState = MovingState.Dying;
                else
                    currentMovingState = MovingState.Dying;
            }
            else if (collisionObject is GameTile)
                if ((collisionObject as GameTile).Id == 27 || (collisionObject as GameTile).Id == 28)
                    currentMovingState = MovingState.Dying;

        }

        private void Move(GameTime gameTime) {
            movementController.Move(this, gameTime);
        }
        /// <summary>
        /// change framelist based on the current moving state which is walking, jumping...
        /// </summary>
        private void UpdateFrameList() {
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                case MovingState.Jumping:
                    Animation.updateFrameList(SantaFrames.idleFrames);
                    break;
                case MovingState.Walking:
                    Animation.updateFrameList(SantaFrames.walkingFrames);
                    break;
                case MovingState.Dying:
                    Animation.updateFrameList(SantaFrames.dyingFrames);
                    break;
                default:
                    break;
            }

        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }


        public override void Update(GameTime gameTime) {
            Move(gameTime);
            UpdateFrameList();
            frame = Animation.update(gameTime);
            //if below is true, santa is dead.
            if (Animation.FrameList == SantaFrames.dyingFrames && frame == Animation.FrameList[Animation.FrameList.Count-1])
            {
                toBeRemoved = true;
            }
        }
    }

}

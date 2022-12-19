using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameProject.Content.Game.Movables.Santa {
    internal class Santa : ControllableGravityObject, IAnimatable {
        private List<Frame> frameList;
        private Animation animation;
        private ControllableGravityMovementManager movementController;

        public Animation Animation => animation;

        public override bool CanAccelerate => true;

        public Santa(Texture2D texture, int speed, int x, int y):base(texture, new Vector2(x, y), SantaFrames.idleFrames[0], speed) {
            inputReader = new InputReaderKeyboard();
            movementController = new ControllableGravityMovementManager();
            frameList = SantaFrames.idleFrames;
            animation = new Animation(frameList, 15);
        }
        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (collisionObject is Cadeau)
                (collisionObject as Cadeau).ToBeRemoved = true;

        }

        private void Move(GameTime gameTime) {
            movementController.Move(this, gameTime);
        }
        /// <summary>
        /// change framelist based on the current moving state which is walking, jumping...
        /// </summary>
        private void updateFrameList() {
            List<Frame> prevFrameList = frameList;
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                case MovingState.Jumping:
                    frameList = SantaFrames.idleFrames;
                    break;
                case MovingState.Walking:
                    frameList = SantaFrames.walkingFrames;
                    break;
                case MovingState.Dying:
                    frameList = SantaFrames.dyingFrames;
                    break;
                default:
                    break;
            }
            if (prevFrameList != frameList)
                animation.reset();
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }


        public override void Update(GameTime gameTime) {
            Move(gameTime);
            frame = Animation.update(gameTime, frameList);
            updateFrameList();
            //if below is true, santa is dead.
            if (frameList == SantaFrames.dyingFrames && frame == frameList[frameList.Count-1])
            {
                toBeRemoved = true;
            }
        }
    }

}

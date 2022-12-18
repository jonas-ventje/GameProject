using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.Movement.MovementManagers;
using GameProject.Content.Game.GameObjects;

namespace GameProject.Content.Game.Movables.Crate {
    internal class Crate : MovableGameObject, IAnimatable {
        private List<Frame> activeFrameList;
        private Animation animation;
        private GravityMovementManager movementController;

        public Animation Animation => animation;

        public Crate(Texture2D texture, int x, int y) : base(texture, new Vector2(x, y), CrateFrames.idleFrames[0]) {
            activeFrameList = CrateFrames.idleFrames;
            movementController = new GravityMovementManager();
            animation = new Animation(activeFrameList, 20);
        }
        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (side == CollidingSide.Bottom && activeFrameList != CrateFrames.breakingFrames)
            {
                activeFrameList = CrateFrames.breakingFrames;
                animation.reset();
            }
            if (collisionObject is Santa.Santa && side == CollidingSide.Bottom)
            {
                (collisionObject as Santa.Santa).CurrentMovingState = MovingState.Dying;
            }
        }

        private void Move(GameTime gameTime) {
            movementController.Move(this, gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
        }


        public override void Update(GameTime gameTime) {
            Move(gameTime);
            frame = animation.update(gameTime, activeFrameList);
            if (frame == CrateFrames.breakingFrames[CrateFrames.breakingFrames.Count - 1])
            {
                toBeRemoved = true;
            }
        }
    }
}

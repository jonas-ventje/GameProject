using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movables.Santa;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GameProject.Content.Game.Movables.Snowman {
    internal class Snowman : ControllableGravityObject, IAnimatable, IPacing {
        private ControllableGravityMovementManager movementManager;
        private List<Frame> frameList;
        private Animation animation;
        private MovingDirection movingDirection = MovingDirection.Left;

        public Snowman(Texture2D texture, int speed, int x, int y) : base(texture, new Vector2(x, y), SnowmanFrames.idleFrames[0], speed) {
            inputReader = new InputReaderPacing(this);
            movementManager = new ControllableGravityMovementManager();
            frameList = SnowmanFrames.idleFrames;
            animation = new Animation(frameList, 15);
        }

        public override bool CanAccelerate => false;

        public Animation Animation => animation;

        public MovingDirection MovingDirection
        {
            get => movingDirection;
            set => movingDirection = value;
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (collisionObject is Santa.Santa)
            {
                (collisionObject as Santa.Santa).CurrentMovingState = MovingState.Dying;
            }
            if (side == CollidingSide.Right)
                movingDirection = MovingDirection.Left;
            else if (side == CollidingSide.Left)
                movingDirection = MovingDirection.Right;
        }
        private void Move(GameTime gameTime) {
            movementManager.Move(this, gameTime);
        }

        public override void Update(GameTime gameTime) {
            Move(gameTime);
            if (!(frameList == SnowmanFrames.dyingFrames && frame == frameList[frameList.Count - 1]))
            {
                frame = animation.update(gameTime, frameList);
            }
            UpdateFrameList();
        }

        public override Rectangle IntersectionBlock {
            get
            {
                Rectangle rect = base.IntersectionBlock;
                rect.Y -= frame.Hitbox.Height;
                return rect;
            }
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y-frame.BoundingBox.Height), frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }

        private void UpdateFrameList() {
            List<Frame> prevFrameList = frameList;
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                case MovingState.Jumping:
                    frameList = SnowmanFrames.idleFrames;
                    break;
                case MovingState.Walking:
                    frameList = SnowmanFrames.walkingFrames;
                    break;
                case MovingState.Dying:
                    frameList = SnowmanFrames.dyingFrames;
                    break;
                default:
                    break;
            }
            if (prevFrameList != frameList)
                animation.reset();
        }
    }
}

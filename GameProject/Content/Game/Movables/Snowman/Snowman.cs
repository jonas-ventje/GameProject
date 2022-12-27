using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.InputReaders;
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
    internal class Snowman : ControllableGravityObject, IAnimatable, IPacing, ISantaObserver {
        private ControllableGravityMovementManager movementManager;
        private Animation animation;
        private MovingDirection movingDirection = MovingDirection.Left;
        private MovableGameObject nearbyMovable;
        private bool santaMoved = false;

        public Snowman(Texture2D texture, int speed, int x, int y, MovableGameObject nearbyMovable, IObserverSubject subject) : base(texture, new Vector2(x, y), SnowmanFrames.idleFrames[0], speed) {
            inputReader = new InputReaderEmpty();
            movementManager = new ControllableGravityMovementManager();
            animation = new Animation(SnowmanFrames.idleFrames, 15);
            this.nearbyMovable = nearbyMovable;
            subject.RegisterObserver(this);
        }

        public override bool CanAccelerate => false;

        public Animation Animation => animation;

        public MovingDirection MovingDirection
        {
            get => movingDirection;
            set => movingDirection = value;
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (collisionObject is Santa.Santa && side != CollidingSide.Top)
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
            CheckAttackMode();
            //change inputreader when santa moved for the first time
            if(santaMoved && inputReader is InputReaderEmpty) inputReader = new InputReaderPacing(this);

            //check dead and otherwise update frame
            if (!(Animation.FrameList == SnowmanFrames.dyingFrames && frame == Animation.FrameList[Animation.FrameList.Count - 1]))
            {
                frame = animation.update(gameTime);
            }
            UpdateFrameList();

        }



        public override Rectangle IntersectionBlock
        {
            get
            {
                Rectangle rect = base.IntersectionBlock;
                rect.Y -= frame.Hitbox.Height;
                return rect;
            }
        }

        private void CheckAttackMode() {
            if (Vector2.Distance(nearbyMovable.IntersectionBlock.Center.ToVector2(), IntersectionBlock.Center.ToVector2()) < 750)
            {
                horizontalSpeed = 5;
                //currentMovingState = MovingState.Attacking;
            }
        }
        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y - frame.BoundingBox.Height), frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }

        private void UpdateFrameList() {
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                    Animation.updateFrameList(SnowmanFrames.idleFrames);
                    break;
                case MovingState.Jumping:
                    Animation.updateFrameList(SnowmanFrames.idleFrames);
                    break;
                case MovingState.Walking:
                    Animation.updateFrameList(SnowmanFrames.walkingFrames);
                    break;
                case MovingState.Dying:
                    Animation.updateFrameList(SnowmanFrames.dyingFrames);
                    break;
                case MovingState.Attacking:
                    Animation.updateFrameList(SnowmanFrames.attackFrames);
                    break;
                default:
                    break;
            }
        }

        public void update(bool santaMoved) {
            if (santaMoved)
            {
                this.santaMoved = true;
            }
        }
    }
}

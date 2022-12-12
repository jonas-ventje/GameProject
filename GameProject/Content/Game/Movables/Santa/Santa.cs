using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameProject.Content.Game.Movables.Santa {
    internal class Santa : IControllableGravityObject, IAnimatable {
        private List<Frame> activeFrameList;
        private Animation animation;
        private Frame activeFrame;
        private ControllableGravityMovementManager movementController;

        #region propperties
        private MovingState currentMovingState;
        private Texture2D texture;
        private Vector2 position;
        private SpriteEffects spriteDirection;
        private IInputReader inputReader;
        private int horizontalSpeed;
        private bool toBeRemoved = false;
        public MovingState CurrentMovingState
        {
            get => currentMovingState;
            set => currentMovingState = value;
        }
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
        public int HorizontalSpeed
        {
            get => horizontalSpeed;
            set => horizontalSpeed = value;
        }
        public SpriteEffects SpriteDirection
        {
            get => spriteDirection;
            set => spriteDirection = value;
        }

        public IInputReader InputReader => inputReader;
        public Frame ActiveFrame
        {
            get => activeFrame;
            set => activeFrame = value;
        }

        public Rectangle IntersectionBlock
        {
            get
            {
                if (SpriteDirection == SpriteEffects.FlipHorizontally)
                    //left = positionX + spritesheet width - hitbox.width - hitbox.left
                    return new Rectangle((int)position.X + activeFrame.BoundingBox.Width - activeFrame.Hitbox.Left - activeFrame.Hitbox.Width, (int)position.Y + activeFrame.Hitbox.Top, activeFrame.Hitbox.Width, activeFrame.Hitbox.Height);
                //left = positionX + left boundry
                return new Rectangle((int)position.X + activeFrame.Hitbox.Left, (int)position.Y + activeFrame.Hitbox.Top, activeFrame.Hitbox.Width, activeFrame.Hitbox.Height);
            }
        }

        public bool ToBeRemoved => toBeRemoved;
        #endregion

        public Santa(Texture2D texture, int speed, Vector2 position) {
            this.texture = texture;
            this.HorizontalSpeed = speed;
            this.Position = position;
            this.SpriteDirection = SpriteEffects.None;
            this.inputReader = new InputReaderKeyboard();
            movementController = new ControllableGravityMovementManager();
            activeFrameList = SantaFrames.idleFrames;
            animation = new Animation(activeFrameList, 15);
            activeFrame = activeFrameList[0];
        }
        public void CollisionEffect(IGameObject collisionObject, CollidingSide side) {
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
            List<Frame> prevFrameList = activeFrameList;
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                case MovingState.Jumping:
                    activeFrameList = SantaFrames.idleFrames;
                    break;
                case MovingState.Walking:
                    activeFrameList = SantaFrames.walkingFrames;
                    break;
                case MovingState.Dying:
                    activeFrameList = SantaFrames.dyingFrames;
                    break;
                default:
                    break;
            }
            if (prevFrameList != activeFrameList)
                animation.reset();
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }


        public void Update(GameTime gameTime) {
            Move(gameTime);
            activeFrame = animation.update(gameTime, activeFrameList);
            updateFrameList();
            //if below is true, santa is dead.
            if (activeFrameList == SantaFrames.dyingFrames && activeFrame == activeFrameList[activeFrameList.Count-1])
            {
                toBeRemoved = true;
            }
        }


    }

}

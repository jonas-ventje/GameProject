using GameProject.Content.Game.Movement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Diagnostics;

namespace GameProject.Content.Game.Santa {
    internal class Santa : IGameObject, IMovable {
        private List<Frame> activeFrameList;
        private Animation animation;
        private Frame activeFrame;
        private GravityMovementManager movementController;

        #region propperties
        private MovingState currentMovingState;
        private Texture2D texture;
        private Vector2 position;
        private SpriteEffects spriteDirection;
        private IInputReader inputReader;
        private int horizontalSpeed;
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
        #endregion

        public Santa(Texture2D texture, int speed) {
            this.texture = texture;
            this.HorizontalSpeed = speed;
            this.Position = new Vector2(0, 0);
            this.SpriteDirection = SpriteEffects.None;
            this.inputReader = new InputReaderKeyboard();
            movementController = new GravityMovementManager();
            activeFrameList = SantaFrames.idleFrames;
            animation = new Animation(activeFrameList, 15);
            activeFrame = activeFrameList[0];
        }

        private void Move(GameTime gameTime) {
            movementController.Move(this, gameTime);
        }

        private void updateAnimation() {
            List<Frame> prevFrameList = activeFrameList;
            switch (CurrentMovingState)
            {
                case MovingState.Idle: case MovingState.Jumping:
                    activeFrameList = SantaFrames.idleFrames;
                    break;
                case MovingState.Walking:
                    activeFrameList = SantaFrames.walkingFrames;
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
            updateAnimation();
        }
    }

}

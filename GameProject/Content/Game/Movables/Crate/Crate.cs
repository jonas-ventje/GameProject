using GameProject.Content.Game.Movement;
using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables.Crate {
    internal class Crate:IMovableGameObject {
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
        private int horizontalSpeed = 0;
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
                //position + left boundry, position + top boundry
                return new Rectangle((int)position.X + activeFrame.Hitbox.Left, (int)position.Y + activeFrame.Hitbox.Top, activeFrame.Hitbox.Width, activeFrame.Hitbox.Height);
            }
        }
        public bool ToBeRemoved => toBeRemoved;
        #endregion

        public Crate(Texture2D texture, int x, int y) {
            this.texture = texture;
            movementController = new GravityMovementManager();
            inputReader = new InputReaderGravity();
            activeFrameList = CrateFrames.idleFrames;
            spriteDirection = SpriteEffects.None;
            CurrentMovingState = MovingState.Idle;
            position = new Vector2(x, y);
            animation = new Animation(activeFrameList, 20);
            activeFrame = activeFrameList[0];
        }
        public void CollisionEffect(IGameObject collisionObject, CollidingSide side) {
            if (side == CollidingSide.Bottom && activeFrameList != CrateFrames.breakingFrames)
            {
                activeFrameList = CrateFrames.breakingFrames;
                animation.reset();
            }
        }

        private void Move(GameTime gameTime) {
            movementController.Move(this, gameTime);
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }


        public void Update(GameTime gameTime) {
            Move(gameTime);
            activeFrame = animation.update(gameTime, activeFrameList);
            if (activeFrame == CrateFrames.breakingFrames[CrateFrames.breakingFrames.Count - 1])
                toBeRemoved = true;
        }
    }
}

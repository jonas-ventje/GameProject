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

namespace GameProject.Content.Game.Movables.Crate
{
    internal class Crate:IMovableGameObject, IAnimatable {
        private List<Frame> activeFrameList;
        private Animation animation;
        private Frame activeFrame;
        private GravityMovementManager movementController;

        #region propperties
        private Texture2D texture;
        private Vector2 position;
        private bool toBeRemoved = false;
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
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
            activeFrameList = CrateFrames.idleFrames;
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
            spriteBatch.Draw(texture, position, activeFrame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteEffects.None, 1f);
        }


        public void Update(GameTime gameTime) {
            Move(gameTime);
            activeFrame = animation.update(gameTime, activeFrameList);
            if (activeFrame == CrateFrames.breakingFrames[CrateFrames.breakingFrames.Count - 1])
            {
                toBeRemoved = true;
                World.Tiles.Add(GameObjectFactory.CreateGameObject("cadeau", IntersectionBlock.Center.X, IntersectionBlock.Bottom - 150));
            }
        }
    }
}

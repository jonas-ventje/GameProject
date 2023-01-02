using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.Movement;
using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using GameProject.Content.Game.Movement.MovementManagers;

namespace GameProject.Content.Game.Movables.Crate
{
    internal class Crate : MovableGameObject, IAnimatable {
        private Animation animation;
        private GravityMovementManager movementController;
        private SoundEffect breakingSound;

        public Animation Animation => animation;

        public override bool CanAccelerate => false;

        public Crate(Texture2D texture, int x, int y, ContentManager content) : base(texture, new Vector2(x, y), CrateFrames.idleFrames[0]) {
            movementController = new GravityMovementManager();
            animation = new Animation(CrateFrames.idleFrames, 20, this);
            breakingSound = content.Load<SoundEffect>("./sounds/breaking_crate");
        }
        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (side == CollidingSide.Bottom && Animation.FrameList != CrateFrames.breakingFrames)
            {
                if (Animation.updateFrameList(CrateFrames.breakingFrames))
                    breakingSound.CreateInstance().Play();
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
            frame = animation.update(gameTime);
            if (frame == CrateFrames.breakingFrames[CrateFrames.breakingFrames.Count - 1])
            {
                toBeRemoved = true;
            }
        }
    }
}

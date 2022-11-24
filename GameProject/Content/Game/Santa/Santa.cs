using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace GameProject.Content.Game.Santa
{
    internal class Santa : IGameObject {
        private Texture2D texture;
        private Vector2 position;
        private IMovementController movementController;
        private SpriteEffects spriteEffect;
        private List<Frame> activeFrameList;
        private Animation animation;
        private Frame activeFrame;
        private Vector2 speed;


        public Santa(Texture2D texture, Vector2 speed) {
            this.texture = texture;
            this.speed = speed;
            position = new Vector2(0, 0);
            spriteEffect = SpriteEffects.None;
            movementController = new GravityMovementController(new InputReaderKeyboard(), speed);
            activeFrameList = SantaFrames.idleFrames;
            animation = new Animation(activeFrameList, 15);
            activeFrame = activeFrameList[0];
        }

        private void Move(GameTime gameTime) {
            Vector2 noCollisionMovement;
            Vector2 movement = movementController.Move(gameTime, activeFrame, position, spriteEffect, out noCollisionMovement);
            position += movement;

            //check which animation frame is required
            List<Frame> prevFrameList = activeFrameList;
            if (noCollisionMovement.X == 0)
                activeFrameList = SantaFrames.idleFrames;
            else if (noCollisionMovement.X != 0)
            {
                activeFrameList = SantaFrames.walkingFrames;
                if (noCollisionMovement.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                else
                    spriteEffect = SpriteEffects.None;
            }
            //activeFrames must be set to 0 again when animation changes because it does not have equal numbers of frames
            if (prevFrameList != activeFrameList)
                animation.reset();

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, spriteEffect, 1f);
        }


        public void Update(GameTime gameTime) {
            Move(gameTime);
            activeFrame = animation.update(gameTime, activeFrameList);
        }
    }

}

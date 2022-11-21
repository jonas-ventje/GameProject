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
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace GameProject.Content.Game.Santa
{
    internal class Santa : IGameObject {
        private Texture2D texture;
        private int activeFrame = 0;
        private double secondCounter;
        private int fps = 15;
        private Vector2 position;
        private IMovementController movementController;
        private SpriteEffects spriteEffect;
        private List<Frame> activeFrameList;


        public Santa(Texture2D texture, Vector2 speed) {
            this.texture = texture;
            position = new Vector2(0, 0);
            spriteEffect = SpriteEffects.None;
            movementController = new MovementControllerSanta(new InputReaderKeyboard(), speed);
            activeFrameList = SantaFrames.idleFrames;
        }

        private void Move(GameTime gameTime) {
            Vector2 movement = movementController.Move(gameTime, ref activeFrameList, ref activeFrame, ref spriteEffect, position);
            position += movement;


/*            //check which animation frame is required
            List<SantaFrame> prevFrameList = activeFrameList;
            if (movement.X == 0)
                activeFrameList = SantaFrames.idleFrames;
            else if (movement.X != 0)
            {
                activeFrameList = SantaFrames.walkingFrames;
                if (movement.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                else
                    spriteEffect = SpriteEffects.None;
            }
            //activeFrames must be set to 0 again when animation changes because it does not have equal numbers of frames
            if (prevFrameList != activeFrameList)
                activeFrame = 0;*/


        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrameList[activeFrame].BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, spriteEffect, 1f);
        }


        public void Update(GameTime gameTime) {
            Move(gameTime);
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (secondCounter >= 1d / fps)
            {
                activeFrame++;
                secondCounter = 0;
            }
            if (activeFrame >= activeFrameList.Count)
                activeFrame = 0;
        }
    }

}

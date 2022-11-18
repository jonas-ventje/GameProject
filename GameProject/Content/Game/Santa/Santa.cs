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

namespace GameProject.Content.Game.Santa {
    internal class Santa : IGameObject {
        private Texture2D texture;
        private int activeFrame = 0;
        private double secondCounter;
        private int fps = 15;
        private Vector2 position;
        private IMovementController movementController;
        private SpriteEffects spriteEffect;
        private List<SantaFrame> activeFrameList;
/*        private float gravityAcceleration = 9f;
        private bool isInTheAir = false;
        private double gravityPhysicsTime = 0;
        float verticalSpeedAtFire = 0;*/


        public Santa(Texture2D texture, Vector2 speed) {
            this.texture = texture;
            position = new Vector2(0, 0);
            spriteEffect = SpriteEffects.None;
            movementController = new MovementControllerSanta(new InputReaderKeyboard(), speed);
            activeFrameList = SantaFrames.idleFrames;
        }

        private void Move(GameTime gameTime) {
/*        
            if (Math.Abs(actualMovement.Y) < Math.Abs(movement.Y))
            {

                isInTheAir = false;
            }
            
            else
                isInTheAir = true;

            if (state.IsKeyDown(Keys.Space))
            {
                verticalSpeedAtFire = -5.5f;
                isInTheAir = true;
            }*/


            position += movementController.Move(gameTime, activeFrameList[activeFrame], spriteEffect, position);


/*            //check which animation frame is required
            if (movement.X == 0)
                activeFrameList = SantaFrames.idleFrames;
            else if (movement.X != 0 && movement.Y == verticalSpeed * speed.Y)
            {
                activeFrameList = SantaFrames.walkingFrames;
                if (movement.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                else
                    spriteEffect = SpriteEffects.None;
            }
            //activeFrames must be set to 0 again when animation changes because it does not have equal numbers of frames
            if (prevFrameList != activeFrameList)
                activeFrame = 0;
*/

        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrameList[activeFrame].BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, spriteEffect, 1f);
        }


        public void Update(GameTime gameTime) {
/*            float verticalSpeed = 1;
            if (isInTheAir)
            {
                gravityPhysicsTime += gameTime.ElapsedGameTime.TotalSeconds;
                verticalSpeed += gravityAcceleration * (float)gravityPhysicsTime + verticalSpeedAtFire;
            }
            else
            {
                gravityPhysicsTime = 0;               
                //for falling without jump, there must be no start velocity
                verticalSpeedAtFire = 0;
            }*/

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

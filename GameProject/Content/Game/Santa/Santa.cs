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
        private Vector2 speed;
        private SpriteEffects spriteEffect;
        private List<SantaFrame> activeFrameList;

        public Santa(Texture2D texture, Vector2 speed) {
            this.texture = texture;
            position = new Vector2(0, 0);
            spriteEffect = SpriteEffects.None;

            this.speed = speed;

            activeFrameList = SantaFrames.idleFrames;
        }

        private void move() {
            KeyboardState state = Keyboard.GetState();
            var movement = new Vector2(0, 0);
            var prevFrameList = activeFrameList;
            if (state.IsKeyDown(Keys.Left))
                movement.X -= 1;
            if (state.IsKeyDown(Keys.Right))
                movement.X += 1;
            if (state.IsKeyDown(Keys.Up))
                movement.Y -= 1;
            if (state.IsKeyDown(Keys.Down))
                movement.Y += 1;

            movement *= speed;
            Vector2 actualMovement = CollisionController.calculatePossibleMovement(activeFrameList[activeFrame], spriteEffect, position, movement);

            position += actualMovement;


            //check which animation frame is required
            if (movement == Vector2.Zero)
                activeFrameList = SantaFrames.idleFrames;
            else if (movement.X != 0 && movement.Y == 0)
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


        }

        public void draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, activeFrameList[activeFrame].BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, spriteEffect, 1f);
        }


        public void update(GameTime gameTime) {
            move();
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

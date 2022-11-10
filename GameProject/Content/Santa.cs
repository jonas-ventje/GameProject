using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct2D1.Effects;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content {
    internal class Santa : IGameObject {
        private Texture2D texture;
        private List<Rectangle> idleFrames;
        private List<Rectangle> walkingFrames;
        private List<Rectangle> activeFrameList;
        private int activeFrame = 0;
        private double secondCounter;
        private int fps = 15;
        private Vector2 position;
        private Vector2 speed;
        private SpriteEffects spriteEffect;

        public Santa(Texture2D texture, Vector2 speed) {
            this.texture = texture;
            position = new Vector2(0, 0);
            spriteEffect = SpriteEffects.None;
            idleFrames = new List<Rectangle>();
            walkingFrames = new List<Rectangle>();

            //find idle frames in spritesheet
            for (int i = 17; i < 17 + 16; i++)
                idleFrames.Add(spritePositionToRectangle(256, 176, 8, i));

            //find walking frames in spritesheet
            for (int i = 71; i < 71 + 13; i++)
                walkingFrames.Add(spritePositionToRectangle(256, 176, 8, i));

            activeFrameList = idleFrames;

            this.speed = speed;


        }
        private Rectangle spritePositionToRectangle(int spriteWidth, int spriteHeigh, int numberHorizontal, int position) {
            int startPixelHorizontal = spriteWidth * (position % numberHorizontal);
            int startPixelVertical = spriteHeigh * (position / numberHorizontal);
            return new Rectangle(startPixelHorizontal, startPixelVertical, spriteWidth, spriteHeigh);
        }

        private void move() {
            KeyboardState state = Keyboard.GetState();
            var direction = Vector2.Zero;
            var prevFrameList = activeFrameList;
            if (state.IsKeyDown(Keys.Left))
                direction.X -= 1;
            if (state.IsKeyDown(Keys.Right))
                direction.X += 1;

            //check which animation frame is required
            if (direction == Vector2.Zero)
                activeFrameList = idleFrames;
            else if (direction.X != 0 && direction.Y == 0)
            {
                activeFrameList = walkingFrames;
                if (direction.X < 0)
                    spriteEffect = SpriteEffects.FlipHorizontally;
                else
                    spriteEffect = SpriteEffects.None;
            }
            //activeFrames must be set to 0 again when animation changes because it does not have equal numbers of frames
            if (prevFrameList != activeFrameList)
                activeFrame = 0;
            direction *= speed;
            position += direction;

        }

        public void draw(SpriteBatch spriteBatch) {
            move();
            spriteBatch.Draw(texture, position, activeFrameList[activeFrame], Color.White, 0f, new Vector2(0, 0), 1f, spriteEffect, 1f);
        }

        public void update(GameTime gameTime) {
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

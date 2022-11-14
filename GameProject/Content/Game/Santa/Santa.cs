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
            var direction = new Vector2(0, 1);
            var prevFrameList = activeFrameList;
            if (state.IsKeyDown(Keys.Left))
                direction.X -= 1;
            if (state.IsKeyDown(Keys.Right))
                direction.X += 1;

            direction *= speed;
            Vector2 acturalMovement = checkCollisions(direction);
            position += (acturalMovement);


            //check which animation frame is required
            if (direction == Vector2.Zero)
                activeFrameList = SantaFrames.idleFrames;
            else if (direction.X != 0 && direction.Y == 0)
            {
                activeFrameList = SantaFrames.walkingFrames;
                if (direction.X < 0)
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
        private Rectangle hitboxRectangle(Rectangle hitbox, Vector2 movement) {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                //left = positionX + spritesheet width - hitbox.width - hitbox.left
                return new Rectangle((int)(position + movement).X + activeFrameList[activeFrame].BoundingBox.Width - hitbox.Left - hitbox.Width, (int)(position + movement).Y, hitbox.Width, hitbox.Height);
            //left = positionX + left boundry
            return new Rectangle((int)(position + movement).X + hitbox.Left, (int)(position + movement).Y, hitbox.Width, hitbox.Height);
        }
        private Vector2 intersectionDepth(Rectangle rect1, Rectangle rect2) {
            // no intersection --> return no depth vector
            if (!rect1.Intersects(rect2))
                return Vector2.Zero;

            // calc half sizes.
            float halfWidth1 = rect1.Width / 2.0f;
            float halfHeight1 = rect1.Height / 2.0f;
            float halfWidth2 = rect2.Width / 2.0f;
            float halfHeight2 = rect2.Height / 2.0f;

            // center distances and width, height when no intercection
            float distanceX = rect1.Left + halfWidth1 - (rect2.Left + halfWidth2);
            float distanceY = rect1.Top + halfHeight1 - (rect2.Top + halfHeight2);
            float totalWidthBoth = halfWidth1 + halfWidth2;
            float toalHeightBoth = halfHeight1 + halfHeight2;

            // Calculate and return intersection depths.
            float depthX = distanceX > 0 ? totalWidthBoth - distanceX : -totalWidthBoth - distanceX;
            float depthY = distanceY > 0 ? toalHeightBoth - distanceY : -toalHeightBoth - distanceY;
            return new Vector2(depthX, depthY);
        }
        private Vector2 maxIntersectionMultipleHitboxes(Block b, Vector2 movement) {
            Vector2 maxIntersection = Vector2.Zero;
            foreach (Rectangle hitbox in activeFrameList[activeFrame].Hitbox)
            {
                Rectangle positionRectangle = hitboxRectangle(hitbox, movement);
                Debug.WriteLine(positionRectangle);
                Vector2 intersection = intersectionDepth(b.IntersectionBlock, positionRectangle);
                if (Math.Abs(intersection.X) > Math.Abs(maxIntersection.X))
                    maxIntersection.X = intersection.X;
                if (Math.Abs(intersection.Y) > Math.Abs(maxIntersection.Y))
                    maxIntersection.Y = intersection.Y;
            }
            return maxIntersection;
        }
        private Vector2 checkCollisions(Vector2 movement) {
            Vector2 undoMovement = new Vector2();
            foreach (Block b in Block.Blocks)
            {
                Vector2 maxIntersection = maxIntersectionMultipleHitboxes(b, movement);
                if (maxIntersection == Vector2.Zero)
                    continue;
                //not a clean stattement in the if's
                else if (Math.Abs(maxIntersection.X) < Math.Abs(maxIntersection.Y))
                {
                    //move X-axis
                    Debug.WriteLine($"shift X {maxIntersection}");
                    if (undoMovement.X < maxIntersection.X)
                        undoMovement.X = maxIntersection.X;
                }
                else if (Math.Abs(maxIntersection.X) >= Math.Abs(maxIntersection.Y))
                {
                    //move Y-axis
                    Debug.WriteLine($"shift Y {maxIntersection}");
                    if (undoMovement.Y < maxIntersection.Y)
                        undoMovement.Y = maxIntersection.Y;

                }
            }
            return new Vector2(movement.X - undoMovement.X, movement.Y - undoMovement.Y);

        }
    }

}

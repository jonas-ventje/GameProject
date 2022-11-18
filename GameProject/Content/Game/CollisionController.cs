using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal static class CollisionController {
        private static Rectangle HitboxRectangle(SantaFrame frame, SpriteEffects spriteEffect, Rectangle hitbox, Vector2 position) {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                //left = positionX + spritesheet width - hitbox.width - hitbox.left
                return new Rectangle((int)position.X + frame.BoundingBox.Width - hitbox.Left - hitbox.Width, (int)position.Y + hitbox.Top, hitbox.Width, hitbox.Height);
            //left = positionX + left boundry
            return new Rectangle((int)position.X + hitbox.Left, (int)position.Y + hitbox.Top, hitbox.Width, hitbox.Height);
        }
        private static Vector2 IntersectionDepth(Rectangle rect1, Rectangle rect2) {
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
        public static Vector2 CalculateAvailableMovement(SantaFrame frame, SpriteEffects spriteEffect, Vector2 position, Vector2 movement) {
            Vector2 undoMovement = new Vector2();
            foreach (Block b in Block.Blocks)
            {
                List<Rectangle> collided = frame.Hitbox.Select(hitbox => HitboxRectangle(frame, spriteEffect, hitbox, position + movement)).Where(intersectionBox => b.IntersectionBlock.Intersects(intersectionBox)).ToList();
                foreach (Rectangle c in collided)
                {
                    Vector2 intersection = IntersectionDepth(b.IntersectionBlock, c);
                    if (Math.Abs(intersection.Y) < Math.Abs(intersection.X))
                        if (Math.Abs(intersection.Y) > Math.Abs(undoMovement.Y))
                            undoMovement.Y = intersection.Y;
                        else
                            continue;
                    else
                        if (Math.Abs(intersection.X) > Math.Abs(undoMovement.X))
                        undoMovement.X = intersection.X;
                }
            }
            return new Vector2(movement.X - undoMovement.X, movement.Y - undoMovement.Y);

        }
    }
}

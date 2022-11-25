using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameProject.Content.Game {
    public enum CollidingSide { Top, Bottom, Left, Right, None };
    internal static class CollisionController {
        private static Rectangle HitboxRectangle(Frame frame, SpriteEffects spriteEffect, Rectangle hitbox, Vector2 position) {
            if (spriteEffect == SpriteEffects.FlipHorizontally)
                //left = positionX + spritesheet width - hitbox.width - hitbox.left
                return new Rectangle((int)position.X + frame.BoundingBox.Width - hitbox.Left - hitbox.Width, (int)position.Y + hitbox.Top, hitbox.Width, hitbox.Height);
            //left = positionX + left boundry
            return new Rectangle((int)position.X + hitbox.Left, (int)position.Y + hitbox.Top, hitbox.Width, hitbox.Height);
        }
        public static Vector2 CollisionDepth(Frame frame, SpriteEffects spriteEffect, Vector2 position, Vector2 movement, Rectangle collisionObject, out CollidingSide where) {
            where = CollidingSide.None;
            Rectangle collidedHitbox = frame.Hitbox.FirstOrDefault(hitbox => collisionObject.Intersects(HitboxRectangle(frame, spriteEffect, hitbox, position + movement)));
            if (collidedHitbox == default(Rectangle))
                return Vector2.Zero;
            Rectangle collided = HitboxRectangle(frame, spriteEffect, collidedHitbox, position);
            Rectangle movedRectangle = HitboxRectangle(frame, spriteEffect, collidedHitbox, position + movement);

            if (collisionObject.Right > collided.Left + movement.X &&
                collisionObject.Left < collided.Left &&
                collisionObject.Bottom > collided.Top &&
                collisionObject.Top < collided.Bottom)
            {
                //collision left, a 
                where = CollidingSide.Left;
                return new Vector2(movedRectangle.Left - collisionObject.Right,0);
            }
            else if (collisionObject.Left < collided.Right + movement.X &&
                collisionObject.Right > collided.Right &&
                collisionObject.Bottom > collided.Top &&
                collisionObject.Top < collided.Bottom)
            {
                //collision right
                where = CollidingSide.Right;
                return new Vector2(movedRectangle.Right - collisionObject.Left, 0);
            }
            else if (collisionObject.Bottom > collided.Top + movement.Y &&
                collisionObject.Top < collided.Top &&
                collisionObject.Right > collided.Left &&
                collisionObject.Left < collided.Right)
            {
                //collision top
                where = CollidingSide.Top;
                return new Vector2(0, movedRectangle.Top - collisionObject.Bottom);
            }
            else if (collisionObject.Top < collided.Bottom + movement.Y &&
                collisionObject.Bottom > collided.Bottom &&
                collisionObject.Right > collided.Left &&
                collisionObject.Left < collided.Right)
            {
                //collision bottom
                where = CollidingSide.Bottom;
                return new Vector2(0, movedRectangle.Bottom - collisionObject.Top);
            }
            return Vector2.Zero;
        }
        public static Vector2 CollisionDepth(Frame frame, SpriteEffects spriteEffect, Vector2 position, Vector2 movement, Rectangle collisionObject) {
            CollidingSide where;
            return CollisionDepth(frame, spriteEffect, position, movement, collisionObject, out where); 
        }
    }
}

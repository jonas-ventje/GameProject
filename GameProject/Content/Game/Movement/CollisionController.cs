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
        public static Vector2 CollisionDepth(Rectangle referenceObject, Rectangle collisionObject, Vector2 movement, out CollidingSide where) {
            where = CollidingSide.None;
            Rectangle movedReferenceObject = new Rectangle(referenceObject.Left + (int)movement.X, referenceObject.Top + (int)movement.Y, referenceObject.Width, referenceObject.Height);
            if (!collisionObject.Intersects(movedReferenceObject))
                return Vector2.Zero;

            else if (collisionObject.Right > referenceObject.Left + movement.X &&
                collisionObject.Left < referenceObject.Left &&
                collisionObject.Bottom > referenceObject.Top &&
                collisionObject.Top < referenceObject.Bottom)
            {
                //collision left, a 
                where = CollidingSide.Left;
                return new Vector2(movedReferenceObject.Left - collisionObject.Right, 0);
            }
            else if (collisionObject.Left < referenceObject.Right + movement.X &&
                collisionObject.Right > referenceObject.Right &&
                collisionObject.Bottom > referenceObject.Top &&
                collisionObject.Top < referenceObject.Bottom)
            {
                //collision right
                where = CollidingSide.Right;
                return new Vector2(movedReferenceObject.Right - collisionObject.Left, 0);
            }
            else if (collisionObject.Bottom > referenceObject.Top + movement.Y &&
                collisionObject.Top < referenceObject.Top &&
                collisionObject.Right > referenceObject.Left &&
                collisionObject.Left < referenceObject.Right)
            {
                //collision top
                where = CollidingSide.Top;
                return new Vector2(0, movedReferenceObject.Top - collisionObject.Bottom);
            }
            else if (collisionObject.Top < referenceObject.Bottom + movement.Y &&
                collisionObject.Bottom > referenceObject.Bottom &&
                collisionObject.Right > referenceObject.Left &&
                collisionObject.Left < referenceObject.Right)
            {
                //collision bottom
                where = CollidingSide.Bottom;
                return new Vector2(0, movedReferenceObject.Bottom - collisionObject.Top);
            }
            return Vector2.Zero;
        }
        public static Vector2 CollisionDepth(Rectangle referenceObject, Rectangle collisionObject, Vector2 movement) {
            CollidingSide where;
            return CollisionDepth(referenceObject, collisionObject, movement, out where);
        }
    }
}

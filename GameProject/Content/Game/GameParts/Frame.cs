using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameParts
{
    internal class Frame
    {

        private Rectangle boundingBox;
        private Rectangle hitbox;

        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
        }


        public Rectangle Hitbox
        {
            get
            {
                return hitbox;
            }
        }
        public Frame(Rectangle boundingBox, Rectangle hitbox)
        {
            this.boundingBox = boundingBox;
            this.hitbox = hitbox;
        }
        /// <summary>
        /// boundingbox equal to hitbox or no hitbox
        /// </summary>
        /// <param name="boundingBox"></param>
        public Frame(Rectangle boundingBox, bool hasHitbox = true)
        {
            this.boundingBox = boundingBox;
            if (hasHitbox)
                hitbox = new Rectangle(0, 0, boundingBox.Width, boundingBox.Height);
            else
                hitbox = Rectangle.Empty;
        }
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game
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
        public Frame(Rectangle boundingBox) {
            this.boundingBox = boundingBox;
            this.hitbox = new Rectangle(0,0,boundingBox.Width, boundingBox.Height);
        }
    }
}

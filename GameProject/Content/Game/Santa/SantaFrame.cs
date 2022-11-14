using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Santa
{
    internal class SantaFrame
    {

        private Rectangle boundingBox;
        private List<Rectangle> fatalHitbox;
        private List<Rectangle> hitbox;

        public Rectangle BoundingBox
        {
            get
            {
                return boundingBox;
            }
        }


        public List<Rectangle> FatalHitbox
        {
            get
            {
                return fatalHitbox;
            }
        }


        public List<Rectangle> Hitbox
        {
            get
            {
                return hitbox;
            }
        }
        public SantaFrame(Rectangle boundingBox, List<Rectangle> fatalHitbox, List<Rectangle> hitbox) {
            this.boundingBox = boundingBox;
            this.fatalHitbox = fatalHitbox;
            this.hitbox = hitbox;
        }
    }
}

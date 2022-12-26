using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects {
    internal abstract class GameObject {
        protected Texture2D texture;
        protected bool toBeRemoved = false;
        protected Vector2 position;
        protected Frame frame;

        /// <summary>
        /// the rectangle with position etc included. The rectangle in the screen where colision is posible
        /// </summary>
        public virtual Rectangle IntersectionBlock
        {
            get
            {
                if (frame.Hitbox.IsEmpty)
                    return Rectangle.Empty;
                //position + left boundry, position + top boundry
                return new Rectangle((int)position.X + frame.Hitbox.Left, (int)position.Y + frame.Hitbox.Top, frame.Hitbox.Width, frame.Hitbox.Height);

            }
        }

        /// <summary>
        /// does the gameobject need to be removed next render
        /// </summary>
        public bool ToBeRemoved
        {
            get => toBeRemoved;
            set => toBeRemoved = value;
        }

        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
        public Frame Frame
        {
            get => frame;
        }
        /// <summary>
        /// with predefined frame
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="frame"></param>
        public GameObject(Texture2D texture, Vector2 position, Frame frame) {
            this.texture = texture;
            this.toBeRemoved = false;
            this.position = position;
            this.frame = frame;
        }
        /// <summary>
        /// without frame. Frame is the texture
        /// </summary>
        /// <param name="texture"></param>
        /// <param name="position"></param>
        /// <param name="frame"></param>
        public GameObject(Texture2D texture, Vector2 position, bool hasHitbox) 
            :this(texture, position, new Frame(new Rectangle(0, 0, texture.Width, texture.Height), hasHitbox)) { 
        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, frame.BoundingBox, Color.White);
        }

    }
}

using GameProject.Content.Game.InputReaders;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{
    internal abstract class ControllableObject : MovableGameObject {

        protected SpriteEffects spriteDirecton;
        protected int horizontalSpeed;
        protected IInputReader inputReader;

        public ControllableObject(Texture2D texture, Vector2 position, Frame frame, int horizontalSpeed) : base(texture, position, frame) {
            spriteDirecton = SpriteEffects.None;
            this.horizontalSpeed = horizontalSpeed;
        }
        public ControllableObject(Texture2D texture, Vector2 position, bool hasHitbox, int horizontalSpeed)
            : this(texture, position, new Frame(new Rectangle(0, 0, texture.Width, texture.Height), hasHitbox), horizontalSpeed) {
        }
        public IInputReader InputReader
        {
            get => inputReader;
        }
        public SpriteEffects SpriteDirection
        {
            get => spriteDirecton; set => spriteDirecton = value;
        }
        public int Speed
        {
            get => horizontalSpeed; set => horizontalSpeed = value;
        }
        public override Rectangle IntersectionBlock
        {
            get
            {
                if (frame.Hitbox.IsEmpty)
                    return Rectangle.Empty;
                if (SpriteDirection == SpriteEffects.FlipHorizontally)
                    //left = positionX + spritesheet width - hitbox.width - hitbox.left
                    return new Rectangle((int)position.X + frame.BoundingBox.Width - frame.Hitbox.Left - frame.Hitbox.Width, (int)position.Y + frame.Hitbox.Top, frame.Hitbox.Width, frame.Hitbox.Height);
                //left = positionX + left boundry
                return new Rectangle((int)position.X + frame.Hitbox.Left, (int)position.Y + frame.Hitbox.Top, frame.Hitbox.Width, frame.Hitbox.Height);
            }
        }

    }
}

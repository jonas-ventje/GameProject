using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movement.MovementManagers;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables
{
    internal class SnowmanSled : IControllableObject {
        private Texture2D texture;
        private Vector2 position;
        private int horizontalSpeed;
        private SpriteEffects spriteDirection;
        private IInputReader inputReader;
        private ControllableNonGravityMovementManager movementManager = new ControllableNonGravityMovementManager();

        public IInputReader InputReader => inputReader;

        public SpriteEffects SpriteDirection
        {
            get => spriteDirection;
            set => spriteDirection = value;
        }
        public int HorizontalSpeed
        {
            get => horizontalSpeed;
            set => horizontalSpeed = value;
        }
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
        public Rectangle IntersectionBlock => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        public bool ToBeRemoved => false;

        public SnowmanSled(Texture2D texture, Vector2 position, Santa.Santa santa, int horizontalSpeed) {
            this.texture = texture;
            this.position = position;
            this.inputReader = new InputReaderFolowMovableX(santa, this);
            this.horizontalSpeed = horizontalSpeed;
        }

        public void CollisionEffect(IGameObject collisionObject, CollidingSide side) {
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update(GameTime gameTime) {
            movementManager.Move(this, gameTime);
        }
    }
}

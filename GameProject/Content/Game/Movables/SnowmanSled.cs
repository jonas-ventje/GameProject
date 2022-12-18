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

namespace GameProject.Content.Game.Movables {
    internal class SnowmanSled : ControllableObject {
        private const int minDropInterval = 5;
        private const int maxDropInterval = 10;

        private ControllableNonGravityMovementManager movementManager = new ControllableNonGravityMovementManager();
        private double dropInterval;
        private double elapsedDropInterval;

        //public Rectangle IntersectionBlock => new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

        private void calcDropInterval() {
            Random rand = new Random();
            dropInterval = minDropInterval + rand.NextDouble()*(maxDropInterval-minDropInterval);
            elapsedDropInterval = 0;
        }

        public SnowmanSled(Texture2D texture, int x, int y, Santa.Santa santa, int horizontalSpeed):base(texture, new Vector2(x,y), false, horizontalSpeed) {
            calcDropInterval();
            this.inputReader = new InputReaderFolowMovableX(santa, this);
            this.horizontalSpeed = horizontalSpeed;
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);

            Texture2D _pointTexture;
            _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _pointTexture.SetData<Color>(new Color[] { Color.DeepSkyBlue });
            spriteBatch.Draw(_pointTexture, new Rectangle((int)position.X + 49, (int)position.Y + 11, (int)(211*(elapsedDropInterval/dropInterval)), 11), Color.White);
        }

        public override void Update(GameTime gameTime) {
            movementManager.Move(this, gameTime);

            elapsedDropInterval += gameTime.ElapsedGameTime.TotalSeconds;
            if (elapsedDropInterval >= dropInterval)
            {
                calcDropInterval();
                World.Tiles.Add(GameObjectFactory.CreateGameObject("crate", frame.BoundingBox.Center.X-50, frame.BoundingBox.Bottom));
            }
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }
    }
}

﻿using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movement.MovementManagers;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Content.Game.Screens;
using GameProject.Content.Game.InputReaders;
using GameProject.Content.Game.GameParts;

namespace GameProject.Content.Game.Movables
{
    internal class SnowmanSled : ControllableObject, ISantaObserver {
        private const int minDropInterval = 2;
        private const int maxDropInterval = 10;

        private ControllableNonGravityMovementManager movementManager = new ControllableNonGravityMovementManager();
        private double dropInterval;
        private double elapsedDropInterval;
        private bool santaMoved = false;

        public override bool CanAccelerate => false;

        private void calcDropInterval() {
            Random rand = new Random();
            dropInterval = minDropInterval + rand.NextDouble() * (maxDropInterval - minDropInterval);
            elapsedDropInterval = 0;
        }

        public SnowmanSled(Texture2D texture, int x, int y, Santa.Santa santa, int horizontalSpeed, IObserverSubject subject) : base(texture, new Vector2(x, y), false, horizontalSpeed) {
            this.inputReader = new InputReaderFolowMovableX(santa, this);
            this.horizontalSpeed = horizontalSpeed;
            subject.RegisterObserver(this);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, Color.White);

            Texture2D _pointTexture;
            _pointTexture = new Texture2D(spriteBatch.GraphicsDevice, 1, 1);
            _pointTexture.SetData<Color>(new Color[] { Color.DeepSkyBlue });
            spriteBatch.Draw(_pointTexture, new Rectangle((int)position.X + 49, (int)position.Y + 11, (int)(211 * (elapsedDropInterval / dropInterval)), 11), Color.White);
        }

        public override void Update(GameTime gameTime) {
            movementManager.Move(this, gameTime);
            if (santaMoved)
            {
                elapsedDropInterval += gameTime.ElapsedGameTime.TotalSeconds;
                if (elapsedDropInterval >= dropInterval)
                {
                    calcDropInterval();
                    World.Tiles.Add(GameObjectFactory.CreateGameObject("crate", (int)Position.X + frame.BoundingBox.Center.X - 50, (int)position.Y + frame.BoundingBox.Bottom));
                }
            }
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }

        public void update(bool santaMoved) {
            if (santaMoved)
            {
                this.santaMoved = true;
                calcDropInterval();
            }
        }
    }
}

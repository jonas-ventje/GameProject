using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables
{
    internal class Cadeau : IMovableGameObject {
        private Texture2D texture;
        private Vector2 position;
        private bool toBeRemoved;
        private int bouncePosition = 0;
        private int fps = 15;
        private const int bounceLength = 20;
        public Cadeau(Texture2D texture, int x, int y) {
            this.texture = texture;
            this.position = new Vector2(x,y);
            Random rand = new Random();
            this.bouncePosition = rand.Next(-bounceLength, bounceLength+1);
        }

        public Rectangle IntersectionBlock => new Rectangle((int)position.X, (int)position.Y+bouncePosition, 91, 128);
        public Vector2 Position
        {
            get => position;
            set => position = value;
        }
        public bool ToBeRemoved
        {
            get => toBeRemoved;
            set => toBeRemoved = value;
        }

        public void Update(GameTime gameTime) {
            bouncePosition = (int)(bounceLength * Math.Sin(gameTime.TotalGameTime.TotalSeconds*3));
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y+bouncePosition), Color.White * .9f);
        }

        public void CollisionEffect(IGameObject collisionObject, CollidingSide side) {
            throw new NotImplementedException();
        }
    }
}

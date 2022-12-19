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
    internal class Cadeau : MovableGameObject {
        private int bouncePosition = 0;
        private const int bounceLength = 20;

        public override bool CanAccelerate => false;

        public Cadeau(Texture2D texture, int x, int y):base(texture, new Vector2(x,y), true)  {
            Random rand = new Random();
            this.bouncePosition = rand.Next(-bounceLength, bounceLength+1);
        }

        //public Rectangle IntersectionBlock => new Rectangle((int)position.X, (int)position.Y+bouncePosition, 91, 128);

        public override void Update(GameTime gameTime) {
            bouncePosition = (int)(bounceLength * Math.Sin(gameTime.TotalGameTime.TotalSeconds*3));
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y+bouncePosition), Color.White * .9f);
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }
    }
}

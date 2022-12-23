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
    internal class Gift : MovableGameObject {
        private int bouncePosition = 0;
        private const int bounceLength = 20;
        private int offsetX;

        public override bool CanAccelerate => false;

        public Gift(Texture2D texture, int x, int y):base(texture, new Vector2(x,y), true)  {
            offsetX = Game1.rand.Next(0, 360);
        }

        public override void Update(GameTime gameTime) {
            bouncePosition = (int)(bounceLength * Math.Sin(gameTime.TotalGameTime.TotalSeconds*3 + offsetX));
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, new Vector2(position.X, position.Y+bouncePosition), Color.White * .9f);
        }

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }
    }
}

using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables {
    internal class SantaSled : MovableGameObject {
        public SantaSled(Texture2D texture, int x, int y, Frame frame) : base(texture, new Vector2(x,y), frame) {
        }

        public override bool CanAccelerate => false;

        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            //throw new NotImplementedException();
        }

        public override void Update(GameTime gameTime) {
            //throw new NotImplementedException();
        }
    }
}

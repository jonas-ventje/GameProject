using GameProject.Content.Game.GameParts;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{
    internal abstract class MovableGameObject : GameObject {
        public abstract bool CanAccelerate
        {
            get;
        }
        public MovableGameObject(Texture2D texture, Vector2 position, Frame frame) : base(texture, position, frame) {
        }
        public MovableGameObject(Texture2D texture, Vector2 position, bool hasHitbox)
            : this(texture, position, new Frame(new Rectangle(0, 0, texture.Width, texture.Height), hasHitbox)) {
        }
        public abstract void Update(GameTime gameTime);
        public abstract void CollisionEffect(GameObject collisionObject, CollidingSide side);

    }
}

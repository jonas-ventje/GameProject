using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{
    internal interface IMovableGameObject : IGameObject
    {
        public Vector2 Position
        {
            get; set;
        }
        void Update(GameTime gameTime);
        void CollisionEffect(IGameObject collisionObject, CollidingSide side);

    }
}

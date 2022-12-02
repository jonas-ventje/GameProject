using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{
    internal interface IGameObject
    {
        void Draw(SpriteBatch spriteBatch);
        public Rectangle IntersectionBlock
        {
            get;
        }
        public bool ToBeRemoved
        {
            get;
        }

    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{


    internal interface IControllableObject : IMovableGameObject
    {
        public IInputReader InputReader
        {
            get;
        }
        public SpriteEffects SpriteDirection
        {
            get; set;
        }
        public int HorizontalSpeed
        {
            get; set;
        }
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movement {
    enum MovingState {Idle, Walking, Jumping }
    internal interface IMovable {
        public MovingState CurrentMovingState
        {
            get; set;
        }
        public Vector2 Position
        {
            get; set;
        }
        public int HorizontalSpeed
        {
            get; set;
        }
        public IInputReader InputReader
        {
            get;
        }
        public SpriteEffects SpriteDirection
        {
            get; set;
        }
        public Frame ActiveFrame
        {
            get; set;
        }
    }
}

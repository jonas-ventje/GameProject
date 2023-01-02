using GameProject.Content.Game.Movement;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.InputReaders
{
    internal class InputReaderPacing : IInputReader
    {
        private IPacing movable;
        public InputReaderPacing(IPacing movable)
        {
            this.movable = movable;
        }

        public Vector2 ReadInput()
        {
            if (movable.MovingDirection == MovingDirection.Left)
                return new Vector2(-1, 0);
            else if (movable.MovingDirection == MovingDirection.Right)
                return new Vector2(1, 0);
            return Vector2.Zero;
        }
    }
}

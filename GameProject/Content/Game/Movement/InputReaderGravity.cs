using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movement {
    internal class InputReaderGravity : IInputReader {
        public Vector2 ReadInput() {
            return new Vector2(0, 1);
        }
    }
}

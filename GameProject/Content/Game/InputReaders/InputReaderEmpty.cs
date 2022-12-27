using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.InputReaders {
    internal class InputReaderEmpty : IInputReader {
        public Vector2 ReadInput() {
            return Vector2.Zero;
        }
    }
}

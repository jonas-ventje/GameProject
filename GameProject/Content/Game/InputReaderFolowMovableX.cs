using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class InputReaderFolowMovableX : IInputReader {

        private IMovableGameObject movable;
        private IControllableObject reference;
        public InputReaderFolowMovableX(IMovableGameObject movable, IControllableObject reference) {
            this.movable = movable;
            this.reference = reference;
        }

        public Vector2 ReadInput() {
            int referenceCenter = reference.IntersectionBlock.Center.X;
            int movableCenter = movable.IntersectionBlock.Center.X;
            Vector2 movement = new Vector2(movableCenter - referenceCenter, 0);

            //if it will shift its speed and is then too far that is will shift back next time, then stay
            if (Math.Abs(movement.X) <= reference.HorizontalSpeed)
                movement = Vector2.Zero;

            if (movement != Vector2.Zero)
                movement.Normalize();
            return movement;
        }
    }
}

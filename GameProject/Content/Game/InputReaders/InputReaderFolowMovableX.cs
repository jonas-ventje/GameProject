using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using SharpDX.Direct3D9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.InputReaders
{
    internal class InputReaderFolowMovableX : IInputReader
    {

        private MovableGameObject movable;
        private ControllableObject reference;
        public InputReaderFolowMovableX(MovableGameObject movable, ControllableObject reference)
        {
            this.movable = movable;
            this.reference = reference;
        }

        //this one has bugs. since acceleration, the speed can be higher dan movable stored speed.
        public Vector2 ReadInput()
        {
            int referenceCenter = BoundingPositionRectangle(reference).Center.X;
            int movableCenter = movable.IntersectionBlock.Center.X;
            Vector2 movement = new Vector2(movableCenter - referenceCenter, 0);

            //if it will shift its speed and is then too far that is will shift back next time, then stay
            if (Math.Abs(movement.X) <= reference.Speed)
                movement = Vector2.Zero;

            if (movement != Vector2.Zero)
                movement.Normalize();
            return movement;
        }

        private Rectangle BoundingPositionRectangle(GameObject gameObject)
        {
            int left = (int)gameObject.Position.X + gameObject.Frame.BoundingBox.Left;
            int top = (int)gameObject.Position.Y + gameObject.Frame.BoundingBox.Top;

            return new Rectangle(left, top, gameObject.Frame.BoundingBox.Width, gameObject.Frame.BoundingBox.Height);

        }
    }
}

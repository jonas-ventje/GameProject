using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects {
    enum MovingState {
        Idle, Walking, Jumping, Dying, Attacking, Falling
    }
    internal abstract class ControllableGravityObject:ControllableObject {
        protected MovingState currentMovingState;
        protected ControllableGravityObject(Texture2D texture, Vector2 position, Frame frame, int horizontalSpeed) : base(texture, position, frame, horizontalSpeed) {
            currentMovingState= MovingState.Idle;
        }
        public ControllableGravityObject(Texture2D texture, Vector2 position, bool hasHitbox, int horizontalSpeed)
            : this(texture, position, new Frame(new Rectangle(0, 0, texture.Width, texture.Height), hasHitbox), horizontalSpeed) {
        }

        public MovingState CurrentMovingState
        {
            get => currentMovingState; set => currentMovingState = value;
        }
    }
}

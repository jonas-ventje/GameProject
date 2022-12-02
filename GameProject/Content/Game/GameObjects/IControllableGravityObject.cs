using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.GameObjects
{
    enum MovingState
    {
        Idle, Walking, Jumping, Dying
    }
    internal interface IControllableGravityObject : IControllableObject
    {
        public MovingState CurrentMovingState
        {
            get; set;
        }
    }
}

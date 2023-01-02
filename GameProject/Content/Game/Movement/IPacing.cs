using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movement
{
    enum MovingDirection
    {
        Left, Right
    }
    internal interface IPacing
    {
        public MovingDirection MovingDirection
        {
            get; set;
        }
    }
}

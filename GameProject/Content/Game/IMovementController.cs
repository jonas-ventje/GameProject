using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game
{
    internal interface IMovementController {
#nullable enable
        public Vector2 Move(GameTime? gameTime, ref List<Frame> frameList, ref int activeFrame, ref SpriteEffects spriteEffect, Vector2 position);
#nullable disable
        }
    }

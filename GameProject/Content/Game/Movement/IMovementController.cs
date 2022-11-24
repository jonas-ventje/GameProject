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
        public Vector2 Move(GameTime? gameTime, Frame frame, Vector2 position, SpriteEffects spriteEffect, out Vector2 noCollisionMovement);
#nullable disable
        }
    }

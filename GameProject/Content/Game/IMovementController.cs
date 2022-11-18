using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal interface IMovementController {
#nullable enable
        Vector2 Move(GameTime? gameTime, SantaFrame frame, SpriteEffects spriteEffect, Vector2 position);
#nullable disable
    }
}

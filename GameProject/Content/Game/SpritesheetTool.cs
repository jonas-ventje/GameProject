using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content {
    internal static class SpritesheetTool {
        public static Rectangle spritePositionToRectangle(int spriteWidth, int spriteHeigh, int numberHorizontal, int position) {
            int startPixelHorizontal = spriteWidth * (position % numberHorizontal);
            int startPixelVertical = spriteHeigh * (position / numberHorizontal);
            return new Rectangle(startPixelHorizontal, startPixelVertical, spriteWidth, spriteHeigh);
        }
    }
}

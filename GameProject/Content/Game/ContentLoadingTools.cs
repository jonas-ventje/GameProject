using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal static class ContentLoadingTools {
        public static Rectangle CoordToRect(int x1, int y1, int x2, int y2) {
            return new Rectangle(x1, y1, (x2 - x1), (y2 - y1));
        }
    }
}

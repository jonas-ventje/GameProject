using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables.Crate {
    internal static class CrateFrames {
        internal static List<Frame> idleFrames = new List<Frame>();
        internal static List<Frame> breakingFrames = new List<Frame>();
        static CrateFrames() {
            #region idleFrames
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 5, 0),
                    hitbox: ContentLoadingTools.CoordToRect(0, 0, 101, 101)
                ));
            #endregion
            #region brakingFrames
            breakingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 5, 0),
                hitbox: ContentLoadingTools.CoordToRect(0, 0, 101, 101)
            ));
            breakingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 5, 1),
                hitbox: ContentLoadingTools.CoordToRect(0, 10, 101, 101)
            ));
            breakingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 5, 2),
                hitbox: ContentLoadingTools.CoordToRect(0, 24, 101, 101)
            ));
            breakingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 5, 3),
                hitbox: ContentLoadingTools.CoordToRect(0, 41, 101, 101)
            ));
            breakingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(101, 101, 4, 4),
                hitbox: ContentLoadingTools.CoordToRect(0, 65, 101, 101)
            ));
            #endregion
        }

    }
}

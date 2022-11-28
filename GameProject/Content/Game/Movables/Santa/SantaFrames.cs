using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables.Santa {
    internal static class SantaFrames {
        internal static List<Frame> idleFrames = new List<Frame>();
        internal static List<Frame> walkingFrames = new List<Frame>();

        static SantaFrames() {
            #region idleFrames
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 17),
                hitbox: ContentLoadingTools.CoordToRect(52, 9, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 18),
                hitbox: ContentLoadingTools.CoordToRect(52, 9, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 19),
                hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 20),
                hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 21),
                hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 22),
                hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 23),
                hitbox: ContentLoadingTools.CoordToRect(52, 11, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 24),
                hitbox: ContentLoadingTools.CoordToRect(52, 11, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 25),
                hitbox: ContentLoadingTools.CoordToRect(52, 11, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 26),
                hitbox: ContentLoadingTools.CoordToRect(52, 11, 147, 157)
            ));
            idleFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 27),
                hitbox: ContentLoadingTools.CoordToRect(52, 12, 147, 157)
            ));
            idleFrames.Add(new Frame(
               boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 28),
               hitbox: ContentLoadingTools.CoordToRect(52, 11, 147, 157)
           ));
            idleFrames.Add(new Frame(
               boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 29),
               hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
           ));
            idleFrames.Add(new Frame(
               boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 30),
               hitbox: ContentLoadingTools.CoordToRect(52, 10, 147, 157)
           ));
            idleFrames.Add(new Frame(
               boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 31),
               hitbox: ContentLoadingTools.CoordToRect(52, 9, 147, 157)
           ));
            idleFrames.Add(new Frame(
               boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 32),
                           hitbox: ContentLoadingTools.CoordToRect(52, 9, 147, 157)
                       ));
            #endregion
            #region walingFrames
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 71),
                            hitbox: ContentLoadingTools.CoordToRect(50, 9, 146, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 72),
                            hitbox: ContentLoadingTools.CoordToRect(52, 8, 145, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 73),
                            hitbox: ContentLoadingTools.CoordToRect(53, 8, 150, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 74),
                            hitbox: ContentLoadingTools.CoordToRect(54, 8, 152, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 75),
                            hitbox: ContentLoadingTools.CoordToRect(52, 8, 152, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 76),
                            hitbox: ContentLoadingTools.CoordToRect(51, 9, 146, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 77),
                            hitbox: ContentLoadingTools.CoordToRect(51, 9, 146, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 78),
                            hitbox: ContentLoadingTools.CoordToRect(53, 9, 151, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 79),
                            hitbox: ContentLoadingTools.CoordToRect(53, 8, 156, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 80),
                            hitbox: ContentLoadingTools.CoordToRect(50, 9, 146, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 81),
                            hitbox: ContentLoadingTools.CoordToRect(53, 8, 149, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 82),
                            hitbox: ContentLoadingTools.CoordToRect(51, 8, 146, 157)
                        ));
            walkingFrames.Add(new Frame(
                boundingBox: ContentLoadingTools.SpritePositionToRectangle(256, 176, 8, 83),
                            hitbox: ContentLoadingTools.CoordToRect(51, 8, 147, 157)
                        ));
            #endregion
        }

    }
}

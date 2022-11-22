using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Santa
{
    internal static class SantaFrames {
        internal static List<Frame> idleFrames = new List<Frame>();
        internal static List<Frame> walkingFrames = new List<Frame>();

        static SantaFrames() {
            #region idleFrames
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 17),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62,9, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52,9,147,157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 18),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 9, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 9, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 19),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 20),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 21),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 22),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 23),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 11, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 11, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 24),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 11, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 11, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 25),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 11, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 11, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 26),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 11, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 11, 147, 157) }
            ));
            idleFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 27),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 12, 147, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 12, 147, 157) }
            ));
            idleFrames.Add(new Frame(
               boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 28),
               fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 11, 147, 157) },
               hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 11, 147, 157) }
           ));
            idleFrames.Add(new Frame(
               boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 29),
               fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
               hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
           ));
            idleFrames.Add(new Frame(
               boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 30),
               fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 10, 147, 157) },
               hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 10, 147, 157) }
           ));
            idleFrames.Add(new Frame(
               boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 31),
               fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 9, 147, 157) },
               hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 9, 147, 157) }
           ));
            idleFrames.Add(new Frame(
               boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 32),
               fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(62, 9, 147, 157) },
               hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 9, 147, 157) }
           ));
            #endregion
            #region walingFrames
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 71),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(70, 13, 141, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(50, 9, 146, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 72),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(69, 15, 139, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 8, 145, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 73),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(69, 13, 138, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(53, 8, 150, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 74),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(68, 14, 139, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(54, 8, 152, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 75),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(69, 17, 136, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(52, 8, 152, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 76),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(68, 15, 138, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(51, 9, 146, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 77),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(68, 17, 140, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(51, 9, 146, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 78),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(60, 14, 139, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(53, 9, 151, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 79),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(65, 14, 138, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(53, 8, 156, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 80),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(65, 15, 137, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(50, 9, 146, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 81),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(64, 13, 138, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(53, 8, 149, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 82),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(67, 14, 140, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(51, 8, 146, 157) }
            ));
            walkingFrames.Add(new Frame(
                boundingBox: SpritesheetTool.SpritePositionToRectangle(256, 176, 8, 83),
                fatalHitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(68, 14, 138, 157) },
                hitbox: new List<Rectangle> { ContentLoadingTools.CoordToRect(51, 8, 147, 157) }
            ));
            #endregion
        }

    }
}

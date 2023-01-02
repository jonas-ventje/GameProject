using GameProject.Content.Game.GameParts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables.Snowman
{
    internal static class SnowmanFrames {
        internal static List<Frame> idleFrames = new List<Frame>();
        internal static List<Frame> walkingFrames = new List<Frame>();
        internal static List<Frame> dyingFrames = new List<Frame>();
        internal static List<Frame> attackFrames = new List<Frame>();

        static SnowmanFrames() {
            #region idleFrames
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(777, 419, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(892, 419, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(0, 568, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(115, 568, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(230, 568, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(345, 568, 115, 143)
            ));
            idleFrames.Add(new Frame(
                boundingBox: new Rectangle(460, 568, 115, 143)
            ));
            #endregion
            #region walkingFrames
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(575, 568, 112, 139)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(687, 568, 110, 137)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(797, 568, 103, 136)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(900, 568, 98, 134)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(0, 711, 98, 133)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(98, 711, 98, 133)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(196, 711, 102, 136)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(298, 711, 109, 137)
            ));
            walkingFrames.Add(new Frame(
                boundingBox: new Rectangle(407, 711, 112, 139)
            ));
            #endregion
            #region dyingDrames
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(400, 148, 123, 153), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(523, 148, 124, 151), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(647, 148, 115, 148), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(762, 148, 140, 133), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(0, 301, 159, 118), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(159, 301, 178, 118), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(337, 301, 204, 91), false
            ));
            dyingFrames.Add(new Frame(
                boundingBox: new Rectangle(770, 301, 253, 110), false
            ));
            #endregion
            #region atticFrames
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(0, 0, 119, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(119, 0, 119, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(238, 0, 116, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(354, 0, 111, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(465, 0, 108, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(573, 0, 109, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(682, 0, 114, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(796, 0, 131, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(0, 148, 140, 146)
            ));
            attackFrames.Add(new Frame(
                boundingBox: new Rectangle(140, 148, 140, 146)
            ));
            #endregion
        }
    }
}

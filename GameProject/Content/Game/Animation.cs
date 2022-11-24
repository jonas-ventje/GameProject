using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game
{
    internal class Animation
    {
        private List<Frame> frameList;
        private int activeFrame = 0;
        private double secondCounter;
        private int fps;
        public Animation(List<Frame> activeFrameList, int fps) {
            this.frameList = activeFrameList;
            this.activeFrame = 0;
            this.secondCounter = 0;
            this.fps = fps;
        }
        public Frame update(GameTime gameTime) {
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            if (secondCounter >= 1d / fps)
            {
                activeFrame++;
                secondCounter = 0;
            }
            if (activeFrame >= frameList.Count)
                activeFrame = 0;
            return frameList[activeFrame];

        }
        /// <summary>
        /// when an animation should start with frame 0
        /// </summary>
        public void reset() {
            activeFrame = 0;
        }
        public Frame update(GameTime gameTime, List<Frame> frameList) {
            this.frameList = frameList;
            return update(gameTime);
        }
    }
}

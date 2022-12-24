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
        public List<Frame> FrameList
        {
            get
            {
                return frameList;
            }
            set
            {
                frameList = value;
            }
        }

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
        /// updates the stored framelist, and sets the activeFrame back to 0 if its another framelist
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="frameList"></param>
        /// <returns></returns>
        public void updateFrameList(List<Frame> frameList) {
            List<Frame> oldFrameList = frameList;
            this.frameList = frameList;
            if (oldFrameList != frameList)
            {
                activeFrame = 0;
            }
        }
    }
}

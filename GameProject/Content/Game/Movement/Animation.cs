using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.GameParts;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movement
{
    internal class Animation
    {
        private List<Frame> frameList;
        private int activeFrame = 0;
        private double secondCounter;
        private int fps;
        private GameObject movable;
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

        public Animation(List<Frame> activeFrameList, int fps, GameObject movable)
        {
            frameList = activeFrameList;
            activeFrame = 0;
            secondCounter = 0;
            this.fps = fps;
            this.movable = movable;
        }
        public Frame update(GameTime gameTime)
        {
            secondCounter += gameTime.ElapsedGameTime.TotalSeconds;
            int prevHitboxHeight = frameList[activeFrame].Hitbox.Height;
            if (secondCounter >= 1d / fps)
            {
                activeFrame++;
                secondCounter = 0;
            }
            if (activeFrame >= frameList.Count)
                activeFrame = 0;

            //change position when heights aren't equal
            int newHitboxHeight = frameList[activeFrame].Hitbox.Height;
            if (prevHitboxHeight < newHitboxHeight)
            {
                Vector2 newPosition = new Vector2(movable.Position.X, movable.Position.Y + prevHitboxHeight - newHitboxHeight);
                movable.Position = newPosition;
            }
            return frameList[activeFrame];

        }
        /// <summary>
        /// updates the stored framelist, and sets the activeFrame back to 0 if its another framelist
        /// </summary>
        /// <param name="gameTime"></param>
        /// <param name="frameList"></param>
        /// <returns></returns>
        public bool updateFrameList(List<Frame> frameList)
        {
            List<Frame> oldFrameList = this.frameList;
            this.frameList = frameList;
            if (oldFrameList != frameList)
            {
                activeFrame = 0;
                return true;
            }
            return false;
        }
    }
}

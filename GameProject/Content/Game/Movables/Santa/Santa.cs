using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.GameParts;
using GameProject.Content.Game.InputReaders;
using GameProject.Content.Game.Movement;
using GameProject.Content.Game.Movement.MovementManagers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace GameProject.Content.Game.Movables.Santa
{
    internal class Santa : ControllableGravityObject, IAnimatable, IObserverSubject {
        private Animation animation;
        private ControllableGravityMovementManager movementController;
        private List<ISantaObserver> observers;
        private bool santaMoved = false;
        private SoundEffect giftSound;
        private SoundEffect dyingSound;
        private SoundEffect jumingSound;


        public Animation Animation => animation;

        public override bool CanAccelerate => true;

        public Santa(Texture2D texture, int speed, int x, int y, ContentManager content) : base(texture, new Vector2(x, y), SantaFrames.idleFrames[0], speed) {
            inputReader = new InputReaderKeyboard();
            movementController = new ControllableGravityMovementManager();
            animation = new Animation(SantaFrames.idleFrames, 15, this);
            observers = new List<ISantaObserver>();
            giftSound = content.Load<SoundEffect>("./sounds/collect_gift");
            dyingSound = content.Load<SoundEffect>("./sounds/santa_dying");
            jumingSound = content.Load<SoundEffect>("./sounds/santa_jumping");
        }
        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
            if (collisionObject is Gift)
            {
                (collisionObject as Gift).ToBeRemoved = true;
                giftSound.CreateInstance().Play();
            }
            else if (collisionObject is Snowman.Snowman)
            {
                if (side == CollidingSide.Bottom)
                    (collisionObject as Snowman.Snowman).CurrentMovingState = MovingState.Dying;
                else
                    currentMovingState = MovingState.Dying;
            }
            else if (collisionObject is GameTile)
                if ((collisionObject as GameTile).Id == 27 || (collisionObject as GameTile).Id == 28)
                    currentMovingState = MovingState.Dying;

        }

        private void Move(GameTime gameTime) {
            int prevPositionX = (int)position.X;
            movementController.Move(this, gameTime);
            if (position.X != prevPositionX && !santaMoved)
            {
                santaMoved = true;
                NotifyObservers();
            }
        }
        /// <summary>
        /// change framelist based on the current moving state which is walking, jumping...
        /// </summary>
        private void UpdateFrameList() {
            switch (CurrentMovingState)
            {
                case MovingState.Idle:
                case MovingState.Falling:
                case MovingState.Jumping:
                    Animation.updateFrameList(SantaFrames.idleFrames);
                    break;
                case MovingState.Walking:
                    Animation.updateFrameList(SantaFrames.walkingFrames);
                    break;
                case MovingState.Dying:
                    if (Animation.updateFrameList(SantaFrames.dyingFrames))
                        dyingSound.CreateInstance().Play();
                    break;
                default:
                    break;
            }
        }

        public override void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, frame.BoundingBox, Color.White, 0f, new Vector2(0, 0), 1f, SpriteDirection, 1f);
        }


        public override void Update(GameTime gameTime) {
            MovingState prevMovingState = currentMovingState;
            Move(gameTime);
            if (prevMovingState != MovingState.Jumping && currentMovingState == MovingState.Jumping)
                jumingSound.CreateInstance().Play();
            UpdateFrameList();
            frame = Animation.update(gameTime);
            //if below is true, santa is dead.
            if (Animation.FrameList == SantaFrames.dyingFrames && frame == Animation.FrameList[Animation.FrameList.Count - 1])
            {
                toBeRemoved = true;
            }
        }

        public void RegisterObserver(ISantaObserver observer) {
            observers.Add(observer);
        }

        public void RemoveObserver(ISantaObserver observer) {
            observers.Remove(observer);
        }

        public void NotifyObservers() {
            foreach (ISantaObserver observer in observers)
            {
                observer.update(santaMoved);
            }
        }
    }

}

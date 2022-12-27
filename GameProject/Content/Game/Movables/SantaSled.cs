using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables {
    internal class SantaSled : MovableGameObject {
        private World world;
        private Santa.Santa santa;
        private float tilted = 0f;
        private const float tiltRange = .18f;
        private const int departDistance = 250;
        private Vector2 startPosition;
        private double startTime;
        private bool departing = false;

        private Frame waitingFrame;
        private Frame departureFrame;
        private Color color = Color.White;

        public bool Departing
        {
            get => departing;
        }

        public SantaSled(Texture2D texture, int x, int y, Frame frame, World world, Santa.Santa santa) : base(texture, new Vector2(x, y), frame) {
            Passable = true;
            this.world = world;
            this.santa = santa;
            waitingFrame = new Frame(new Rectangle(0, 51, 230, 178));
            departureFrame = new Frame(new Rectangle(231, 0, 230, 229));
            this.frame = waitingFrame;
            startPosition = position;
        }

        public override bool CanAccelerate => false;



        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }

        public override void Update(GameTime gameTime) {

            if (world.CatchedRatio == 1 && frame == waitingFrame)
                tilted = tiltRange * (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 18);
            else
                tilted = 0f;
            if (world.CatchedRatio == 1 && Vector2.Distance(new Vector2(IntersectionBlock.Center.X, IntersectionBlock.Center.Y), new Vector2(santa.IntersectionBlock.Center.X, santa.IntersectionBlock.Center.Y)) < departDistance)
            {
                color = Color.LightSalmon;
                //in the depart area. Wating for the button to press.
                if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                {
                    frame = departureFrame;
                    startTime = gameTime.TotalGameTime.TotalSeconds;
                    departing = true;
                    santa.ToBeRemoved = true;
                }
            }
            else
                color = Color.White;
            if (departing)
            {
                color = Color.White;
                //end of game when sled is outside boundries.
                if (IntersectionBlock.Bottom < 0 || IntersectionBlock.Left > Game1.virtualWidth)
                {
                    world.Victory = true;
                }
                Vector2 offset = new Vector2((float)Math.Pow((gameTime.TotalGameTime.TotalSeconds - startTime) * 17, 2), -(float)Math.Pow((gameTime.TotalGameTime.TotalSeconds - startTime) * 4, 3));
                position = startPosition + offset;
            }

        }
        public override void Draw(SpriteBatch spriteBatch) {
            Vector2 origin = new Vector2(frame.Hitbox.Center.X, frame.Hitbox.Center.Y);
            Vector2 position = frame == waitingFrame ? this.position + new Vector2(0, 51) : this.position;
            Vector2 positionFromOrigin = position + origin;
            spriteBatch.Draw(texture, positionFromOrigin, frame.BoundingBox, color, tilted, origin, 1f, SpriteEffects.None, 1f);
        }
    }
}

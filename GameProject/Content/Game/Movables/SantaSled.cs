using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Movables
{
    internal class SantaSled : MovableGameObject {
        private World world;
        private Santa.Santa santa;
        private float wiggleAngle = 0f;
        private const float wiggleRange = .18f;
        private const int departDistance = 250;
        private Vector2 startPosition;
        private double startTime;
        private bool departing = false;

        private double victoryDelay;

        private Frame waitingFrame;
        private Frame departureFrame;
        private Color color = Color.White;

        private Texture2D particleTexture;
        private List<Particle> particles;
        private SoundEffect departingSound;

        public bool Departing
        {
            get => departing;
        }

        public SantaSled(Texture2D texture, Texture2D particleTexture, int x, int y, Frame frame, World world, Santa.Santa santa, ContentManager content) : base(texture, new Vector2(x, y), frame) {
            Passable = true;
            this.world = world;
            this.santa = santa;
            waitingFrame = new Frame(new Rectangle(0, 51, 230, 178));
            departureFrame = new Frame(new Rectangle(231, 0, 230, 229));
            this.frame = waitingFrame;
            startPosition = position;
            this.particleTexture = particleTexture;
            this.particles = new List<Particle>();
            this.departingSound = content.Load<SoundEffect>("./sounds/flying_away");
        }

        public override bool CanAccelerate => false;



        public override void CollisionEffect(GameObject collisionObject, CollidingSide side) {
        }

        public override void Update(GameTime gameTime) {
            if (world.CatchedRatio == 1 && frame == waitingFrame)
            {
                //all catched --> wiggle
                Wiggle(gameTime);
            }
            else
                wiggleAngle = 0f;
            if (departing)
            {
                Depart(gameTime);
            }

        }

        public override void Draw(SpriteBatch spriteBatch) {
            Vector2 origin = new Vector2(frame.Hitbox.Center.X, frame.Hitbox.Center.Y);
            Vector2 position = frame == waitingFrame ? this.position + new Vector2(0, 51) : this.position;
            Vector2 positionFromOrigin = position + origin;
            spriteBatch.Draw(texture, positionFromOrigin, frame.BoundingBox, color, wiggleAngle, origin, 1f, SpriteEffects.None, 1f);
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
        }

        private Particle GenerateNewParticle() {
            Vector2 position = this.position + new Vector2(0, texture.Height * 0.75f);
            Vector2 velocity = new Vector2((float)(Game1.rand.NextDouble() * 3 - 1), (float)(Game1.rand.NextDouble() * 3 - 1));
            float angularVelocity = 0.1f * (float)(Game1.rand.NextDouble() * 2 - 1);
            float scale = (float)(Game1.rand.NextDouble() * 4);
            int ttl = 40 + Game1.rand.Next(150);

            return new Particle(particleTexture, position, velocity, 0f, angularVelocity, 1f, scale, ttl);
        }

        private void Wiggle(GameTime gameTime) {
            wiggleAngle = wiggleRange * (float)Math.Sin(gameTime.TotalGameTime.TotalSeconds * 18);
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
                    departingSound.CreateInstance().Play();
                }
            }
            else
                color = Color.White;
        }

        private void Depart(GameTime gameTime) {
            color = Color.White;
            //end of game when sled is outside boundries.
            if (IntersectionBlock.Bottom < 0 || IntersectionBlock.Left > Game1.virtualWidth)
            {
                if (victoryDelay == 0)
                    victoryDelay = gameTime.TotalGameTime.TotalMilliseconds + 2000;
                else if(gameTime.TotalGameTime.TotalMilliseconds>victoryDelay)
                    world.Victory = true;
            }

            Vector2 offset = new Vector2((float)Math.Pow((gameTime.TotalGameTime.TotalSeconds - startTime) * 17, 2), -(float)Math.Pow((gameTime.TotalGameTime.TotalSeconds - startTime) * 4, 3));
            position = startPosition + offset;

            //add 10 particles
            for (int i = 0; i < 10; i++)
            {
                particles.Add(GenerateNewParticle());
            }

            UpdateParticles();
        }

        private void UpdateParticles() {
            List<Particle> toRemove = new List<Particle>();
            foreach (var particle in particles)
            {
                particle.Update();
                if (particle.TTL <= 0)
                    toRemove.Add(particle);
            }
            foreach (var particle in toRemove)
            {
                particles.Remove(particle);
            }
        }
    }
}

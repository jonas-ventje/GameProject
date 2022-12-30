using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game.Screens {
    internal class Particle {
        private Texture2D texture;
        private Vector2 position;
        private Vector2 velocity;
        private float angle;
        private float angularVelocity;
        private float scale;
        private int ttl;
        private float opacity;
        private float opacitySteps;
        public int TTL
        {
            get => ttl;
        }

        public Particle(Texture2D texture, Vector2 position, Vector2 velocity,
            float angle, float angularVelocity, float opacity, float size, int timeToLive) {
            this.texture = texture;
            this.position = position;
            this.velocity = velocity;
            this.angle = angle;
            this.angularVelocity = angularVelocity;
            this.scale = size;
            this.ttl = timeToLive;
            this.opacity = opacity;
            this.opacitySteps = 1 / (float)timeToLive;
        }

        public void Update() {
            ttl--;
            position += velocity;
            angle += angularVelocity;
            opacity -= opacitySteps;
        }

        public void Draw(SpriteBatch spriteBatch) {
            Vector2 origin = new Vector2(texture.Width / 2, texture.Height / 2);
            spriteBatch.Draw(texture, position, null, Color.White*opacity,
                angle, origin, scale, SpriteEffects.None, 0f);
        }
    }
}

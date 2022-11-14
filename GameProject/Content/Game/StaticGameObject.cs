using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content {
    internal abstract class StaticGameObject {
        public static List<StaticGameObject> staticGameObjects = new List<StaticGameObject>();
        public StaticGameObject() {
            staticGameObjects.Add(this);
        }
        public abstract void draw(SpriteBatch spriteBatch);
    }
}

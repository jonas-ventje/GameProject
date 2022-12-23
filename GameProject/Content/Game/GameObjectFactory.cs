using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movables;
using GameProject.Content.Game.Movables.Crate;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal static class GameObjectFactory {

        private static Texture2D crateTexture;
        private static Texture2D cadeauTexture;

        public static void Init(Texture2D crateTextureI, Texture2D cadeauTextureI) {
            crateTexture = crateTextureI;
            cadeauTexture = cadeauTextureI;
        }
        public static GameObject CreateGameObject(string type, int x, int y) {
            if(crateTexture == null)
                throw new NullReferenceException();
            else if (type == "crate")
                return new Crate(crateTexture, x, y);
            else if (type == "cadeau")
                return new Gift(cadeauTexture, x, y);
            else throw new ArgumentException();
        
        }

    }
}

using GameProject.Content.Game.GameObjects;
using GameProject.Content.Game.Movables;
using GameProject.Content.Game.Movables.Crate;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal static class GameObjectFactory {

        private static Texture2D crateTexture;
        private static Texture2D giftTexture;
        private static ContentManager content;
        public static void Init(ContentManager contentI) {
            content = contentI;
            crateTexture = content.Load<Texture2D>("./images/crate");
            giftTexture = content.Load<Texture2D>("./images/cadeau_2");
        }
        public static GameObject CreateGameObject(string type, int x, int y) {
            if(crateTexture == null)
                throw new NullReferenceException();
            else if (type == "crate")
                return new Crate(crateTexture, x, y, content);
            else if (type == "cadeau")
                return new Gift(giftTexture, x, y);
            else throw new ArgumentException();
        
        }

    }
}

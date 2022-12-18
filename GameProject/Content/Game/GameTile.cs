using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameProject.Content.Game {
    internal class GameTile : GameObject {
        public GameTile(Texture2D texture, Frame frame, int x, int y)
            //always draw from the right lower corner
            : base(texture, new Vector2(x, y + 128 - frame.BoundingBox.Height), frame) {
        }
    }
}
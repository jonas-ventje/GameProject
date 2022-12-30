using GameProject.Content.Game.GameObjects;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameProject.Content.Game {
    internal class Button {
        Texture2D texture;
        SpriteFont font;
        Vector2 position;
        ButtonState oldState;
        Color color = Color.White;
        bool isDisabled;
        string text;

        public Button(Texture2D texture, SpriteFont font, int x, int y, string text, bool disabled = false) {
            this.texture = texture;
            this.position = new Vector2(x, y);
            isDisabled = disabled;
            this.font = font;
            this.text = text;
        }

        public bool isHovered() {
            double xPos = Mouse.GetState().Position.X * (1 / Game1.scale);
            double yPos = Mouse.GetState().Position.Y * (1 / Game1.scale);

            if (xPos < position.X + texture.Width &&
                    xPos > position.X &&
                    yPos < position.Y + texture.Height &&
                    yPos > position.Y)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>if the button was pressed</returns>
        public bool Update() {
            MouseState state = Mouse.GetState();
            bool isPressed = false;
            if (isDisabled)
                color = Color.Gray;
            else if (isHovered())
            {
                color = Color.LightSalmon;
                if (state.LeftButton == ButtonState.Released && oldState == ButtonState.Pressed)
                {
                    Debug.WriteLine("pressed");
                    isPressed = true;
                }
            }
            else
                color = Color.White;
            oldState = state.LeftButton;
            return isPressed;
        }
        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(texture, position, color);
            Vector2 textMiddlePoint = font.MeasureString(text) / 2;
            // Places text in center of the screen
            spriteBatch.DrawString(font, text, position + new Vector2(texture.Width / 2, texture.Height /2f), color, 0, textMiddlePoint, 1.0f, SpriteEffects.None, 0.5f);
        }
    }
}

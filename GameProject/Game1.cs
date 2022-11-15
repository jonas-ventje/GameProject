﻿using GameProject.Content;
using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;

namespace GameProject
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D santaTexture;
        private Texture2D blockTexture;

        private Santa santa;
        private Block block;
        private Block block2;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
/*            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;*/
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            base.Initialize();

            santa = new Santa(santaTexture, new Vector2(3,3));
            block = new Block(blockTexture, 400, 100, new Vector2(10, 300));
            block2 = new Block(blockTexture, 200, 200, new Vector2(400, 30));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            santaTexture = Content.Load<Texture2D>("./images/santaClaus_small");
            blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            blockTexture.SetData(new[] { Color.HotPink });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            santa.update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            santa.draw(_spriteBatch);
            block.draw(_spriteBatch);
            block2.draw(_spriteBatch);
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
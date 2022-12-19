﻿using GameProject.Content;
using GameProject.Content.Game;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;

namespace GameProject {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D renderTarget;
        private Texture2D blockTexture;
        private Texture2D backgroundTexture;
        private GameState prevGameState;
        private Vector2 position;


        public static float scale;
        public static int virtualWidth = 3200;
        public static int virtualHeight = 1792;


        private IScreen onDisplay;

        public Game1() {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize() {
         /*   _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
            _graphics.IsFullScreen = true;*/
           _graphics.PreferredBackBufferWidth = 1120;
            _graphics.PreferredBackBufferHeight = 630;
            Window.AllowUserResizing = true;
            _graphics.ApplyChanges();

            scale = 1F / ((float)virtualWidth / GraphicsDevice.Viewport.Width);

            //onDisplay = new World(Content);
            onDisplay = new StartScreen(Content);

            prevGameState = GameState.StartScreen;
            position = new Vector2(0, 0);
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);
            blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            backgroundTexture = Content.Load<Texture2D>("./images/background");
            blockTexture.SetData(new[] { Color.HotPink });
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            GameState newGameState = onDisplay.Update(gameTime);
            if (prevGameState != newGameState)
            {
                switch (newGameState)
                {
                    case GameState.StartScreen:
                        onDisplay = new StartScreen(Content);
                        break;
                    case GameState.Info:
                        throw new NotImplementedException();
                        break;
                    case GameState.Level1:
                        onDisplay = new World(Content);
                        break;
                    case GameState.Level2:
                        throw new NotImplementedException();

                        break;
                    case GameState.GameOver:
                        throw new NotImplementedException();

                        break;
                    default:
                        break;
                }
                prevGameState = newGameState;
            }
            float virtualRatio = (float)virtualWidth / virtualHeight;
            float screenRatio = (float)GraphicsDevice.Viewport.Width / GraphicsDevice.Viewport.Height;
            if (virtualRatio > screenRatio)
            {

                scale = 1F / ((float)virtualWidth / GraphicsDevice.Viewport.Width);
                int start = (int)(GraphicsDevice.Viewport.Width - scale * virtualWidth) / 2;
                position = new Vector2(0, start);
            }
            else
            {
                scale = 1F / ((float)virtualHeight / GraphicsDevice.Viewport.Height);
                int start = (int)(GraphicsDevice.Viewport.Width - scale * virtualWidth) / 2;
                position = new Vector2(start, 0);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
            onDisplay.Draw(_spriteBatch);
            _spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.LightSalmon);
            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
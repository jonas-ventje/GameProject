using GameProject.Content;
using GameProject.Content.Game;
using GameProject.Content.Game.Levels;
using GameProject.Content.Game.Movables.Santa;
using GameProject.Content.Game.Screens;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Diagnostics;
using System.Reflection.Metadata;

namespace GameProject {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D renderTarget;
        private Texture2D backgroundTexture;
        private Texture2D backgroundTextureBlurred;
        private Texture2D background;
        private Vector2 position;


        public static float scale;
        public static int virtualWidth = 3328;
        public static int virtualHeight = 1792;

        public static Random rand = new Random();


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

            //Scores.CheckScores();

            scale = 1F / ((float)virtualWidth / GraphicsDevice.Viewport.Width);

            onDisplay = new StartScreen(Content);
            //onDisplay = new World(Content, new Level1());

            position = new Vector2(0, 0);
            MediaPlayer.Volume = .2f;
            MediaPlayer.IsRepeating = true;
            base.Initialize();
        }

        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidth, virtualHeight);
            backgroundTexture = Content.Load<Texture2D>("./images/background");
            backgroundTextureBlurred = Content.Load<Texture2D>("./images/bgBlurred");
            MediaPlayer.Play(Content.Load<Song>("./sounds/background music"));
            background = backgroundTexture;
        }

        protected override void Update(GameTime gameTime) {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //update what is on screen
            onDisplay = onDisplay.Update(gameTime);

            //update the scale (for resizing purposes)
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

            //update blurred/non-blurred background
            if (onDisplay is StartScreen)
                background = backgroundTextureBlurred;
            else
                background = backgroundTexture;
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            //draw at virtual screen
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.White);
            _spriteBatch.Begin();
            _spriteBatch.Draw(background, Vector2.Zero, Color.White);
            onDisplay.Draw(_spriteBatch);
            _spriteBatch.End();

            //draw at real screen
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);
            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, position, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
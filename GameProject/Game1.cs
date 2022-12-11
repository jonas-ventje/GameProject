using GameProject.Content;
using GameProject.Content.Game;
using GameProject.Content.Game.Movables.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameProject {
    public class Game1 : Game {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D renderTarget;
        private Texture2D blockTexture;
        private Texture2D backgroundTexture;


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
            /*            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                        _graphics.IsFullScreen = true;*/
            _graphics.PreferredBackBufferWidth = 1120;
            _graphics.PreferredBackBufferHeight = 630;
            _graphics.ApplyChanges();
            base.Initialize();

            scale = 1F / ((float)virtualWidth / GraphicsDevice.Viewport.Width);

            //onDisplay = new World(Content);
            onDisplay = new startScreen(Content);

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

            onDisplay.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(backgroundTexture, Vector2.Zero, Color.White);
            onDisplay.Draw(_spriteBatch);
            _spriteBatch.End();
            GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            _spriteBatch.Draw(renderTarget, Vector2.Zero, null, Color.White, 0f, Vector2.Zero, scale, SpriteEffects.None, 0f);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
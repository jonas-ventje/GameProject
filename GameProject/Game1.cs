using GameProject.Content;
using GameProject.Content.Game;
using GameProject.Content.Game.Santa;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace GameProject {
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private RenderTarget2D renderTarget;
        private Texture2D santaTexture;
        private Texture2D tilesTexture;
        private Texture2D blockTexture;


        private float scale;
        private int virtualWidht = 3200;
        private int virtualHeight = 1792;


        private Santa santa;
        private World world;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            /*            _graphics.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
                        _graphics.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;
                        _graphics.IsFullScreen = true;*/
            _graphics.PreferredBackBufferWidth = 1120;
            _graphics.PreferredBackBufferHeight = 630;
            _graphics.ApplyChanges();
            base.Initialize();

            scale = 1F / ((float)virtualWidht / GraphicsDevice.Viewport.Width);

            santa = new Santa(santaTexture, 5);
            world = new World(tilesTexture);

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            renderTarget = new RenderTarget2D(GraphicsDevice, virtualWidht, virtualHeight);
            santaTexture = Content.Load<Texture2D>("./images/santaClaus_small");
            tilesTexture = Content.Load<Texture2D>("./images/tileset");
            blockTexture = new Texture2D(GraphicsDevice, 1, 1);
            blockTexture.SetData(new[] { Color.HotPink });
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            santa.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.SetRenderTarget(renderTarget);
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            
            santa.Draw(_spriteBatch);
            world.Draw(_spriteBatch);

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
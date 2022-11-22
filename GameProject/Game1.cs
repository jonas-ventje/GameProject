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
        private Texture2D santaTexture;
        private Texture2D tilesTexture;
        private Texture2D blockTexture;

        private Santa santa;
        private World world;
        private Block block;
        private Block block2;
        private Block block3;
        private Block block4;

        public Game1()
        {

            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 3200;
            _graphics.PreferredBackBufferHeight = 1800;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            base.Initialize();

            santa = new Santa(santaTexture, new Vector2(3,3));
            world = new World(tilesTexture);
            //block = new Block(blockTexture, 400, 128, new Vector2(10, 500));
            block2 = new Block(blockTexture, 200, 128, new Vector2(400, 200));
            block3 = new Block(blockTexture, 400, 128, new Vector2(400, 500+128+128));
            block4 = new Block(blockTexture, 400, 128, new Vector2(10, 500+128));

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
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
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin();
            santa.Draw(_spriteBatch);
            //block.Draw(_spriteBatch);
            block2.Draw(_spriteBatch);
            block3.Draw(_spriteBatch);
            block4.Draw(_spriteBatch);
            world.Draw(_spriteBatch);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
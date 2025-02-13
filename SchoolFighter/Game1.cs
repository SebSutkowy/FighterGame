using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.Direct3D9;
using System.Collections.Generic;
using System.Security.Cryptography.Xml;

namespace SchoolFighter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static Texture2D _pixelTemplate;
        public static SpriteBatch _spriteBatch;
        TileMap _map;
        Tile[] _tiles = new Tile[9];
        Character _player;
        new Vector2 _velocity;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Globals.Content = Content;
            _graphics.PreferredBackBufferWidth = Globals.winWidth;
            _graphics.PreferredBackBufferHeight = Globals.winHeight;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            
            _tiles[0] = new Tile(100, new Vector2(0, 0), _pixelTemplate);
            _tiles[2] = new Tile(100, new Vector2(200, 0), _pixelTemplate);
            _map = new TileMap();
           
                Globals.prevKeys = Keyboard.GetState();
                base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals._playerTexture = Content.Load<Texture2D>("297x528");
            Globals.Content = Content;
            SceneManager.Scenes = new Dictionary<string, Scene>
            {
                { "MainMenu", new MainMenuScene() },
                { "Game", new GameScene() },
                { "Victory", new VictoryScene() }
            };
            SceneManager.CurrentScene = SceneManager.Scenes["Game"];
            SceneManager.PreviousScene = null;
            SceneManager.LoadContent();
            _spriteBatch = new SpriteBatch(GraphicsDevice);
           
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.UpdateTime(gameTime);
            Globals.keys = Keyboard.GetState();
            SceneManager.Update();
            Globals.prevKeys = Globals.keys;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            SceneManager.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);

            _map.DrawTiles();
        }
    }
}

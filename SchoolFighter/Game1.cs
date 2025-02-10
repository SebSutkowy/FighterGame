using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Drawing;
using Color = Microsoft.Xna.Framework.Color;

namespace SchoolFighter
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = Globals.winWidth;
            _graphics.PreferredBackBufferHeight = Globals.winHeight;
            //_graphics.IsFullScreen = true;
            _graphics.ApplyChanges();

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
                { "MainMenu", new MainMenuScene(_graphics) },
                {"SelectMenu", new CharecterSelectionScene() },
                { "Game", new GameScene() },
                { "Victory", new VictoryScene() }
            };
            SceneManager.CurrentScene = SceneManager.Scenes["MainMenu"];
            SceneManager.PreviousScene = null;
            SceneManager.LoadContent();            

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            Globals.UpdateTime(gameTime);
            Globals.keys = Keyboard.GetState();
            Globals.controller = GamePad.GetState();
            SceneManager.Update();
            //Button.Update();
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
        }
    }
}

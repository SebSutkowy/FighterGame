using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SchoolFighter
{
    // yoo family
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private GamepadCursor gamepadCursor;
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
            Globals.prevButtons = GamePad.GetState(PlayerIndex.One);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            Globals._blankTexture = Content.Load<Texture2D>("297x528");
            Globals._playerTexture.Add(Content.Load<Texture2D>("ryu_idle0"));
            Globals._playerTexture.Add(Content.Load<Texture2D>("ryu_idle1"));
            Globals._playerTexture.Add(Content.Load<Texture2D>("ryu_idle2"));
            Globals._playerTexture.Add(Content.Load<Texture2D>("ryu_idle3"));
            Globals._playerTexture.Add(Content.Load<Texture2D>("ryu_idle4"));
            Globals.cursorTexture=(Content.Load<Texture2D>("cursor"));
            Globals.Content = Content;
            SceneManager.Scenes = new Dictionary<string, Scene>
            {
                { "MainMenu", new MainMenuScene(_graphics) },
                {"SelectMenu", new CharecterSelectionScene() },
                { "Game", new GameScene() },
                { "Victory", new VictoryScene() },
                {"Pause", new PauseMenu(_graphics) }
            };
            SceneManager.CurrentScene = SceneManager.Scenes["MainMenu"];
            SceneManager.PreviousScene = null;
            SceneManager.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            if (Keyboard.GetState().IsKeyDown(Keys.Q) || GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                SceneManager.ChangeScene("Pause");

            }
            if (GamePad.GetState(PlayerIndex.One).IsConnected)
            {
                gamepadCursor.Update(gameTime);
            }


            // TODO: Add your update logic here
            Globals.UpdateTime(gameTime);
            Globals.keys = Keyboard.GetState();
            Globals.buttons = GamePad.GetState(PlayerIndex.One);
            SceneManager.Update();
            Globals.prevKeys = Globals.keys;
            Globals.prevButtons = Globals.buttons;


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();
            SceneManager.Draw(_spriteBatch);
            gamepadCursor.Draw(_spriteBatch);
            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}

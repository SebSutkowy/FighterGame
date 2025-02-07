using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SchoolFighter;


namespace SchoolFighter
{
    internal class MainMenuScene : Scene
    {
        private List<Component> _components;
        private GraphicsDeviceManager graphics;

        //private Game1 _game2;
        GamePadState state = GamePad.GetState(PlayerIndex.One);
        public MainMenuScene() : base() 
        {
            // Write anything that will be in the main menu when you start it here.
            var buttonTexture = Globals.Content.Load<Texture2D>("Control\\Button1");
            var buttonFont = Globals.Content.Load<SpriteFont>("Font");
            int width = (graphics.PreferredBackBufferWidth / 2) - 100;
            var height = (graphics.PreferredBackBufferHeight / 2);
            Vector2 place = new Vector2(width, height - 200);
            int place1 = width - (width - 200);
            //int width2 = _game2.Window.ClientBounds.Width;
            if (state.IsConnected)
            {
                place = state.ThumbSticks.Left;
            }
            if (GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.DPadDown) || GamePad.GetState(PlayerIndex.One).IsButtonDown(Buttons.LeftThumbstickDown))
            {
                place += new Vector2(0, place1);
            }
            var newGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(width, height - 200),
                Text = "New Game",

            };

            newGameButton.Click += NewGameButton_Click;

            var loadGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(width, height),
                Text = "Load Game",
            };

            loadGameButton.Click += LoadGameButton_Click;

            var quitGameButton = new Button(buttonTexture, buttonFont)
            {
                Position = new Vector2(width, height + 200),
                Text = "Quit",
            };

            quitGameButton.Click += QuitGameButton_Click;

            _components = new List<Component>()
      {
               newGameButton,
               loadGameButton,
               quitGameButton,
      };
        }

        public override void LoadContent()
        {
            // Load content here
        }

        public override void Update()
        {
            // Write code for the main menu here
        }

        public override void Draw(SpriteBatch spriteBatch)
        { 
            // Draw here
        }

        public override void AddData(string additionalData = "")
        {
            return;
        }
    }
}

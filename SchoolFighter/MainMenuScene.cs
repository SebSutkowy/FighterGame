using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Reflection.Metadata;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SchoolFighter;



namespace SchoolFighter
{
    internal class MainMenuScene : Scene
    {
        private List<Component> _components;
        private Game _game;
        
        //private Game1 _game2;
        GamePadState state = GamePad.GetState(PlayerIndex.One);

        public MainMenuScene( GraphicsDeviceManager _graphics) : base()
        {
            // Write anything that will be in the main menu when you start it here.

            var buttonTexture = Globals.Content.Load<Texture2D>("button");
            var buttonFont = Globals.Content.Load<SpriteFont>("Font");
            int width = (_graphics.PreferredBackBufferWidth / 2) - 100;
            var height = (_graphics.PreferredBackBufferHeight / 2);
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

        private void QuitGameButton_Click(object sender, EventArgs e)
        {
            _game.Exit();
        }

        private void LoadGameButton_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            SceneManager.ChangeScene("SelectMenu",$"idk");
        }

        public override void LoadContent()
        {
            // Load content here
        }

        public override void Update()
        {
            foreach (var component in _components)
            {
                component.Update();
            }



        }

        public override void Draw(SpriteBatch _spriteBatch)
        {
            

            foreach (var component in _components)
                component.Draw(_spriteBatch);

            
        }

        public override void AddData(string additionalData = "")
        {
            return;
        }

    }
}



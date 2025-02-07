using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;





namespace SchoolFighter
{
    internal class CharecterSelectionScene : Scene
    {
        public CharecterSelectionScene(Game1 game, GraphicsDevice graphicsDevice)
          : base(game, graphicsDevice)
        {
            
        }
        private Rectangle charRect1, charRect2;
        private Texture2D charTexture1, charTexture2;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private Scene _currentState;
        public override void LoadContent()
        {
            charTexture1 = Globals.Content.Load<Texture2D>("Control\\Ryu");
            charTexture2 = Globals.Content.Load<Texture2D>("Control\\Charecter1");
            int newWidth = charTexture1.Width * 2;
            int newHeight = charTexture1.Height * 2;

            charRect1 = new Rectangle(50, 50, newWidth, newHeight);
            charRect2 = new Rectangle(300, 50, newWidth, newHeight);
        }
        public override void Draw( SpriteBatch spriteBatch)
        {

            
            spriteBatch.Begin();
            spriteBatch.Draw(charTexture1, charRect1, Color.White);
            spriteBatch.Draw(charTexture2, charRect2, Color.White);

            spriteBatch.End();
        }

        

        public override void Update()
        {
            currentMouseState = Mouse.GetState();

            if (charRect1.Contains(currentMouseState.X, currentMouseState.Y))
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {

                    _currentState.Update();

                    Debug.WriteLine("Rectangle clicked!");
                }
            }

            previousMouseState = currentMouseState;
        }

        public override void AddData(string additionalData = "")
        {
            throw new System.NotImplementedException();
        }
    }

}

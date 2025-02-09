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
        public CharecterSelectionScene()
          : base()
        {
            
        }
        private Rectangle charRect1, charRect2;
        private Texture2D charTexture1, charTexture2;
        private MouseState currentMouseState;
        private MouseState previousMouseState;
        private Scene _currentState;
        public override void LoadContent()
        {
            charTexture1 = Globals.Content.Load<Texture2D>("Ryu");
            charTexture2 = Globals.Content.Load<Texture2D>("Mai");
            int newWidth = charTexture1.Width/4 ;
            int newHeight = charTexture1.Height/4 ;

            charRect1 = new Rectangle(50, 50, newWidth, newHeight);
            charRect2 = new Rectangle(300, 50, newWidth, newHeight);
        }
        public override void Draw( SpriteBatch spriteBatch)
        {

            
            
            spriteBatch.Draw(charTexture1, charRect1, Color.White);
            spriteBatch.Draw(charTexture2, charRect2, Color.White);

            
        }

        

        public override void Update()
        {
            currentMouseState = Mouse.GetState();

            if (charRect1.Contains(currentMouseState.X, currentMouseState.Y))
            {
                if (currentMouseState.LeftButton == ButtonState.Pressed && previousMouseState.LeftButton == ButtonState.Released)
                {

                    SceneManager.ChangeScene("Game",$"idk");

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

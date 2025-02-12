using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.ComponentModel;


namespace SchoolFighter
{
    internal partial class Button : Component
    {
        #region Fields

        private MouseState _currentMouse;

        private GamePadState _currentGamePadState;

        private Rectangle myRectangle, myRectangle2;

        private SpriteFont _font;

        private bool _isHovering;

        private MouseState _previousMouse;

        private GamePadState _previousGamePadState;

        private Texture2D _texture;

        #endregion

        #region Properties

        public event EventHandler Click;

        public bool Clicked { get; private set; }

        public Color PenColour { get; set; }

        public Vector2 Position { get; set; }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            }
        }

        public string Text { get; set; }

        #endregion

        #region Methods


        public Button(Texture2D texture, SpriteFont font)
        {
            _texture = texture;

            _font = font;

            PenColour = Color.White;
        }
        public static void LoadContent()
        {

        }
        public override void Draw(SpriteBatch spriteBatch)
        {
            var colour = Color.White;
            var expansion = 20;
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);
            myRectangle = new Rectangle((int)Position.X, (int)Position.Y, _texture.Width, _texture.Height);
            if (_isHovering)
            {
                colour = Color.Gray;
                myRectangle.X = myRectangle.X - expansion / 2;
                myRectangle.Y = myRectangle.Y - expansion / 2;
                myRectangle.Width = (Rectangle.Width) + (expansion * 9 / 8);
                myRectangle.Height = (Rectangle.Height) + (expansion * 9 / 8);
                spriteBatch.Draw(_texture, myRectangle, colour);

            }
            
            if (!_isHovering)
            {
                myRectangle2.Width = Rectangle.Width * 3;
                myRectangle2.Height = Rectangle.Height * 3;
                spriteBatch.Draw(_texture, Rectangle, colour);

            }

            if (!string.IsNullOrEmpty(Text))
            {
                var x = (Rectangle.X + (Rectangle.Width / 2)) - (_font.MeasureString(Text).X / 2);
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (_font.MeasureString(Text).Y / 2);

                spriteBatch.DrawString(_font, Text, new Vector2(x, y), PenColour);
            }
        }

        public override void Update()
        {
            _previousMouse = _currentMouse;
            _currentMouse = Mouse.GetState();

            _previousGamePadState = _currentGamePadState;
            _currentGamePadState = GamePad.GetState(PlayerIndex.One);

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);
            var ControllerRect = new Rectangle(6, 6, 1, 1);


            _isHovering = false;

            if (mouseRectangle.Intersects(Rectangle))
            {
                _isHovering = true;

                if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
                {
                    Click?.Invoke(this, new EventArgs());
                }
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                Click?.Invoke(this, EventArgs.Empty);
            }

        }



        #endregion
    }
}


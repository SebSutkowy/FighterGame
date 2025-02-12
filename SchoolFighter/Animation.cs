using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    public class Animation
    {
        private readonly Texture2D _texture;
        private readonly FrameDetails[] _frames;
        private readonly float _frameSpeed;
        private float _timer;
        private int _currentFrame;

        public Animation(Texture2D texture, FrameDetails[] frames, float frameSpeed)
        {
            _texture = texture;
            _frames = frames;
            _frameSpeed = frameSpeed;
            _timer = 0;
            _currentFrame = 0;
        }

        public void Update()
        {
            _timer += Globals.deltaTime;

            if (_timer >= _frameSpeed)
            {
                _timer = 0;
                _currentFrame = (_currentFrame + 1) % _frames.Length;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 position, int row, float scale)
        {
            FrameDetails frame = _frames[_currentFrame];

            Rectangle sourceRectangle = new(frame.X, frame.Y, frame.Width, frame.Height);
            spriteBatch.Draw(_texture, new Rectangle((int)position.X, (int)position.Y, (int)(frame.Width * scale), (int)(frame.Height * scale)), sourceRectangle, Color.White);
        }

        public void Reset()
        {
            _currentFrame = 0;
            _timer = 0;
        }
    }
}

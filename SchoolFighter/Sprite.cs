using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace SchoolFighter
{
    internal class Sprite
    {
        public Vector2 Position { get; set; }
        public Texture2D Texture { get; set; }
        public Color Color { get; set; }
        public float Speed { get; set; }
        public Vector2 Velocity { get; set; }
        public Rectangle Hitbox { get; set; }
        public bool IsVisible { get; set; }
        public int currentFrames = 0;
        public int cycle_period = 20;
        public int frame_period;


        public Sprite()
        { }


        public Sprite(Texture2D _texture, Vector2 _position, Color _color, float _speed, Vector2 _velocity)
        {
            Texture = _texture;
            Position = _position;    
            Color = _color;
            Speed = _speed;
            Velocity = _velocity;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            IsVisible = true;
        }

        public void FrameUpdate()
        {
            frame_period = cycle_period / Globals.idleFrames.Count;
            currentFrames++;
            currentFrames = currentFrames % cycle_period;
            Texture = Globals.idleFrames[currentFrames / (frame_period)];
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsVisible)
                spriteBatch.Draw(Texture, Hitbox, Color);
            FrameUpdate();
        }

        public bool IsColliding(Rectangle hitbox)
        {
            if (Hitbox.Intersects(hitbox))
                return true;
            return false;
        }

    }
}

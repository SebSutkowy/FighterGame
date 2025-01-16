using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    public class Sprite
    {
        public Texture2D Texture { get; set; }
        public Vector2 Position { get; set; }
        public Color Color { get; set; }
        public float Velocity { get; set; }
        public Rectangle Hitbox { get; set; }
        public bool IsVisible { get; set; }

        public Sprite()
        { }

        public Sprite(Texture2D _texture, Vector2 _position, Color _color, float _velocity)
        {
            Texture = _texture;
            Position = _position;    
            Color = _color;
            Velocity = _velocity;
            Hitbox = new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height);
            IsVisible = true;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if(IsVisible)
                spriteBatch.Draw(Texture, Position, Color);
        }

    }
}

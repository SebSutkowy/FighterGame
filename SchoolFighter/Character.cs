using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SchoolFighter
{
    enum Direction
    {
        Left,
        Right
    }

    internal class Character : Sprite
    {
        float UpwardVelocity = 0f;
        bool Jumping = false;
        Direction Facing = Direction.Right;
        private int Team { get; set; }
        public Character() : base () { }
        public Character(Texture2D _texture, Vector2 _position, Color _color, float _velocity) : base(_texture, _position, _color, _velocity) { }

        public void Move()
        {
            float g = 1.0f;
            int[] movement = { Keyboard.GetState().IsKeyDown(Keys.A) ? 1 : 0, Keyboard.GetState().IsKeyDown(Keys.D) ? 1 : 0 };
            if(Keyboard.GetState().IsKeyDown(Keys.W) && !Jumping)
            {
                UpwardVelocity += Velocity*5;
                Jumping = true;
            }
            if(Position.Y + Texture.Height > Globals.winHeight)
            {
                UpwardVelocity = 0f;
                Position = new Vector2(Position.X, Globals.winHeight - Texture.Height);
                Jumping = false;
            }
            Position += new Vector2(Velocity*(movement[1] - movement[0]), -UpwardVelocity);
            UpwardVelocity -= g;
        }

        public AttacHitbox Attack()
        {
            if(!Keyboard.GetState().IsKeyDown(Keys.E))
            {
                return null;
            }
            if (Facing == Direction.Left)
            {
                return new AttacHitbox(Team, Position.X - Texture.Width, Position.Y, Texture.Width, Texture.Height, 15);
            }
            else if (Facing == Direction.Right)
            {
                return new AttacHitbox(Team, Position.X + Texture.Width, Position.Y, Texture.Width, Texture.Height, 15);
            }
            return null;
        }



    }
}

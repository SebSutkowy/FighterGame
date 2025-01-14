using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

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
        private const int AttackCooldownMax = 15;
        private int AttackCooldown = 0;
        int Falling = 0;
        public int Health { get; set; }
        public int Team { get; set; }
        public Character() : base () { }
        public Character(Texture2D _texture, Vector2 _position, Color _color, float _velocity, int team) : base(_texture, _position, _color, _velocity)
        {
            Team = team;
        }

        public void Move()
        { 
            int[] movement = { Globals.keys.IsKeyDown(Keys.A) ? 1 : 0, Globals.keys.IsKeyDown(Keys.D) ? 1 : 0 };
            if (Globals.keys.IsKeyDown(Keys.W) && !Jumping)
            {
                UpwardVelocity = Velocity * 5;
                Jumping = true;
            }
            if (Position.Y + Texture.Height > Globals.winHeight)
            {
                UpwardVelocity = 0f;
                Position = new Vector2(Position.X, Globals.winHeight - Texture.Height);
                Jumping = false;
            }
            if (AttackCooldown <= 0 || Falling > 0 )
            {
                Position += new Vector2(Velocity * (movement[1] - movement[0]), -UpwardVelocity);
                if (movement[1] - movement[0] < 0)
                {
                    Facing = Direction.Left;
                }
                else if (movement[1] - movement[0] > 0)
                {
                    Facing = Direction.Right;
                }
                UpwardVelocity -= Globals.g;
            }
            AttackCooldown = MathHelper.Max(AttackCooldown-1, 0);
            Falling = MathHelper.Max(Falling-1, 0);
        }

        public AttacHitbox Attack()
        {
            if(Globals.IsKeyPressed(Keys.S) && Jumping)
            {
                AttackCooldown = AttackCooldownMax;
                Falling = AttackCooldownMax;
                UpwardVelocity = -50*Globals.g;
                Debug.WriteLine("Here");
                return new AttacHitbox(Team, 0, Texture.Height, Texture.Width, Texture.Height/2, AttackCooldownMax, 1, this);
            }
            if (Globals.IsKeyPressed(Keys.E) && Facing == Direction.Left)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttacHitbox(Team, Position.X - Texture.Width*1.25f, Position.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax, 1, Vector2.Zero);
            }
            else if (Globals.IsKeyPressed(Keys.E) && Facing == Direction.Right)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttacHitbox(Team, Position.X + Texture.Width, Position.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax, 1, Vector2.Zero);
            }
            return null;
        }



    }
}

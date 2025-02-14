using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;
using System.Collections.Generic;

namespace SchoolFighter
{
    enum Directions
    {
        None,
        Left,
        Right,
        Up,
        Down
    }

    internal class Character : Sprite
    {
        private bool Jumping = false;
        private Directions Facing = Directions.Right;
        private const int AttackCooldownMax = 15;
        private int AttackCooldown = 0;
        private int Falling = 0;
        private int StunTimer = 0;
        private const int StunLength = 60;
        private bool UpwardsKnockback = false;
        private bool Crouching = false;
        private int KnockbackDirection = 0;
        private int CurrentFrame = 0;
        private const int CyclePeriod = 30;
        
        public List<Texture2D> Textures { get; set; }
        public int Health { get; set; }
        public int Strength { get; set; }
        public int Team { get; set; }
        public Dictionary<string, Keys> KeyBinds = new Dictionary<string, Keys>()
        {
            {"Move left", Keys.A },
            {"Move right", Keys.D },
            {"Jump", Keys.W },
            {"Crouch", Keys.S },
            {"Punch", Keys.E }
        };

        public Character() : base () { }
        public Character(Texture2D _texture, Vector2 _position, Color _color, float _speed, Vector2 _velocity, int health, int strength, int team, List<Texture2D> _textures) : base(_texture, _position, _color, _speed, _velocity)
        {
            Health = health;
            Strength = strength;
            Team = team;
            Textures = _textures;
        }

        public void SetBinds(Dictionary<string, Keys> binds)
        {
            KeyBinds = binds;
        }

        public void Update(bool enableMovement = true)
        {
            // check for attacks
            if (AttackCooldown <= 0 || Falling > 0)
            {
                Position += new Vector2(0, -Velocity.Y * Globals.deltaTime);
                Velocity -= new Vector2(0, Globals.g);
            }
            if (Hitbox.Bottom > Globals.winHeight)
            {
                Velocity = new Vector2(Velocity.X, 0);
                Position = new Vector2(Position.X, Globals.winHeight - Texture.Height);
                Jumping = false;
            }
            if (StunTimer <= 0)
            {
                UpwardsKnockback = false;
            }
            Crouching = Jumping ? false : Crouching;
            (int damage, Directions direction) = HitboxManager.CheckCollisions(this, Team);
            if (damage != 0 && StunTimer <= 0)
            {
                StunTimer = StunLength;
                Debug.WriteLine($"Health: {Health} - {damage}");
                Health -= Math.Abs(damage);
                Debug.WriteLine($"Health: {Health}♥");
                if (Directions.Left == direction) KnockbackDirection = -1;
                else if (Directions.Right == direction) KnockbackDirection = 1;
            }
            if(enableMovement && StunTimer <= 0)
            {
                Move();
                HitboxManager.AddHitbox(Attack());
                KnockbackDirection = 0;
            }
            if(Math.Abs(StunTimer) > 0)
            {
                Debug.WriteLine(StunTimer);
                Position += new Vector2(0.5f * StunTimer * KnockbackDirection * Globals.deltaTime, 0);
                Debug.WriteLine($"Horizontal KB: {0.5f * StunTimer * Globals.deltaTime}");
                if (!UpwardsKnockback)
                {
                    Velocity = new Vector2(0, Globals.g * 3f);
                    UpwardsKnockback = true;
                }
                Jumping = true;
            }
            Hitbox = !Crouching ?
                new Rectangle((int)Position.X, (int)Position.Y, Texture.Width, Texture.Height) :
                new Rectangle((int)Position.X, (int)Position.Y + Texture.Height / 4, Texture.Width, 3*Texture.Height / 4);
            AttackCooldown = MathHelper.Max(AttackCooldown - 1, 0);
            Falling = MathHelper.Max(Falling - 1, 0);
            StunTimer = Math.Sign(StunTimer)*(Math.Abs(StunTimer) - 1);
            

        }



        public void Move()
        { 
            int[] movement = { Globals.keys.IsKeyDown(KeyBinds["Move left"]) ? 1 : 0, Globals.keys.IsKeyDown(KeyBinds["Move right"]) ? 1 : 0 };
            if (Globals.keys.IsKeyDown(KeyBinds["Jump"]) && !Jumping)
            {
                Velocity = new Vector2(Velocity.X, Speed * 5); // Jump
                Jumping = true;
            }
            if (AttackCooldown <= 0 || Falling > 0 )
            {
                Position += new Vector2(Speed * (movement[1] - movement[0]) * Globals.deltaTime, 0);
                if (movement[1] - movement[0] < 0) // Change the directions the player is facing
                {
                    Facing = Directions.Left;
                }
                else if (movement[1] - movement[0] > 0)
                {
                    Facing = Directions.Right;
                }
            }
        }

        public AttackHitbox Attack()
        {
            // Generate Hitboxes
            if (AttackCooldown > 0) return null;
            if (Globals.IsKeyPressed(KeyBinds["Crouch"]) && Jumping)
            {
                AttackCooldown = AttackCooldownMax;
                Falling = AttackCooldownMax;
                Velocity = new Vector2(Velocity.X, -50*Globals.g);
                return new AttackHitbox(Team, 0, 0, Texture.Width, 3*Texture.Height/2, AttackCooldownMax/2, (int)(Strength*1.25f), Directions.Down, this);
                // Ground Pound
            }
            Crouching = (Globals.keys.IsKeyDown(KeyBinds["Crouch"]) && !Jumping) ? true : false; 
            if (Globals.IsKeyPressed(KeyBinds["Punch"]) && Facing == Directions.Left)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttackHitbox(Team, Hitbox.X - Hitbox.Width*0.25f, Hitbox.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax/2, Strength, Directions.Left, Vector2.Zero);
                // Left punch
            }
            else if (Globals.IsKeyPressed(KeyBinds["Punch"]) && Facing == Directions.Right)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttackHitbox(Team, Hitbox.X, Hitbox.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax/2, Strength, Directions.Right, Vector2.Zero);
                // Right punch
            }
            return null;
        }

        public void Draw(SpriteBatch spriteBatch, bool flip=false)
        {
            Debug.WriteLine($"Current frame: {CurrentFrame}");
            CurrentFrame++;
            CurrentFrame = (CurrentFrame) % CyclePeriod;
            int frame = CurrentFrame / (CyclePeriod / Textures.Count);
            Vector2 Origin = new Vector2(Textures[frame].Width/2,Textures[frame].Height/2);
            spriteBatch.Draw(Textures[frame], Hitbox, Hitbox, Color.White, 0, Origin, (flip ? SpriteEffects.FlipHorizontally : SpriteEffects.None), 0.5f);
        }

    }
}

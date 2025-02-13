using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;

using System.Collections.Generic;

using Microsoft.Xna.Framework.Content;
using SharpDX.Direct3D9;

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

        
        private const int CyclePeriod = 30;
        private AnimationManager _animationManager = new AnimationManager();
        private Texture2D _texture;
        private const float JumpDuration = 0.75f;
        private Dictionary<string,Keys>KeyBinds = new Dictionary<string,Keys>();    


        public List<Texture2D> Textures { get; set; }

        public int Health { get; set; }
        public int Strength { get; set; }
        public int Team { get; set; }
        public Character() : base () { }
        public Character(Texture2D _texture, Vector2 _position, Color _color, float _speed, Vector2 _velocity, int health, int strength, int team) : base(_texture, _position, _color, _speed, _velocity)
        {
            Health = health;
            Strength = strength;
            Team = team;
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

        public void LoadContent(ContentManager content)
        {
            _texture = content.Load<Texture2D>("Ryu");

            // Idle animation frames
            _animationManager.AddAnimation("Idle", new Animation(_texture, new[]
            {
                new FrameDetails(75, 14, 60, 89),
                new FrameDetails(7, 14, 59, 90),
                new FrameDetails(277, 11, 58, 92),
                new FrameDetails(211, 10, 55, 93)
            }, 0.2f), 0);

            // Walk Right animation frames
            _animationManager.AddAnimation("WalkRight", new Animation(_texture, new[]
            {
                new FrameDetails(9, 136, 53, 83),
                new FrameDetails(78, 130, 48, 90),
                new FrameDetails(152, 128, 64, 92),
                new FrameDetails(229, 130, 45, 91),
                new FrameDetails(307, 128, 54, 91),
                new FrameDetails(371, 128, 50, 89)
            }, 0.1f), 2);

            // Walk Left animation frames
            _animationManager.AddAnimation("WalkLeft", new Animation(_texture, new[]
            {
                new FrameDetails(777, 128, 61, 87),
                new FrameDetails(430, 124, 59, 90),
                new FrameDetails(495, 124, 57, 90),
                new FrameDetails(559, 124, 58, 90),
                new FrameDetails(631, 125, 58, 91),
                new FrameDetails(707, 126, 57, 89)
            }, 0.1f), 1);

            // Jump animation frames
            _animationManager.AddAnimation("Jump", new Animation(_texture, new[]
            {
                new FrameDetails(67, 224, 56, 184),
                new FrameDetails(138, 223, 50, 89),
                new FrameDetails(197, 233, 54, 77),
                new FrameDetails(259, 240, 48, 70),
                new FrameDetails(319, 234, 48, 89),
                new FrameDetails(375, 244, 55, 109)
            }, JumpDuration / 3f), 3);

            _animationManager.AddAnimation("Crouch", new Animation(_texture, new[]
            {
                new FrameDetails(551, 21, 53, 83),
                new FrameDetails(611, 36, 57, 69),
                new FrameDetails(679, 44, 61, 69),
            }, 0.1f), 4);

            // Attack animations
            _animationManager.AddAnimation("LightPunch", new Animation(_texture, new[]
            {
                new FrameDetails(9, 365, 54, 91),
                new FrameDetails(88, 365, 92, 91)
            }, AttackCooldown / 2f), 5);

            _animationManager.AddAnimation("MediumHeavyPunch", new Animation(_texture, new[]
            {
                new FrameDetails(6, 466, 60, 94),
                new FrameDetails(86, 465, 74, 95)
            }, AttackCooldown / 2f), 6);

            _animationManager.AddAnimation("HeavyPunch", new Animation(_texture, new[]
            {
                new FrameDetails(175, 465, 108, 94)
            }, AttackCooldown / 1f), 7);

            _animationManager.AddAnimation("LightMediumKick", new Animation(_texture, new[]
            {
                new FrameDetails(87, 923, 66, 92)
            }, AttackCooldown / 1f), 8);

            _animationManager.AddAnimation("MediumKick", new Animation(_texture, new[]
            {
                new FrameDetails(162, 922, 114, 94)
            }, AttackCooldown / 1f), 9);

            _animationManager.AddAnimation("HeavyKick", new Animation(_texture, new[]
            {
                new FrameDetails(5, 1196, 61, 94),
                new FrameDetails(72, 1191, 92, 107)
            }, AttackCooldown / 2f), 10);
        }

        public void Move()
        { 
            int[] movement = { Globals.keys.IsKeyDown(Keys.A) ? 1 : 0, Globals.keys.IsKeyDown(Keys.D) ? 1 : 0 };
            if (Globals.keys.IsKeyDown(Keys.W) && !Jumping)
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
            if(Globals.IsKeyPressed(Keys.S) && Jumping)
            {
                AttackCooldown = AttackCooldownMax;
                Falling = AttackCooldownMax;
                Velocity = new Vector2(Velocity.X, -50*Globals.g);
                return new AttackHitbox(Team, 0, 0, Texture.Width, 3*Texture.Height/2, AttackCooldownMax/2, (int)(Strength*1.25f), Directions.Down, this);
                // Ground Pound
            }
            Crouching = (Globals.keys.IsKeyDown(Keys.S) && !Jumping) ? true : false; 
            if (Globals.IsKeyPressed(Keys.E) && Facing == Directions.Left)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttackHitbox(Team, Hitbox.X - Hitbox.Width*0.25f, Hitbox.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax/2, Strength, Directions.Left, Vector2.Zero);
                // Left punch
            }
            else if (Globals.IsKeyPressed(Keys.E) && Facing == Directions.Right)
            {
                AttackCooldown = AttackCooldownMax;
                return new AttackHitbox(Team, Hitbox.X, Hitbox.Y, Texture.Width*1.25f, Texture.Height/2, AttackCooldownMax/2, Strength, Directions.Right, Vector2.Zero);
                // Right punch
            }
            return null;
        }

    }
}

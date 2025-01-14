using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace SchoolFighter
{
    internal class AttacHitbox
    {
        public Rectangle Hitbox { get; set; }
        public int Team { get; set; }
        public int Lifespan { get; set; }
        public int Damage { get; set; }
        public Vector2 Velocity { get; set; }
        public Sprite Owner { get; set; }
        public Vector2 RelativePosition {get; set;}
        
        public AttacHitbox(int _team, float x, float y, float width, float height, int lifespan, int damage, Vector2 velocity)
        {
            Team = _team;
            Hitbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Lifespan = lifespan;
            Damage = damage;
            Velocity = velocity;
            Owner = null;
        }
        public AttacHitbox(int _team, float x, float y, float width, float height, int lifespan, int damage, Sprite owner)
        {
            Team = _team;
            RelativePosition = new Vector2(x, y);
            Hitbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Lifespan = lifespan;
            Damage = damage;
            Owner = owner;
            Velocity = Vector2.Zero;
        }

        public void Update()
        {
            Lifespan--;
            if(Velocity != Vector2.Zero)
            {
                Hitbox = new Rectangle(Hitbox.X + (int)Velocity.X, Hitbox.Y + (int)Velocity.Y, Hitbox.Width, Hitbox.Height);
            }
            if(Owner != null)
            {
                Hitbox = new Rectangle((int)Owner.Position.X + (int)RelativePosition.X, (int)Owner.Position.Y + (int)RelativePosition.Y, Hitbox.Width, Hitbox.Height);
            }
            // check for collisions here maybe
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals._playerTexture, Hitbox, Color.Blue);
        }
    }
}
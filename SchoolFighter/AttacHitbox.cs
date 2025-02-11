using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;

namespace SchoolFighter
{
    internal class AttackHitbox
    {
        public Rectangle Hitbox { get; set; }
        public int Team { get; set; }
        public int Lifespan { get; set; }
        public int Damage { get; set; }
        public Vector2 Velocity { get; set; }
        public Sprite Owner { get; set; }
        public Vector2 RelativePosition {get; set;}
        
        public Directions Direction { get; set; }
        public AttackHitbox(int _team, float x, float y, float width, float height, int lifespan, int damage, Directions direction, Vector2 velocity)
        {
            Team = _team;
            Hitbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Lifespan = lifespan;
            Damage = damage;
            Direction = direction;
            Velocity = velocity;
            Owner = null;
        }
        public AttackHitbox(int _team, float x, float y, float width, float height, int lifespan, int damage, Directions direction, Sprite owner)
        {
            Team = _team;
            RelativePosition = new Vector2(x, y);
            Hitbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Lifespan = lifespan;
            Damage = damage;
            Direction = direction;
            Owner = owner;
            Velocity = Vector2.Zero;
        }

        public bool CheckCollision(Sprite player)
        {
            if (Hitbox.Intersects(player.Hitbox)) return true;
            return false;
        }
        public bool CheckCollision(Rectangle hitbox)
        {
            if (Hitbox.Intersects(hitbox)) return true;
            return false;
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
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //s]priteBatch.Draw(Globals._blankTexture, Hitbox, Color.CornflowerBlue);
        }
    }
}
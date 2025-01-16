using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    public class AttacHitbox
    {
        public Rectangle Hitbox { get; set; }
        public int Team { get; set; }
        public int Lifespan { get; set; }
        public AttacHitbox(int _team, float x, float y, float width, float height, int lifespan)
        {
            Team = _team;
            Hitbox = new Rectangle((int)x, (int)y, (int)width, (int)height);
            Lifespan = lifespan;
        }
         
        public void Update()
        {
            Lifespan--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals._playerTexture, Hitbox, Color.Blue);
        }
    }
}
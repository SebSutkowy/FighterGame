
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace SchoolFighter
{
    internal class HealthBar
    {
        public int TotalHealth { get; set; }
        public Vector2 Position { get; set; }
        public Vector2 Size { get; set; }
        public Directions Direction { get; set; }
        public Rectangle healthBar;


        public HealthBar(int totalHealth, Vector2 position, Vector2 size, Directions direction) 
        { 
            TotalHealth = totalHealth;
            Position = position;
            Size = size;
            Direction = direction;
        }

        public void Update(int currentHealth)
        {
            int x = 0;
            if (Direction == Directions.Left)
            {
                x = (int)(Size.X * (1 - (float)currentHealth / (float)TotalHealth) + Position.X);
            }
            else if (Direction == Directions.Right)
            {
                x = (int)Position.X;
            }
            healthBar = new Rectangle(x, (int)Position.Y, (int)(Size.X * ((float)currentHealth / (float)TotalHealth)), (int)Size.Y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Globals.healthBar, healthBar, Color.Red);
        }
    }  
}

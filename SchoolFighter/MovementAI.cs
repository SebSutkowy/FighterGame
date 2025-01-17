using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SchoolFighter
{
    public class MovementAI 
    {
        public Vector2 velocity;


        public void Direction(Character player , Character bot, float speed)
        {
            Vector2 direction = player.Position - bot.Position;
            direction.Normalize();

            velocity = speed * direction;

            if(player.Position.X - bot.Position.X < 20 || player.Position.X + bot.Position.X > 20)
            {
                velocity = Vector2.Zero;
            }
            bot.Position += velocity;
            
        }
    }
}

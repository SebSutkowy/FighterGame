using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SchoolFighter
{
    public class MovementAI 
    {
        public Vector2 velocity;


        public void Direction(GameTime gameTime, Character player , Character bot, float speed)
        {
            Vector2 direction = player.Position - bot.Position;
            direction.Normalize();

            velocity = speed * direction;

            bot.Position += (velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
            
        }
    }
}

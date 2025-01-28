using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace SchoolFighter
{
    public class MovementAI 
    {
        public Vector2 velocity;
        public int frames = 120;


        public void Direction(Character player , Character bot, float speed)
        {
            frames -= 1;
            Vector2 direction = player.Position - bot.Position;
            direction.Normalize();
            velocity = speed * direction;

            bool wait = false;

            if (!wait)
            {
                if (player.Position.X - bot.Position.X >= player.Texture.Width || bot.Position.X - player.Position.X >= player.Texture.Width)
                {
                    frames = 120;
                }
                else if(frames > 0)
                {
                    bot.Position += velocity;
                }
            }
            else if (frames <= 0)
            {
                 
            }

        }
    }
}

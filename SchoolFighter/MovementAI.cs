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


        public void Direction(Character player , Character bot, float speed)
        {
            Vector2 direction = player.Position - bot.Position;
            direction.Normalize();
            velocity = speed * direction;

            bool stop = false;

            if (!stop)
            {
                if (player.Position.X - bot.Position.X >= 200 || bot.Position.X - player.Position.X >= 300)
                {
                    stop = true;
                }
                else
                {
                    bot.Position += velocity;
                }
            }
            if (stop)
            {
                Task.Delay(100);
                stop = false;
            }

        }
    }
}

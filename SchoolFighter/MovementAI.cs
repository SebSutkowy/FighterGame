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
        public int frames = 0;
        public bool wait = false;


        public void Direction(Character player , Character bot, float speed)
        {

            Vector2 direction = player.Position - bot.Position;
            direction.Normalize();
            velocity = speed * direction;

            //Debug.WriteLine("general: " + frames);
            Debug.WriteLine(wait);

            if (wait)
            {
                while (frames !<= 0)
                {
                    //Debug.WriteLine("local: " + frames);
                    frames -= 1;
                }
                if (frames <= 0)
                {
                    wait = false;
                }
            }

            if (!wait)
            {
                if (player.isCollided(bot.Hitbox))
                {
                    frames = 120;
                    wait = true;
                }
                if (frames > 0)
                {
                    bot.Position += velocity;
                }
            }

        }
    }
}

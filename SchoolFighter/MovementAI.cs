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

            System.Diagnostics.Debug.WriteLine(player.Position.X - bot.Position.X);

            if (player.Position.X - bot.Position.X == 1 || player.Position.X - bot.Position.X == -2)
            {
                float time = 0;
                bool reset = false;
                time += Globals.singleSecond;
                if (time < 5)
                    reset = true;
                else if(time > 5)
                {
                    bot.Position += velocity;
                    time = 0;
                }
            }
            else
            {
                bot.Position += velocity;
            }

        }
    }
}

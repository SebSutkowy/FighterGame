using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace SchoolFighter
{
    public class MovementAI 
    {
        public Vector2 aiPos;
        private Texture2D aiTex;
        public Vector2 velocity;


        public void Update(GameTime gameTime, Vector2 playerPos, float speed)
        {
            Vector2 direction = playerPos - aiPos;
            direction.Normalize();

            velocity = speed * direction;

            aiPos += (velocity * (float)gameTime.ElapsedGameTime.TotalSeconds);
            
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(aiTex, aiPos, Color.White);
        }
    }
}

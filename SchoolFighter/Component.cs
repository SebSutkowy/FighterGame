using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;


namespace SchoolFighter
{
    public abstract class Component
    {


        public abstract void Draw(SpriteBatch spriteBatch);

        public abstract void Update();

        
    }
}

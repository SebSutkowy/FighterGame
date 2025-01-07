using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    internal abstract class Scene
    {

        public Scene() { }
        public abstract void LoadContent();
        public abstract void Update();
        public abstract void Draw(SpriteBatch spriteBatch);
    }
}

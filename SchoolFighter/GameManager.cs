using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
namespace SchoolFighter
{
    public static class GameManager
    {
        private static Character _hero = new Character();



        public static void LoadContent(ContentManager content)
        {
            _hero.LoadContent(content);
        }

        public static void Update()
        {
            
            _hero.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _hero.Draw(spriteBatch);
        }
    }
}

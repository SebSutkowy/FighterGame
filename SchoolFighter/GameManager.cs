using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SchoolFighter;
using Microsoft.Xna.Framework.Input;

namespace SchoolFighter
{
    public static class GameManager
    {
        private static Character _player = new Character();



        public static void LoadContent(ContentManager content)
        {
            _player.LoadContent(content);
        }

        public static void Update()
        {
            
            _player.Update();
        }

        public static void Draw(SpriteBatch spriteBatch)
        {
            _player.Draw(spriteBatch);
        }
    }
}

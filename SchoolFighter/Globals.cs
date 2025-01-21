using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SchoolFighter
{
    public static class Globals
    {
        public static Texture2D _playerTexture; // blank texture
        public static int winWidth = 1920;
        public static int winHeight = 1080; // window dimensions
        public static float g = 1.0f; // gravity
        public static float deltaTime;
        public static float singleSecond;

        public static void UpdateTime(GameTime gt)
        {
            deltaTime += (float)gt.ElapsedGameTime.TotalSeconds;
            singleSecond = deltaTime - (deltaTime - 1);

        }
    }
}
